using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fundamentals;
using UnityEngine.SceneManagement ;
using UnityEngine.UI ;

public class GameManager : MonoBehaviour {

    private static int number;
    public static bool TutorialMode ;
    public static int[] MovePoint = {0,10,20,50,100,150};
    private static byte moveIndex;

    public static byte MoveIndex
    {
        get
        {
            if (moveIndex >= 5)
            {
                return moveIndex;
            }
            moveIndex++;
            return moveIndex;
            
        }
    }

    public byte digit;

    public static int Number
    {
        get
        {
            return number;
        }
    }
	
	void Start () {
        number = RequestNumber(digit);
        moveIndex = 0;
	    GameObject.Find("MultiplayerGameManager").GetComponent<MultiplayerGameManager>()
	        .MultiplayerGamePlayText = GameObject.Find("Canvas").transform.Find("MultiplayerTextBox").gameObject ;
	    GameObject.Find("MultiplayerGameManager").GetComponent<MultiplayerGameManager>()
	        .TouchBlocker = GameObject.Find("Canvas").transform.Find("Blocker").gameObject;
		GameObject.Find("MultiplayerGameManager").GetComponent<MultiplayerGameManager>()
			.EndGameScreen = GameObject.Find("Canvas").transform.Find("EndGameScreen").gameObject;
		GameObject.Find("Canvas").transform.Find("EndGameScreen").Find("MainMenuButton").GetComponent<Button>().onClick.AddListener(
			delegate
			{
				GameObject.Find("MultiplayerGameManager").GetComponent<MultiplayerGameManager>().DisconnectFromServer();
				GameObject.Find("SoundFX").GetComponent<SoundFX>().Play("ButtonClick");
				Point.gameStopped = false ;
				SceneManager.LoadScene(0);
			});
	    Time.timeScale = 1 ;
	}
	
	
	void Update () {
		
	}

    public static int RequestNumber(byte digit)
    {
        Fundamentals.Number.CurrentNumber = digit;
        return Fundamentals.Number.CurrentNumber;
    }
}
