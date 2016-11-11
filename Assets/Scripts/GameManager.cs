using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public List<GameObject> ZombiePrefabList = new List<GameObject>();

    

    public float Spawntimer;
    public float SpawnTimerMax;
    private int WaveNumber;
    private float timeLeft; //1min for each wave

    public float scoreincrease = 1;
    public Text scoreText;
    public int score;

    public Text bankText;
    public static int bank;


    // Use this for initialization
    void Start ()
    {
        //sees if theres is any ingame currency from previous game and sets it to bank
        if (PlayerPrefs.HasKey("Bank"))
        {
            bank = PlayerPrefs.GetInt("Bank");
        }

        score = 0;
        //adds 100 to bank so tester may purchase items to test them
        if (bank < 100)
        {
            bank += 100;

            SpawnTimerMax = 3.0f;

            UpdateScoreText();
            WaveNumber = 1;
            timeLeft = 60.0f;
        }

    }

        // Update is called once per frame

       void Update ()
        {
            UpdateScoreText();

            //checks if a point has been earned and the adds it to the bank
            PlayerPrefs.SetInt("Bank", bank);
            if (score > 0)
                PlayerPrefs.GetInt("bank", bank + score);

            Countdown();
        if (WaveNumber == 1)
        SpawnTimer();
        
    }
    

    void ZombieSpawn()
    {
        Vector3 ZombieLane1 = new Vector3(Random.Range(-35, -20), 1.5f, Random.Range(32, 30));
        Vector3 ZombieLane2 = new Vector3(Random.Range(-12f, 13f), 1.5f, Random.Range(24, 35));
        Vector3 ZombieLane3 = new Vector3(Random.Range(29, 28), 1.5f, Random.Range(36, 30));

        int prefabIndex = UnityEngine.Random.Range(0, 5);

        int ChooseLane = UnityEngine.Random.Range(0, 3);
        print("Zombie spawned at: " + ChooseLane);

        if (ChooseLane == 0)
            Instantiate((ZombiePrefabList[prefabIndex]), ZombieLane1, Quaternion.identity);
        else if (ChooseLane == 1)
            Instantiate((ZombiePrefabList[prefabIndex]), ZombieLane2, Quaternion.identity);
        else
            Instantiate((ZombiePrefabList[prefabIndex]), ZombieLane3, Quaternion.identity);
    }

    void SpawnTimer()
    {
        Spawntimer -= Time.deltaTime;
        //if lesss than 0 set back to 3 as need a countdown for when to instaniate planets
        if (Spawntimer <= 0)
        {
            Spawntimer = SpawnTimerMax;
            //if the timer is > 1 minus 0.1 from timer upon every instaniation so they gradually spawn quicker
            if (SpawnTimerMax > 1) { SpawnTimerMax -= 0.1f; }
            if (SpawnTimerMax < 1) { SpawnTimerMax = 5; }
            ZombieSpawn();
        }
    }

    void Countdown()
    {

            timeLeft -= Time.deltaTime;
            //print("Wave time: " + timeLeft.ToString("0"));

        if (timeLeft <= 0)
        {
            WaveNumber += 1;
            print("Wave Number: " + WaveNumber);
            timeLeft = 60.0f;
        }
    }

        public void addScore()
    {
        score += 1;
        bank += 1;
        UpdateScoreText();
    }

    public void UpdateScoreText()
    {
        scoreText.GetComponent<Text>().text = "Beaten: " + score.ToString();
        bankText.GetComponent<Text>().text = "Bank: " + bank.ToString();
    }
}
