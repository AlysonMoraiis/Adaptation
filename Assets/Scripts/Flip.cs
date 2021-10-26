using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    private SpriteRenderer sprite;
    private GameObject pp;
    private Player player;
    public Animator anim;

    private GameObject healthBar;
    private HungryBar HBar;


    private void Awake() {
        pp = GameObject.Find("Player");
        player = pp.GetComponent<Player>();

        healthBar = GameObject.Find("HealthBar");
        HBar = healthBar.GetComponent<HungryBar>();
        
    }

    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Z) && player.Tar)
        {
            anim.SetBool("DefMode", true);
            HBar.invuneravel = true;
            player.podeAndar = false;
        }

        if(Input.GetKeyUp(KeyCode.Z))
        {
            anim.SetBool("DefMode", false);
            HBar.invuneravel = false;
            player.podeAndar = true;
        }
    }

    private void FixedUpdate() {
        anim.SetFloat("Speed", Mathf.Abs(player.move));
        anim.SetBool("JumpFall", player.rb2d.velocity.y != 0);
    }


}
