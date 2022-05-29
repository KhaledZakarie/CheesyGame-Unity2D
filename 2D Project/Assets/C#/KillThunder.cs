using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillThunder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Hide when Collision With Players
        if (collision.name == "FirstPlayer" || collision.name == "SecPlayer")
        {
            gameObject.transform.position = new Vector3(-20f, -2f, -1);
        }
    }
}
