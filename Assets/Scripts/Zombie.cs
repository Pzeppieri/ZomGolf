using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

    Transform PlayerPos;
    public float ZombieSpeed;
    public float ZombieRotationSpeed = 10.0f;
    public float ZombieHP;
    float MissingLife;//needed to calculate how much of the bar we remove everyhit
    float OriginalLife;//original life is needed in the calculation
    public GameObject healthBar;

	// Use this for initialization
	void Start ()
    {
        OriginalLife = ZombieHP;
        MissingLife = 0.0f;//initially 0
        //ZombieSpeed = 7f;  This is set in game manager instead.
        healthBar.gameObject.transform.localScale = new Vector3(1, healthBar.transform.localScale.y, healthBar.transform.localScale.z);//the first number is 1, as it is the scale of the green bar first of all, 1 means the bar is full and we shrink it through a calculation based on the original amount of life and its missing life
        PlayerPos = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update ()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, 
        Quaternion.LookRotation(PlayerPos.position - transform.position), ZombieRotationSpeed * Time.deltaTime);

        //PlayerPos.position += PlayerPos.forward * ZombieSpeed * Time.deltaTime;
        transform.position += transform.forward * ZombieSpeed * Time.deltaTime;

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GolfBall")
        {
            ZombieHP -= 1;
            MissingLife += 1.0f / OriginalLife;//everytime the zombie gets hit, we calculate the total amount of missing life the zombie has, thus we can calculate just how much of the bar we should remove(scale down)
            healthBar.gameObject.transform.localScale = new Vector3(1.0f-MissingLife, healthBar.transform.localScale.y, healthBar.transform.localScale.z);//the new scale is calculate with the amount of missing life representation from 1
            //the missing life is calculated in a way to represent just how much of the number 1 is missing
        }
    }

}
