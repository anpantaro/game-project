using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GodTouches;

public class Swipe : MonoBehaviour {

    public Camera MainCamera;
    private Vector3 lastMousePosition;
    private Vector3 newPosition = new Vector3(0, 0, 0);

   

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // マウスクリック開始(マウスダウン)時にカメラの角度を保持(Z軸には回転させないため).
            newPosition = MainCamera.transform.position;
            lastMousePosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            // マウスの移動量分カメラを回転させる.
            newPosition.x += (Input.mousePosition.x - lastMousePosition.x) * 0.1f;
            newPosition.z += (Input.mousePosition.y - lastMousePosition.y) * 0.1f;
            MainCamera.gameObject.transform.position = newPosition;

            lastMousePosition = Input.mousePosition;
        }

    }

   

}