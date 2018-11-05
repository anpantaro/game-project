using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GodTouches;

public class Installation : MonoBehaviour {

    public Camera camera;
    [SerializeField] Material[] matArray;
    public static Gimmick gimmick = Gimmick.Normal;
    public static Gimmick gimmickButton = Gimmick.Normal;
    public string tag;
    public Material mat;

    int[] remaining;


    // Use this for initialization
    void Start ()
    {
        remaining = new int[4]
        {
            2,
            2,
            2,
            2
        };
    }
	
	// Update is called once per frame
	void Update () {
        if (gimmickButton != Gimmick.Normal)
        {
            gimmick = gimmickButton;
            tag = gimmickButton.ToString();
            mat = matArray[(int)gimmickButton];
            gimmickButton = Gimmick.Normal;
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
                    if(hit.transform.tag != "Player" && gimmick != Gimmick.Normal && remaining[(int)gimmick] != 0)
                    {
                        hit.transform.tag = tag;
                        hit.collider.GetComponent<Renderer>().material = mat;
                        remaining[(int)gimmick]--;
                        gimmick = Gimmick.Normal;
                        tag = gimmick.ToString();
                        mat = matArray[(int)gimmick];
                    }
                    
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
    Normal
}