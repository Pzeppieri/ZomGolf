using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GolfBall : MonoBehaviour
{
    //private float startTime;
    //private float endTime;

    //This is never called, so I commented it out 7/11/16
    //private float TimeTaken;
    private GameManager gameManager;


    private Vector3 Distance;
    private Vector3 SpawnPoint = new Vector3(0.14f, 1.25f, -4.5f);
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 force;
    private float power = 500f;
    public GameObject GolfBalls;

    void Start()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
    }
    #region ZombieBeatenText
    //Counter of the zombs.
    public int Score;
    
    //Text
    public Text Scoretext;

    #endregion


    void Update()
    {
      //  Scoretext.text = Score+" beaten".ToString();

    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2.0f);
        Instantiate(GolfBalls, SpawnPoint, Quaternion.identity);
    }

    IEnumerator DestroyBall()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(gameObject);
    }


    void OnMouseDown()
    {
        print("clicked!");
        //startTime = Time.time;
        startPos = Input.mousePosition;

        startPos.z = transform.position.z - Camera.main.transform.position.z;
        startPos = Camera.main.ScreenToWorldPoint(startPos);
    }

    void OnMouseUp()
    {
        //endTime = Time.time;
        endPos = Input.mousePosition;
        endPos.z = transform.position.z - Camera.main.transform.position.z;
        endPos = Camera.main.ScreenToWorldPoint(endPos);

        Distance = endPos - startPos;


        force = Distance;
        force.z = force.magnitude;
        //force.Normalize();

       gameObject.GetComponent<Rigidbody>().AddForce(force * power);
       StartCoroutine(Wait());
        StartCoroutine(DestroyBall());
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie1" || other.tag == "Zombie2" || other.tag == "Zombie3" || other.tag == "Zombie4" || other.tag == "Zombie5")
        {

            //Destroy hit object.
           Destroy(other.gameObject);
            //Increase score
          //  Score=Score+1;
            gameManager.addScore();

        }


    }

    }
