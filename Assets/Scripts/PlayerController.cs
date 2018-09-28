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
    float okuyuki = 1.5f;
    
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
        if (osita && !move)
        {
            move = true;
        }
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
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "down")
        {
            hantei = Hantei.Down;
        }
    }

}
enum Hantei
{
    Right,
    Left,
    Up,
    Down
}