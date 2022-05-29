using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCode : MonoBehaviour
{
    public GameObject PositiveEffect;
    public GameObject NegativeEffect;
    int rand;
    double Time;
    double MoveTime;
    // Start is called before the first frame update
    void Start()
    {
        
        //MoveTime = 900;
        //Time = MoveTime;
    }

    // Update is called once per frame
    void Update()
    {
        /*Time--;
        if (Time == 0)
        {
            //Random Move After Time
            //gameObject.transform.position = new Vector3(Random.Range(-12, 12), Random.Range(-4, 3), -1);
            //Time = MoveTime;
        }*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "FirstPlayer" || collision.name == "SecPlayer")
        {
            Vector3 Location = gameObject.transform.position;
            rand = Random.Range(0, 2); //Random Choice between Speeds
            //gameObject.transform.position = new Vector3(Random.Range(-12, 12), Random.Range(-4, 3), -1);
            gameObject.SetActive(false);
            if(rand==0)
            {
                PositiveEffect.transform.position = Location;//Speed
            }
            else
                NegativeEffect.transform.position = Location;//Slow
        }
            
    }
}
