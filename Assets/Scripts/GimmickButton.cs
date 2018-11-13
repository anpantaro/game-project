using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GodTouches;

public class GimmickButton : MonoBehaviour
{

    public PlayerController playerController;
    

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Button(int gimmickNum)
    {
        bool ositaka = playerController.Osita;
        if (ositaka)
        {
            Installation.gimmickButton = (Gimmick)gimmickNum;
        }
        
    }
}
