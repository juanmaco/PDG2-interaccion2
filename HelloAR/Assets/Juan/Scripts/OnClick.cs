﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour {

    public Material lMat;
    public Material nMat;
    private Renderer myR;
    private Vector3 myTp;
    public int myNumber = 99;
    public delegate void ClickEv(int number);
    public myLogica gameLog;
    public AudioSource mySound;

    public event ClickEv onClick;


	// Use this for initialization
	void Start () {
        myR = GetComponent<Renderer>();
        myR.enabled = true;
        myTp = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        if(gameLog.player == true) { 
        ClickedColor();
        transform.position = new Vector3(myTp.x, -.2f, myTp.z);
        onClick.Invoke(myNumber);
            StartCoroutine(Sound());
        }
    }
    private void OnMouseUp()
    {
        UnClickedColor();
        transform.position = new Vector3(myTp.x, myTp.y, myTp.z);
    }

    public void ClickedColor()
    {
        myR.sharedMaterial = lMat;
    }
    public void UnClickedColor()
    {
        myR.sharedMaterial = nMat;
    }
    IEnumerator Sound()
    {
        mySound.Play();
        yield return new WaitForSeconds(.5f);
    }
}
