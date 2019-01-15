using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flashing : MonoBehaviour {

    public float timeOut;
    private float timeElapsed;

    private GameObject obj;

    float r;
    float b;

    bool which = true;

    // Use this for initialization
    void Start()
    {
        obj = GameObject.Find("TestCube");
        r = 255;
        b = 255;
        timeOut = 0.01f;
        
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut)
        {
            
            // Do anything
            if (which)
            {
                obj.GetComponent<Renderer>().material.color = new Color(r/ 255.0f, 255.0f / 255.0f, b / 255.0f, 255.0f / 255.0f);
                r--;
                b -= 2;
            }
            else
            {
                obj.GetComponent<Renderer>().material.color = new Color(r / 255.0f, 255.0f / 255.0f, b / 255.0f, 255.0f / 255.0f);
                r++;
                b += 2;
            }

            if (r < 150)
            {
                which = false;
            }
            else if(r > 255)
            {
                which = true;
            }
            timeElapsed = 0.0f;
        }
        

    }
}
