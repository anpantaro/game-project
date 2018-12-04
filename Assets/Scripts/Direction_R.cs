using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Direction_R : MonoBehaviour {

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
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("atari");
            
            if(gameObj.tag == "Normal")
            {
                int tmp;
                tmp = playerCo.Put;
                if(tmp == 0)
                {
                    playerCo.GetComponent<PlayerController>().Lost();
                    playerCo.GetComponent<PlayerController>().Right_SideR();
                }
            }
            else
            {
                if(gameObj.tag == "Right")
                {
                    playerCo.GetComponent<PlayerController>().Lost();
                    playerCo.GetComponent<PlayerController>().Right_SideR();
                }
            }
        }
    }
}
