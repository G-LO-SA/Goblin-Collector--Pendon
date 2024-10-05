using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Unity.VisualScripting;
using UnityEngine.UIElements;
using TMPro;


public class Spawner : MonoBehaviour
{
    [SerializeField] Transform Spawnarea;
    [SerializeField] GameObject Objecttospawn;
    Goblin _goblin;
    public float speed = 1f;
    public float timecount = 3f;
    private float frequency = 1f;

    /*IEnumerator cooldown ()
    {
        Vector2 _spawnarea = Spawnarea.position;
        Vector2 targetposition = new Vector2(Random.Range(10, -10), Random.Range(-1, -15));
        var bagshoot = Instantiate(Objecttospawn, _spawnarea, Quaternion.identity);
        bagshoot.GetComponent<Rigidbody2D>().AddForce(targetposition * speed);
        yield return new WaitForSeconds(6);

    }*/
 
    //private void Update()
   // {
        //if (Input.GetKeyDown("space"))
        //{
        //objectspawn();
        //}
   
 

    //}

    private void FixedUpdate()
    {
       if (frequency < timecount ) 
        {
            frequency += Time.deltaTime;
        }

       else
        {
            objectspawn();
            frequency = 0f;
        }
    }

    private void OnDrawGizmosSelected()
    {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, 15);
    }

    public void objectspawn()
    {
        Vector2 _spawnarea = Spawnarea.position;
        Vector2 targetposition = new Vector2(Random.Range(7, -10), Random.Range(-1, -15));
        var bagshoot = Instantiate(Objecttospawn, _spawnarea, Quaternion.identity);
        bagshoot.GetComponent<Rigidbody2D>().AddForce(targetposition * speed);
    }



    /*Gizmos.color = Color.red;
    Gizmos.DrawSphere(transform.position, 10);*/
    //}


}
