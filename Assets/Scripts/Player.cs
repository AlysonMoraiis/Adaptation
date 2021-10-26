using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public ParticleSystem explosion;
    public GameObject[] animals ;
    private bool canTransform;
    public int hunger;
    private SpriteRenderer sprite;
    private Player spr;

    private GameObject healthBar;
    private HungryBar HBar;
    [Header("Movement")]
    public float speed = 2;
    private PlayerJump PJump;
    public float move;
    public bool podeAndar;
    public bool Tar;
    private bool Coe;
    private bool Gue;
    private bool Gor;
    private bool CoeCole;
    private bool TarCole;
    private bool GueCole;
    private bool GorCole;


    
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        PJump = GetComponent<PlayerJump>();
        sprite = GetComponent<SpriteRenderer>();
        healthBar = GameObject.Find("HealthBar");
        HBar = healthBar.GetComponent<HungryBar>();
        //spr = GetComponent<Flip>();
        canTransform = true;
        podeAndar = true;
        Humano();
    }

    private void FixedUpdate() 
    {
        if(podeAndar)
        {
            rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
        } else
        {
        rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
        move = Input.GetAxis("Horizontal");
        //rb2d.velocity = new Vector2(move * speed, rb2d.velocity.y);
        

        Vector3 rotation = transform.eulerAngles;
        if(move > 0f)
        {
            rotation.y = 0f;
        }
        if(move < 0f)
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;
    }

  
    void Update()
    {
        
        if (Input.GetKeyDown("1") && canTransform && CoeCole)
        {
            CreateExplosion();
            Coelho();
        }

        if (Input.GetKeyDown("2") && canTransform && TarCole)
        {
            CreateExplosion();
            Tartaruga();
        }

        if (Input.GetKeyDown("3") && canTransform && GueCole)
        { 
            CreateExplosion();
            Guepardo();
        }

        if (Input.GetKeyDown("4") && canTransform && GorCole)
        {
            CreateExplosion();
            Gorila();
        }
    }

    private void Humano()
    {
        speed = 5;
        hunger = 1;
        PJump.jumpForce = 5;
        animals[0].SetActive(false);
        animals[1].SetActive(false);
        animals[2].SetActive(false);
        animals[3].SetActive(false);
        animals[4].SetActive(true);
        Tar = false;
        Coe = false;
        Gue = false;
        Gor = true;
    }

    private void Coelho()
    {
        
        speed = 7;
        hunger = 3;
        PJump.jumpForce = 12;
        animals[0].SetActive(true);
        animals[1].SetActive(false);
        animals[2].SetActive(false);
        animals[3].SetActive(false);
        animals[4].SetActive(false);
        StartCoroutine(Countdown());
        Tar = false;
        Coe = true;
        Gue = false;
        Gor = false;
        
    }

    private void Tartaruga()
    {
        speed = 3;
        hunger = 1;
        PJump.jumpForce = 0;
        animals[0].SetActive(false);
        animals[1].SetActive(true);
        animals[2].SetActive(false);
        animals[3].SetActive(false);
        animals[4].SetActive(false);
        StartCoroutine(Countdown());
        Tar = true;
        Coe = false;
        Gue = false;
        Gor = false;
    }

     private void Guepardo()
    {
        speed = 12;
        hunger = 5;
        PJump.jumpForce = 6;
        animals[0].SetActive(false);
        animals[1].SetActive(false);
        animals[2].SetActive(true);
        animals[3].SetActive(false);
        animals[4].SetActive(false);
        StartCoroutine(Countdown());
        Tar = false;
        Coe = false;
        Gue = true;
        Gor = false;
    }

    private void Gorila()
    {
        speed = 6;
        hunger = 5;
        PJump.jumpForce = 6;
        animals[0].SetActive(false);
        animals[1].SetActive(false);
        animals[2].SetActive(false);
        animals[3].SetActive(true);
        animals[4].SetActive(false);
        StartCoroutine(Countdown());
        Tar = false;
        Coe = false;
        Gue = false;
        Gor = true;
    }

    private void CreateExplosion()
    {
        explosion.Play();
    }

    IEnumerator Countdown ()
    {
        canTransform = false;
        for (float i = 0f; i < 1f; i += 1f)
        {
            yield return new WaitForSeconds(2f);
        }
        canTransform = true;
    }


    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Cenoura") && Coe)
        {
            Destroy(other.gameObject);
            HBar.currentHealth += 20;
        }

        if(other.gameObject.CompareTag("Alface") && Tar)
        {
            Destroy(other.gameObject);
            HBar.currentHealth += 20;
        }

        if(other.gameObject.CompareTag("Carne") && Gue)
        {
            Destroy(other.gameObject);
            HBar.currentHealth += 20;
        }

        if(other.gameObject.CompareTag("Banana") && Gor)
        {
            Destroy(other.gameObject);
            HBar.currentHealth += 20;
        }

        if(other.gameObject.CompareTag("CoeCole"))
        {
            CoeCole = true;
        }

        if(other.gameObject.CompareTag("TarCole"))
        {
            TarCole = true;
        }

        if(other.gameObject.CompareTag("GueCole"))
        {
            GueCole = true;
        }

        if(other.gameObject.CompareTag("GorCole"))
        {
            GorCole = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            HBar.TakeDamage(20);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("FinalTela"))
        {
            HBar.currentHealth = 0;
            Invoke("ReloadLevel", 2f);
            HBar.isAlive = false;
        }
    }


    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /* public void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if(move > 0.01f)
        {
            rotation.y = 0f;
        }
        else if (move < 0.01f)
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;
    }*/
}
