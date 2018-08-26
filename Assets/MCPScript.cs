using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MCPScript : MonoBehaviour {

    

	enum GameState { Start, Main, End};

	private GameState gameState = GameState.Start;

    public Canvas StartCanvas;
    public Canvas MainCanvas;
    public Canvas EndCanvas;
    public Image Fader;
    public Canvas FaderCanvas;

	// Use this for initialization
	void Start () {
        StartCanvas.enabled = true;
        MainCanvas.enabled = false;
        EndCanvas.enabled = false;
    }

    private void UpdateBasedOneGameState()
    {
        FaderCanvas.GetComponent<Canvas>().sortingOrder = 1;
        Fader.GetComponent<Animation>().Play();

        Invoke("MiddleStep", 1);
       
    }

    private void MiddleStep()
    {
        switch (gameState)
        {
            case GameState.Start:
                StartCanvas.enabled = true;
                MainCanvas.enabled = false;
                EndCanvas.enabled = false;

                break;
            case GameState.Main:
                StartCanvas.enabled = false;
                MainCanvas.enabled = true;
                EndCanvas.enabled = false;
                break;
            case GameState.End:
                StartCanvas.enabled = false;
                MainCanvas.enabled = false;
                EndCanvas.enabled = true;
                break;
        }

        Invoke("NextStep", 1);
    }

    private void NextStep()
    {
        FaderCanvas.GetComponent<Canvas>().sortingOrder = -1;        
    }

    public void ClickToPlay()
    {
        
        Debug.Log("Click to Play");
        gameState = GameState.Main;
        UpdateBasedOneGameState();
    }

    public void ClickToEnd()
    {
        Debug.Log("Click to End");
        gameState = GameState.End;
        UpdateBasedOneGameState();
    }

    public void ClickToRestart()
    {
        Debug.Log("Click to Restart");
        gameState = GameState.Start;
        UpdateBasedOneGameState();
    }

    // Update is called once per frame
    void Update () {
		
	}
}
