using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GodTouches;

public class Installation : MonoBehaviour {

    public Camera camera;
    [SerializeField] Material[] matArray;
    public static Gimmick gimmick;
    public string tag;
    public Material mat;


    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update () {
        if (gimmick != Gimmick.None)
        {
            tag = gimmick.ToString();
            mat = matArray[(int)gimmick];
            gimmick = Gimmick.None;
        }
        TouchJudg();

    }

    public void TouchJudg()
    {
        var phase = GodTouch.GetPhase();
        var pos = GodTouch.GetPosition();

        switch (phase)
        {
            case GodPhase.Began: // 押された
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {

                    // レイに当たったオブジェクトに何かをする
                    hit.transform.tag = tag;
                    hit.collider.GetComponent<Renderer>().material = mat;

                }
                break;
        }
    }

}
public enum Gimmick
{
    Right,
    Left,
    Up,
    Down,
    None
}