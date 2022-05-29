using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class SecPlayerM : MonoBehaviour
{
    Transform MyTransform;
    SpriteRenderer MySprite;
    Animator Anime;
    int score;
    float speed;
    int MaxHealthy;
    int Healthy;
    //TIME
    double SpeedTime;
    //TEXT
    public Transform Selector;
    TextMeshProUGUI HealthText2;
    TextMeshProUGUI ScoreText2;

    //SOUNDS
    public Transform FoodSound;
    public Transform FastSound;
    public Transform DestroySound;
    public Transform DieSound;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(-11.24f, -3.51f, -1);
        score = 0;
        speed = 0.12f;
        MaxHealthy = 3;
        Healthy = MaxHealthy;
        MyTransform = GetComponent<Transform>();
        MySprite = GetComponent<SpriteRenderer>();
        Anime = GetComponent<Animator>();
        //TIME'
        SpeedTime = 0;
        //TEXT
        HealthText2 = Selector.Find("HealthText2").GetComponent<TextMeshProUGUI>();
        ScoreText2 = Selector.Find("ScoreText2").GetComponent<TextMeshProUGUI>();
        ScoreText2.text = "SCORE : " + score;
        HealthText2.text = Healthy + "/" + MaxHealthy;
    }

    // Update is called once per frame
    void Update()
    {
        //KEEPING PLAYER WITHIN SCREEN BOUNDARIES
        if (gameObject.transform.position.x < -12)
            gameObject.transform.position = new Vector3(-12, gameObject.transform.position.y, gameObject.transform.position.z);

        if (gameObject.transform.position.x > 12)
            gameObject.transform.position = new Vector3(12, gameObject.transform.position.y, gameObject.transform.position.z);

        if (gameObject.transform.position.y < -6)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, -6, gameObject.transform.position.z);

        if (gameObject.transform.position.y > 4)
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, 4, gameObject.transform.position.z);

        //TIME 
        if (SpeedTime > 0)//take speed or slow
            SpeedTime--;
        if (SpeedTime == 0)
        {
            speed = 0.12f;
        }
        //BUTTON TO MOVE
        if (Input.GetKey(KeyCode.D))
        {
            MyTransform.Translate(new Vector3(speed, 0, 0));
            MySprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MyTransform.Translate(new Vector3(-speed, 0, 0));
            MySprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            MyTransform.Translate(new Vector3(0, -speed, 0));
        }
        else if (Input.GetKey(KeyCode.W))
        {
            MyTransform.Translate(new Vector3(0, speed, 0));
        }
        //stop sound of destroy when die
        if (Healthy == 1)
            DestroySound.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //COLLISION WITH OBJECTS
        if (collision.name == "Food")
        {
            score += 10;
            Transform Food = Instantiate(FoodSound, collision.transform.position, new Quaternion());
            Destroy(Food.gameObject, Food.GetComponent<AudioSource>().clip.length);
        }
        /*if (collision.name == "Heart")
        {
            if (Healthy < MaxHealthy)
            {
                Healthy++;
                Transform Heart = Instantiate(HeartSound, collision.transform.position, new Quaternion());
                Destroy(Heart.gameObject, Heart.GetComponent<AudioSource>().clip.length);
            }
        }*/
        if (collision.name == "Thunder")
        {
            speed = 0.22f;
            SpeedTime = 90;
            Transform Fast = Instantiate(FastSound, collision.transform.position, new Quaternion());
            Destroy(Fast.gameObject, Fast.GetComponent<AudioSource>().clip.length);
            //Debug.Log(speed);
        }
        if (collision.name == "Slow")
        {
            speed = 0.05f;
            SpeedTime = 90;
            //Debug.Log(speed);
        }
        if (collision.name == "Destroyer")
        {
            Healthy--;
            Transform Dest = Instantiate(DestroySound, collision.transform.position, new Quaternion());
            Destroy(Dest.gameObject, Dest.GetComponent<AudioSource>().clip.length);
        }
        if (Healthy <= 0)
        {
            Destroy(gameObject);
            Transform Die = Instantiate(DieSound, collision.transform.position, new Quaternion());
            Destroy(Die.gameObject, Die.GetComponent<AudioSource>().clip.length);
            SceneManager.LoadScene(3);
        }
        //TEXT
        HealthText2.text = Healthy + "/" + MaxHealthy;
        ScoreText2.text = "SCORE : " + score;

        //Debug.Log("Player1 Score " + score);
        //Debug.Log("Player1 Healthy " + Healthy);
    }
}
