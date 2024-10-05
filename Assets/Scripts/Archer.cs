using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Archer : MonoBehaviour
{
    [SerializeField] GameObject arrow;
    [SerializeField] Transform archer;
    [SerializeField] Transform Target;
    [SerializeField] Animator animator;
    public bool inarea = false;
    public float arrowspeed = 1.15f;
    public float timecount = 3f;
    private float frequency = 1f;

    private void FixedUpdate()
    {
        if (inarea == true)
        {
            if (frequency < timecount)
            {
                frequency += Time.deltaTime;
            }

            else
            {
                shooting();
                frequency = 0f;
            }
            
        }
    }

    private void Update()
    {
        animator.SetBool("Shooting", inarea);
    }


    private void shooting()
    {
        Vector2 _archer = archer.position;
        Vector2 targetDirection = (Target.position - archer.position);

        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;

        var _arrow = Instantiate(arrow, _archer, Quaternion.Euler(0,0,angle)); 
        _arrow.GetComponent<Rigidbody2D>().AddForce(targetDirection * arrowspeed);
        Destroy (_arrow,3f);
    }
}
