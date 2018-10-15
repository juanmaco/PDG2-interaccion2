using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class myLogica : MonoBehaviour {
    public OnClick[] myButtons;
    public List<int> colorList;

    public float showTime = 0.5f;
    public float pauseTime = 0.5f;

    bool maquina = false;
   public bool player = false;
    bool gameO = false;

    private int myRandom;
    public int level = 3;
    private int playerLevel;

    public Text gameOver;

	// Use this for initialization
	void Start () {
        playerLevel = 0;
        gameOver.text = "";
        maquina = true;
        for (int i=0; i < myButtons.Length; i++)
        {
            myButtons[i].onClick += ButtonClicked;
            myButtons[i].myNumber = i;
        }
        
	}

    void ButtonClicked(int _number)
    {
        if(player == true) { 
        if (_number == colorList[playerLevel])
            {
                playerLevel += 1;
            } else
        {
            GameOver();
        }
            if(playerLevel == level)
            {
                level += 1;
                playerLevel = 0;
                maquina = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
        
		if(maquina)
        {
            player = false;
            maquina = false;
            StartCoroutine(Robot());
        }
        if(player == false && gameO== false)
        {
            gameOver.text = " ";
        }
        if(player== true)
        {
            gameOver.text = "Player Turn";
        }
        
    }
     IEnumerator Robot()
    {
        for (int i = 0; i < level; i++) {
            if (colorList.Count < level)
            {
                myRandom = Random.Range(0, myButtons.Length);
                colorList.Add(myRandom);
            }
            yield return new WaitForSeconds(0.5f);
            myButtons[colorList[i]].ClickedColor();
            myButtons[colorList[i]].mySound.Play();
            yield return new WaitForSeconds(showTime);
        myButtons[colorList[i]].UnClickedColor();
        yield return new WaitForSeconds(pauseTime);
        }
        player = true;
    }
    void GameOver()
    {
        gameOver.text = "GAME OVER";
        player = false;
        maquina = false;
        gameO = true;
    }
}
