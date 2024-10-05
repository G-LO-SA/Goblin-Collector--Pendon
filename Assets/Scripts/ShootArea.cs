using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ShootArea : MonoBehaviour
{
    [SerializeField] Archer _arch;
    private void OnTriggerEnter2D(Collider2D other)
    {
 
        if (other.CompareTag("Goblin"))
        {
            _arch.inarea = true;
        }


    }

    private void OnTriggerExit2D(Collider2D other)
    {
    
        if (other.CompareTag("Goblin"))
        {
            _arch.inarea = false;
        }
    }
}

  
