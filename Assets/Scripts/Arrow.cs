using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Arrow : MonoBehaviour
{
    [SerializeField] GameObject arrow;

    /* private void OnCollisionEnter2D(Collision2D other)
     {
         Goblin _gobs = other.collider.GetComponent<Goblin>();

         if (_gobs)
         {
             _gobs.bagpresence = 0;
             _gobs.havebag = false;
             Destroy(arrow, 0.1f);
         }

         if (other.collider.CompareTag("Border") && other.collider.CompareTag("CBag"))
         {
             Destroy(arrow);
         }
     }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        Goblin _gobs = other.GetComponent<Goblin>();

        if (_gobs)
        {
            _gobs.bagpresence = false;
            _gobs.havebag = false;
            Destroy(arrow, 0.1f);
        }

        if (other.CompareTag("Border") && other.CompareTag("CBag"))
        {
            Destroy(arrow);
        }
    }
}
   
