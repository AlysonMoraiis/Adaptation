using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HungryBar : MonoBehaviour
{
    public Slider slider;
    public int maxHealth = 100;
    public int currentHealth;
    public bool isAlive;

    private float currentTime = 0f;
    private float startingTime = 2f;

    private GameObject player;
    private Player HBar;
    public bool invuneravel;


    private void Start() {
        currentHealth = maxHealth;
        isAlive = true;
        currentTime = startingTime;
        player = GameObject.Find("Player");
        HBar = player.GetComponent<Player>();

    }


    private void Update() 
    {
        if (currentHealth < 1)
        {
            isAlive = false;
            Invoke("ReloadLevel", 2f);
        }

        currentTime -= 1 * Time.deltaTime;

        if (currentTime <= 0)
        {
            currentHealth -= HBar.hunger;
            currentTime = 2;
        }

        if (Input.GetKeyDown("l"))
        {
            TakeDamage(100);
        }
    }

    private void FixedUpdate() 
    {
       if(currentHealth > maxHealth)
       {
           currentHealth = maxHealth;
       }
        if(currentHealth >= 1)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }

        SetHealth(currentHealth);
    }
    
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    
    public void TakeDamage(int damage)
    {
        if(isAlive && invuneravel == false)
        {
        currentHealth -= damage;
        }

        if (currentHealth <= 1)
            {
                currentHealth = 0;
                isAlive = false;
                Invoke("ReloadLevel", 2f);
            }
    }  

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
