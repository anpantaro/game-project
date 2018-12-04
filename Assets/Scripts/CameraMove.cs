using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using System;
using System.Linq;

public class CameraMove : MonoBehaviour {

    public Camera MainCamera;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    void FixedUpdete()
    {
#if UNITY_EDITOR
        // マウスが押された場合
        if (Input.GetMouseButtonUp(0))
        {
        }
        else if (Input.GetMouseButton(0))
        {
            MapSwipe();
        }
#elif UNITY_IOS || UNITY_ANDROID
        
        if (Input.touchCount == 0) {
        } else if (Input.touchCount == 1) {
            MapSwipe();
        }
#endif
    }

    public void MapSwipe()
    {
#if UNITY_EDITOR
        //mousePositionの取得
        var drug = Observable.EveryUpdate().Select(pos => Input.mousePosition);
        //クリックが話されたら購読停止
        var stop = Observable.EveryUpdate().Where(_ => Input.GetMouseButtonUp(0));
#elif UNITY_IOS || UNITY_ANDROID
        //positionの取得
        var drug = Observable.EveryUpdate ().Select (pos => Input.GetTouch(0).position);
        //タッチカウントが変更され場合に購読停止
        var stop = Observable.EveryUpdate ().Where(_ => Input.touchCount != 1);
#endif

        //マウスポジションの4フレーム後のポジションを比較してカメラのRigidbodyに力を加える。
        IDisposable onDrug = drug.Zip(drug.Skip(4), (pos1, pos2) => new { x = pos2.x - pos1.x, z = pos2.y - pos1.y })
            //クリックが離されたたら購読停止
            .TakeUntil(stop)
            .Subscribe(deltaPosition => {
                MainCamera.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(deltaPosition.x, 0, deltaPosition.z) * -5;
            }
        );
    }


}
