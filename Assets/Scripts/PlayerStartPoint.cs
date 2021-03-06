﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

    private PlayerController thePlayer;
    private CameraControl theCamera;

    public string pointName;

	// Use this for initialization
	void Start () {
        thePlayer = FindObjectOfType<PlayerController>();

        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            theCamera = FindObjectOfType<CameraControl>();
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
        }

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
