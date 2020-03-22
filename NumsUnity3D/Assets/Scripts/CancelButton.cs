using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems ;
using UnityEngine.UI;

public class CancelButton : MonoBehaviour, IPointerDownHandler {

	public GameObject MultiplayerTextBox ;
	public SoundButton soundButton ;
	public TutorialButton tutorialButton ;
	public SoundFX SoundManager ;

	public void OnPointerDown(PointerEventData data)
	{
		MultiplayerGameManager.CancelConnectingAttempt = true;
		GameObject.Find("MultiplayerGameManager").GetComponent<MultiplayerGameManager>().DisconnectFromServer();
		MultiplayerTextBox.SetActive(false);
		soundButton.enabled = true ;
		tutorialButton.enabled = true ;
		SoundManager.Play("ButtonClick");
	}
}
