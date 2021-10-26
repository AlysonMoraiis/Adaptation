using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float velocidade;

    void Update()
    {
        rb2d.velocity = new Vector2(0, velocidade);
    }

     private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }

        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }


}
