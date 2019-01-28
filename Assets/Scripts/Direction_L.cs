using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction_L : MonoBehaviour {

    public GameObject gameObj;
    public PlayerController playerCo;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            

            if (gameObj.tag == "Normal")
            {
                int tmp;
                tmp = playerCo.Put;
                if (tmp == 1)
                {
                    playerCo.GetComponent<PlayerController>().Lost();
                    playerCo.GetComponent<PlayerController>().Right_SideL();
                }
            }
            else
            {
                if (gameObj.tag == "Left")
                {
                    playerCo.GetComponent<PlayerController>().Lost();
                    playerCo.GetComponent<PlayerController>().Right_SideL();
                }
            }
        }
    }
}
