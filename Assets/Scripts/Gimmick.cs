using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GodTouches;

public class Gimmick : MonoBehaviour
{
    [SerializeField] string tagName;
    [SerializeField] GameObject Gameobj;
    // Use this for initialization
    void Start()
    {
        TouchOperation.cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Installation()
    {
        Vector3 touchStartPos = TouchOperation.GetTouchWorldPosition(0);
        GameObject copyObj = Instantiate(Gameobj, touchStartPos, Quaternion.identity);
        copyObj.GetComponent<MouseStalker>().touchStartPos = touchStartPos;
    }
}
