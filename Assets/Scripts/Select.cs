﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Select : MonoBehaviour {

    public GameObject obj;
    string destination;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnClick()
    {
        destination = obj.GetComponentInChildren<Text>().text;
        SceneManager.LoadScene(destination);
    }

}
