using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {



    public int PlayerHP;

	// Use this for initialization
	void Start () {

        PlayerHP = 100;

	}
	
	// Update is called once per frame
	void Update () {
	
	}



    void OnTriggerEnter(Collider other)
    {
        print("Triggered");
        if (other.tag == "Zombie1")
        {
            Destroy(other.gameObject);
            print("PlayerHP: " + PlayerHP);
        }

        if (other.tag == "Zombie2")
        {
            Destroy(other.gameObject);
            print("PlayerHP: " + PlayerHP);
        }

        if (other.tag == "Zombie3")
        {
            Destroy(other.gameObject);
            print("PlayerHP: " + PlayerHP);
        }

        if (other.tag == "Zombie4")
        {
            Destroy(other.gameObject);
            print("PlayerHP: " + PlayerHP);
        }

        if (other.tag == "Zombie5")
        {
            Destroy(other.gameObject);
            print("PlayerHP: " + PlayerHP);
        }

    }


}
