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
    public void Button(string gimmick)
    {
        switch (gimmick)
        {
            case "Up":
                Installation.gimmick = Gimmick.Up;
                break;
        }
    }
}
