using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direction_D : MonoBehaviour {

    public GameObject gameObj;
    public PlayerController playerCo;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("atari");

            if (gameObj.tag == "Normal")
            {
                int tmp;
                tmp = playerCo.Put;
                if (tmp == 3)
                {
                    playerCo.GetComponent<PlayerController>().Lost();
                    playerCo.GetComponent<PlayerController>().Right_SideD();
                }
            }
            else
            {
                if (gameObj.tag == "Down")
                {
                    playerCo.GetComponent<PlayerController>().Lost();
                    playerCo.GetComponent<PlayerController>().Right_SideD();
                }
            }
        }
    }
}
