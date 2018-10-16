using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

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
    bool osita = false;

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
            Move();
            
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
                kyori +=Time.deltaTime;
                
                if (kyori >= haba)
                {
                    yoko++;
                    Tmp = yoko;
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
    }

    void OnTriggerStay(Collider other)
    {
        if (osita && !move)
        {
            switch (other.gameObject.tag)
            {
                case "yuka":
                    Debug.Log("hit");
                    move = true;
                    break;
                case "down":
                    hantei = Hantei.Down;
                    Debug.Log("hit");
                    move = true;
                    break;
            }
        }
        //if (!move && other.gameObject.tag == "down")
        //{
        //    hantei = Hantei.Down;
        //    Debug.Log("hit");
            
        //}
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

}




enum Hantei
{
    Right,
    Left,
    Up,
    Down
}