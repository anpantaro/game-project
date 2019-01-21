using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GodTouches;

public class Swipe : MonoBehaviour {

    public Camera MainCamera;
    private Vector3 lastMousePosition;
    private Vector3 newPosition = new Vector3(0, 0, 0);

    public float x_Min;
    public float x_Max;
    public float z_Min;
    public float z_Max;


    

    private void Update()
    {
        var phase = GodTouch.GetPhase();
        var pos = GodTouch.GetPosition();
        var delta = GodTouch.GetDeltaPosition();

        switch (phase)
        {
            case GodPhase.Began:
                newPosition = MainCamera.transform.position;
                
                lastMousePosition = Input.mousePosition;
                break;
            case GodPhase.Moved:
                newPosition.x -= (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
                newPosition.z -= (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
                newPosition.x = Mathf.Clamp(newPosition.x, x_Min, x_Max);
                newPosition.z = Mathf.Clamp(newPosition.z, z_Min, z_Max);
                MainCamera.gameObject.transform.position = newPosition;

                lastMousePosition = Input.mousePosition;
                break;
        }


        

    }

   

}