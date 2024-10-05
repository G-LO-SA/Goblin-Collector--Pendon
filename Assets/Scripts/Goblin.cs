using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using Unity.VisualScripting.ReorderableList;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class Goblin : MonoBehaviour
{
    [SerializeField] Transform IdleWhere;
    [SerializeField] Transform Gobhouse;
    [SerializeField] float speed;
    [SerializeField] GameObject[] bag;
    public Animator RedGoblin;

    Vector3 circlesize;
    public bool havebag = false;
    public bool bagpresence;
    private int score = 0;

    void Start()
    {
        circlesize = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
    }
    void FixedUpdate()
    {
        goblinmovement();
    }

    public void goblinmovement()
    {
        GameObject[] bags = GameObject.FindGameObjectsWithTag("Bag");

        if (bags.Length > 0 && bagpresence == true)
        {
            GameObject closestBag = null;
            float closestDistance = 9000f;
     
            foreach (GameObject bag in bags)
            {
                float distanceToBag = Vector2.Distance(transform.position, bag.transform.position);

                if (distanceToBag < closestDistance)
                { 
                    closestDistance = distanceToBag;
                    closestBag = bag;
                }
            }

            if (closestBag != null)
            {
                Vector3 baghere = closestBag.transform.position;
                transform.position = Vector3.MoveTowards(transform.position, baghere, speed * Time.deltaTime);
                RedGoblin.SetBool("Xwhere", true);
            }
        }


        if (bags.Length >= 0 || bags.Length <= 0)
        {
            if (havebag == false && bagpresence == false )
            {
                //transform.position = circlesize - transform.position * speed;
                transform.position = Vector2.MoveTowards(transform.position, circlesize + IdleWhere.position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, circlesize + IdleWhere.position) < 1)
                {
                    bagpresence = true;
                    RedGoblin.SetBool("Xwhere", havebag);
                }

                
            }

            else if (havebag == true)
            {
                Vector3 _gobhouse = Gobhouse.position;
                transform.position = Vector2.MoveTowards(transform.position, _gobhouse, speed * Time.deltaTime);
                RedGoblin.SetBool("Xwhere", havebag);
            }

        }

       

    }

   /* private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Bag"))
        {
            Destroy(other.gameObject);
            bagpresence = 0;
            havebag = true;
            ChangeBagTags("ToBag");
        }

        if (other.collider.CompareTag("CBag"))
        {
            havebag = false;
            circlesize = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            score++;
            Debug.Log("Score: " + score);
            bagpresence = 0;
            ChangeBagTags("Bag");
        }
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
         if (other.CompareTag("Bag"))
        {
            Destroy(other.gameObject);
            bagpresence = false;
            havebag = true;
            ChangeBagTags("ToBag");
        }

        if (other.CompareTag("CBag"))
        {
            havebag = false;
            circlesize = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
            score++;
            Debug.Log("Score: " + score);
            bagpresence = false;
            ChangeBagTags("Bag");
        }
    
    }

       


    private void ChangeBagTags(string newTag)
    {
        GameObject[] Bags = GameObject.FindGameObjectsWithTag("Bag");
        GameObject[] ToBags = GameObject.FindGameObjectsWithTag("ToBag");

        foreach (GameObject bag in Bags)
        {
            bag.tag = newTag;
        }

       
        foreach (GameObject bag in ToBags)
        {
            bag.tag = newTag;
        }
    }

}

