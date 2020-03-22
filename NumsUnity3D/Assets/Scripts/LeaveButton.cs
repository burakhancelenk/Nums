using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems ;
using UnityEngine.SceneManagement ;
using UnityEngine.UI ;

public class LeaveButton : MonoBehaviour, IPointerDownHandler
{

	private MultiplayerGameManager mg ;
	public GameObject MultiplayerGameTextBox ;
	public GameObject Blocker ;
	public SoundFX SoundManager ;

	private void Start()
	{
		mg = GameObject.Find("MultiplayerGameManager").GetComponent<MultiplayerGameManager>() ;
		MultiplayerGameTextBox.transform.Find("OKButton").GetComponent<Button>().onClick.AddListener(LeaveGame);
		MultiplayerGameTextBox.transform.Find("CancelButton").GetComponent<Button>().onClick.AddListener(CancelLeaveAttempt);
		SoundManager = GameObject.Find("SoundFX").GetComponent<SoundFX>() ;
	}

	public void OnPointerDown(PointerEventData data)
	{
		SoundManager.Play("ButtonClick");
        MultiplayerGameTextBox.SetActive(true);
		MultiplayerGameTextBox.transform.Find("CancelButton").gameObject.SetActive(true);
		Blocker.SetActive(true);

		if (MultiplayerGameManager.ConnectedToServer)
		{
			MultiplayerGameTextBox.transform.Find("MultiplayerText").GetComponent<Text>().text =
				"Go back to main menu? you will lose the game." ;
		}
		else
		{
			MultiplayerGameTextBox.transform.Find("MultiplayerText").GetComponent<Text>().text =
				"Go back to main menu?" ;
			Time.timeScale = 0 ;
		}
		
	}

	void LeaveGame()
	{
		SoundManager.Play("ButtonClick");
		mg.DisconnectFromServer();
		SceneManager.LoadScene(0);
	}

	void CancelLeaveAttempt()
	{
		SoundManager.Play("ButtonClick");
		Time.timeScale = 1 ;
		MultiplayerGameTextBox.SetActive(false);
		Blocker.SetActive(false);
	}
	
}
