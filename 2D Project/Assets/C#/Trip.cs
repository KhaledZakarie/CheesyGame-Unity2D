using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trip : MonoBehaviour
{
    double Time;
    double MoveTime;
    // Start is called before the first frame update
    void Start()
    {
        MoveTime = 900;
        Time = MoveTime;
        gameObject.transform.position = new Vector3(Random.Range(-12, 12), Random.Range(-6, 4), -1);
    }

    // Update is called once per frame
    void Update()
    {
        Time--;
        if (Time == 0)
        {
            //Random Move After Time
            gameObject.transform.position = new Vector3(Random.Range(-12, 12), Random.Range(-6, 4), -1);
            Time = MoveTime;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Random Move When Collision with players
        if (collision.name == "FirstPlayer" || collision.name == "SecPlayer")
        {
            gameObject.transform.position = new Vector3(Random.Range(-12, 12), Random.Range(-6, 4), -1);
        }
    }
}
