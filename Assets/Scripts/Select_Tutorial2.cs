using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Select_Tutorial2 : MonoBehaviour
{

    public GameObject obj;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Go_Tutorial2()
    {
        SceneManager.LoadScene("Tutorial2");
    }
}