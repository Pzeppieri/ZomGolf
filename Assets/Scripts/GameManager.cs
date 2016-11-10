using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public List<GameObject> ZombiePrefabList = new List<GameObject>();

    

    public float Spawntimer;
    public float SpawnTimerMax;
    private int WaveNumber;
    private float timeLeft; //1min for each wave


    // Use this for initialization
    void Start ()
    {
        SpawnTimerMax = 3.0f;

       
        WaveNumber = 1;
        timeLeft = 60.0f;
        

    }

    // Update is called once per frame
    void Update ()
    {
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
    
}
