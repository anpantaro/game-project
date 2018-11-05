using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GodTouches;

public class GimmickButton : MonoBehaviour
{
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
        Installation.gimmickButton = (Gimmick)gimmickNum;
    }
}
