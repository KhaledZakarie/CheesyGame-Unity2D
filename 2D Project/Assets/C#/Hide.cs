using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Start()
    {
        //Start Position
        gameObject.transform.position = new Vector3(0.0f, 0.0f,-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public GameObject DieEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Random Move When Collision with players
        if(collision.name== "FirstPlayer" || collision.name== "SecPlayer")
        {
            gameObject.transform.position = new Vector3(Random.Range(-12,12), Random.Range(-6, 4) ,-1);
        }
    }
}
