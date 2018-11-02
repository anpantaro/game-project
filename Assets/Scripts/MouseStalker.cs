using GodTouches;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseStalker : MonoBehaviour {

    public Vector3 touchStartPos;
    Vector3 touchNowPos;

	// Use this for initialization
	void Start () {
        touchNowPos = touchStartPos;

    }
	
	// Update is called once per frame
	void Update () {
        touchNowPos = TouchOperation.GetTouchWorldPosition(0);
        transform.position = touchStartPos + (touchNowPos - touchStartPos);
    }
}
