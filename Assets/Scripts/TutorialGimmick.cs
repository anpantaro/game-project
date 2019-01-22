using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GodTouches;

public class TutorialGimmick : MonoBehaviour 
{

    public TutorialPlayer tutorialPlayer;


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
        bool ositaka = tutorialPlayer.Osita;
        bool stopka = tutorialPlayer.Stop;
        if (ositaka && stopka)
        {
            TutorialInst.gimmickButton = (Gimmick)gimmickNum;
        }

    }
}
