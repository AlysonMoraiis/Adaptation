/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comidinhas : MonoBehaviour
{
    private GameObject pp;
    private Player player;

    private GameObject healthBar;
    private HungryBar HBar;
    public int animal;


    void Awake()
    {
        pp = GameObject.Find("Player");
        player = pp.GetComponent<Player>();
        healthBar = GameObject.Find("HealthBar");
        HBar = healthBar.GetComponent<HungryBar>();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Player") && player.Coe)
        {
            Destroy(this.gameObject);
            HBar.currentHealth += 5;
        }
    }
    

   
}*/
