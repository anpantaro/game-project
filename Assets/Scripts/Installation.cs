using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GodTouches;

public class Installation : MonoBehaviour {

    public Camera camera;
    [SerializeField] Material[] matArray;
    [SerializeField] Text[] text;
    public static Gimmick gimmick = Gimmick.Normal;
    public static Gimmick gimmickButton = Gimmick.Normal;
    public string tag;
    public Material mat;

    public PlayerController playercotroller;

    private int[] remaining;

    float maxDistance = 15;


    [SerializeField] GameObject[] selecting;

    int tmp = 0;

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
        for (int i = 0; i < 4; i++)
        {
            text[i].text = remaining[i].ToString();
        }

    }
	
	// Update is called once per frame
	void Update () {
        bool ositaka;
        ositaka = playercotroller.Osita;
        
        if (ositaka)
        {
            if (gimmickButton != Gimmick.Normal)
            {
                gimmick = gimmickButton;
                tag = gimmickButton.ToString();
                mat = matArray[(int)gimmickButton];
                selecting[tmp].GetComponentInChildren<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
                tmp = (int)gimmickButton;
                selecting[(int)gimmickButton].GetComponentInChildren<Image>().color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 115.0f / 255.0f, 255.0f / 255.0f);
                gimmickButton = Gimmick.Normal;
                
            }
            TouchJudg();
        }
        

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

                if (Physics.Raycast(ray, out hit,maxDistance))
                {


                    // レイに当たったオブジェクトに何かをする
                    if(hit.transform.tag != "Player" && hit.transform.tag != "Goal" && hit.transform.tag != "Drop" && hit.transform.tag != "Destroy" && gimmick != Gimmick.Normal && remaining[(int)gimmick] != 0)
                    {
                        hit.transform.tag = tag;
                        hit.collider.GetComponent<Renderer>().material = mat;
                        remaining[(int)gimmick]--;
                        text[(int)gimmick].text = remaining[(int)gimmick].ToString();
                        selecting[(int)gimmick].GetComponentInChildren<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
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