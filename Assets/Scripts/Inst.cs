using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GodTouches;

public class Inst : MonoBehaviour
{

    [SerializeField] string tagName;
    [SerializeField] GameObject Gameobj;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Installation()
    {
        Vector3 touchStartPos = GodTouch.GetPosition();
        GameObject copyObj = Instantiate(Gameobj, touchStartPos, Quaternion.identity);
        copyObj.GetComponent<MouseStalker>().touchStartPos = touchStartPos;
    }
}
