using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brokenground : MonoBehaviour
{

    public Animator anim;

    private void OnCollisionEnter2D(Collision2D other) {
       if(other.gameObject.tag == "Player")
       {
           anim.Play("chãoquebravel");
           Destroy(this.gameObject, 0.4f);
       }
   }
}
