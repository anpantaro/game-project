using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GodTouches;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Installation : MonoBehaviour {

    public Camera camera;
    [SerializeField] Material[] matArray;
    [SerializeField] Text[] text;
    public static Gimmick gimmick = Gimmick.Normal;
    public static Gimmick gimmickButton = Gimmick.Normal;
    public string tag;
    public Material mat;

    public PlayerController playercotroller;

    [SerializeField] int[] remaining;

    float maxDistance = 15;

    public GameObject se;
    private AudioSource sound1;


    [SerializeField] GameObject[] selecting;

    int tmp = 0;

    private bool noStop = false;

    public bool NoStop
    {
        get { return this.noStop; }
        private set { this.noStop = value; }
    }

    int panelCount;

    // Use this for initialization
    void Start ()
    {
        sound1 = se.GetComponent<AudioSource>();

        for (int i = 0; i < 4; i++)
        {
            text[i].text = remaining[i].ToString();
            if(remaining[i] == 0)
            {
                selecting[i].GetComponentInChildren<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 100.0f / 255.0f);
                panelCount++;
            }
        }
        if(panelCount == 4)
        {
            noStop = true;
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
                if(remaining[tmp] != 0)
                {
                    selecting[tmp].GetComponentInChildren<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
                }

                tmp = (int)gimmickButton;
                if (remaining[(int)gimmickButton] != 0)
                {
                    selecting[(int)gimmickButton].GetComponentInChildren<Image>().color = new Color(189.0f / 255.0f, 241.0f / 255.0f, 115.0f / 255.0f, 255.0f / 255.0f);
                }
                
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
        //if(Input.GetMouseButtonDown(0))
        {
            case GodPhase.Began: // 押された
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    break; 
                }

                if (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                {
                    // かぶさってるので処理キャンセル（タップver）
                    break;
                }
                if (Physics.Raycast(ray, out hit,maxDistance))
                {


                    // レイに当たったオブジェクトに何かをする
                    if(hit.transform.tag == "Normal"  && gimmick != Gimmick.Normal && remaining[(int)gimmick] != 0)
                    {
                        hit.transform.tag = tag;
                        hit.collider.GetComponent<Renderer>().material = mat;
                        remaining[(int)gimmick]--;
                        text[(int)gimmick].text = remaining[(int)gimmick].ToString();
                        sound1.PlayOneShot(sound1.clip);
                        if (remaining[(int)gimmick ] == 0)
                        {
                            selecting[(int)gimmick].GetComponentInChildren<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 100.0f / 255.0f);
                        }
                        else
                        {
                            selecting[(int)gimmick].GetComponentInChildren<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f);
                        }
                        
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