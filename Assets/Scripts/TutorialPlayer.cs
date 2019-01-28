using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialPlayer : MonoBehaviour {

    float MOVEX = 0.0f; // x軸方向に１マス移動するときの距離
    float MOVEY = 0.0f; // y軸方向に１マス移動するときの距離
    float kyori = 0.0f;
    float haba = 1.5f;
    float tate = 1;
    float yoko = 0;
    float Tmp;



    public float speed = 3.0f;
    //Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    //Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

    public float timeOut;
    private float timeElapsed;

    Hantei hantei = Hantei.Right;



    bool move = false;
    private bool osita = false;

    private bool way = false;


    public bool Osita
    {
        get { return this.osita; }  //取得用
        private set { this.osita = value; }
    }



    public GameObject start;
    public GameObject reset;
    public GameObject title;
    public GameObject map;
    public GameObject mapReset;

    public GameObject camera;


    public string right_Side;

    private int put = 0;

    public int Put
    {
        get { return this.put; }
        private set { this.put = value; }
    }

    private bool stop = false;
    int count;

    public bool Stop
    {
        get { return this.stop; }
        private set { this.stop = value; }
    }

    public GameObject test;

   

    // Use this for initialization
    void Start()
    {
        //target = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {


        if (move)
        {
            if (!stop)
            {
                Move();
            }
            else
            {
                
            }
            
            

        }


    }

    void Move()
    {


        /*timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            switch (hantei)
        {
            case Hantei.Right:
                target = transform.position + MOVEX;
                transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
                break;
        }

            timeElapsed = 0.0f;
        }*/

        switch (hantei)
        {
            case Hantei.Right:
                transform.position += transform.right * Time.deltaTime;
                kyori += Time.deltaTime;

                if (kyori >= haba)
                {
                    yoko++;
                    Tmp = yoko;
                    transform.position = new Vector3(haba * yoko, 1.0f, haba * tate);
                    kyori = 0.0f;
                    move = false;
                    count++;
                }
                break;
            case Hantei.Left:

                transform.position -= transform.right * Time.deltaTime;
                kyori += Time.deltaTime;
                if (kyori >= haba)
                {
                    yoko--;
                    transform.position = new Vector3(haba * yoko, 1.0f, haba * tate);
                    kyori = 0.0f;
                    move = false;
                }
                break;
            case Hantei.Up:

                transform.position += transform.forward * Time.deltaTime;
                kyori += Time.deltaTime;
                if (kyori >= haba)
                {
                    tate++;
                    transform.position = new Vector3(haba * yoko, 1.0f, haba * tate);
                    kyori = 0.0f;
                    move = false;
                }
                break;
            case Hantei.Down:

                transform.position -= transform.forward * Time.deltaTime;
                kyori += Time.deltaTime;
                if (kyori >= haba)
                {
                    tate--;
                    transform.position = new Vector3(haba * yoko, 1.0f, haba * tate);
                    kyori = 0.0f;
                    move = false;
                }
                break;

        }


    }
    public void playerstart()
    {
        osita = true;
        move = true;
        start.SetActive(false);
        //reset.SetActive(true);
        title.SetActive(false);
        map.SetActive(false);
        
    }

    public void Stagereset()
    {
        Scene loadScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadScene.name);
    }

    void OnTriggerStay(Collider other)
    {

        if (osita && !move)
        {
            if (!way)
            {
                switch (other.gameObject.tag)
                {

                    case "Normal":
                        Debug.Log("hit");
                        if(count == 2)
                        {
                            
                            stop = true;
                            test.SetActive(true);
                            
                        }
                        move = true;

                        break;
                    case "Right":
                        hantei = Hantei.Right;
                        put = 0;
                        Debug.Log("hit");
                        move = true;
                        break;
                    case "Left":
                        hantei = Hantei.Left;
                        put = 1;
                        Debug.Log("hit");
                        move = true;
                        break;
                    case "Up":
                        hantei = Hantei.Up;
                        put = 2;
                        Debug.Log("hit");
                        move = true;
                        break;
                    case "Down":
                        hantei = Hantei.Down;
                        Debug.Log("hit");
                        put = 3;
                        move = true;
                        break;

                    case "Goal":

                        Debug.Log("Goal");
                        SceneManager.LoadScene("Goal");
                        break;
                    case "Drop":
                        GetComponent<Rigidbody>().useGravity = true;
                        break;
                    case "Destroy":
                        Scene loadScene = SceneManager.GetActiveScene();
                        SceneManager.LoadScene(loadScene.name);
                        break;


                }
            }
            else
            {

                switch (right_Side)
                {
                    case "Right":
                        hantei = Hantei.Right;
                        put = 0;
                        move = true;
                        way = false;
                        break;
                    case "Left":
                        hantei = Hantei.Left;
                        put = 1;
                        move = true;
                        way = false;
                        break;
                    case "Up":
                        hantei = Hantei.Up;
                        put = 2;
                        move = true;
                        way = false;
                        break;
                    case "Down":
                        hantei = Hantei.Down;
                        put = 3;
                        move = true;
                        way = false;
                        break;

                }
            }

        }
        //if (!move && other.gameObject.tag == "down")
        //{
        //    hantei = Hantei.Down;
        //    Debug.Log("hit");

        //}
    }

    public void Lost()
    {
        way = true;
    }

    public void Right_SideR()
    {
        right_Side = "Down";
    }

    public void Right_SideL()
    {
        right_Side = "Up";
    }

    public void Right_SideU()
    {
        right_Side = "Right";
    }

    public void Right_SideD()
    {
        right_Side = "Left";
    }

    //void Adjust()
    //{
    //    switch (hantei)
    //    {
    //        case Hantei.Right:
    //            yoko++;
    //            break;
    //        case Hantei.Left:
    //            yoko--;
    //            break;

    //    }
    //}

    public void Confirmation()
    {
        map.SetActive(false);
        start.SetActive(false);
        title.SetActive(false);
        mapReset.SetActive(true);
        camera.GetComponent<Swipe>().enabled = true;
        camera.GetComponent<FollowPlayer>().enabled = false;
    }

    public void MapReset()
    {
        map.SetActive(true);
        start.SetActive(true);
        title.SetActive(true);
        mapReset.SetActive(false);
        camera.GetComponent<Swipe>().enabled = false;
        camera.GetComponent<FollowPlayer>().enabled = true;
    }

    public void StopReset()
    {
        stop = false;
        test.SetActive(false);
    }

}

