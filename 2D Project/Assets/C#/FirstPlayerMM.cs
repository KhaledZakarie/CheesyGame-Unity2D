using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class FirstPlayerMM : MonoBehaviour
{
    Transform MyTransform;
    SpriteRenderer MySprite;
    Animator Anime;
    int score;
    float speed;
    float lastSpeed;
    int MaxHealthy;
    int Healthy;

    public GameObject Box;

    //TIME
    double SpeedTime;
    double BoxTimeApper;
    double BoxTimeHide;
    //TEXTS
    public Transform Selector;
    TextMeshProUGUI HealthText1;
    TextMeshProUGUI ScoreText1;
    //SOUNDS
    public Transform FoodSound;
    public Transform FastSound;
    public Transform DestroySound;
    public Transform DieSound;

    // Start is called before the first frame update
    void Start()
    {
        Box.SetActive(false);
        BoxTimeApper = 800;
        BoxTimeHide = 0;

        gameObject.transform.position = new Vector3(-11.24f, 3.51f, -1);
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
        HealthText1 = Selector.Find("HealthText1").GetComponent<TextMeshProUGUI>();
        ScoreText1 = Selector.Find("ScoreText1").GetComponent<TextMeshProUGUI>();
        ScoreText1.text = "SCORE : " + score;
        HealthText1.text = Healthy + "/" + MaxHealthy;
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
        //Box Time
        if (BoxTimeApper > 0)
        {
            BoxTimeApper -= 1;
            Debug.Log(BoxTimeApper);
        }
        if (BoxTimeApper == 0 && BoxTimeHide == 0)
        {
            Box.SetActive(true);
            Box.transform.position = new Vector3(Random.Range(-12, 12), Random.Range(-6, 4), -1);
            BoxTimeHide = 800;
        }
        if (BoxTimeHide > 0)
            BoxTimeHide--;
        if (BoxTimeHide == 0 && BoxTimeApper == 0)
        {
            Box.transform.position = new Vector3(Random.Range(-12, 12), Random.Range(-6, 4), -1);
            Box.SetActive(false);
            BoxTimeApper = 300;
        }


        //BUTTON TO MOVE
        if (Input.GetKey(KeyCode.RightArrow))
        {
            MyTransform.Translate(new Vector3(speed, 0, 0));
            MySprite.flipX = false;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            MyTransform.Translate(new Vector3(-speed, 0, 0));
            MySprite.flipX = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            MyTransform.Translate(new Vector3(0, -speed, 0));
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            MyTransform.Translate(new Vector3(0, speed, 0));
        }

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
        if (collision.name == "Thunder")
        {
            speed = 0.22f;
            SpeedTime = 90;
            //Debug.Log(speed);
            Transform Fast = Instantiate(FastSound, collision.transform.position, new Quaternion());
            Destroy(Fast.gameObject, Fast.GetComponent<AudioSource>().clip.length);
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
            SceneManager.LoadScene(6);
        }
        //TEXT
        HealthText1.text = Healthy + "/" + MaxHealthy;
        ScoreText1.text = "SCORE : " + score;
        //Debug.Log(collision.name);
        //Debug.Log("Player1 Healthy " + Healthy);
    }
}
