using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems ;
using UnityEngine.UI;

public class OnlinePlayButton : MonoBehaviour, IPointerDownHandler
{

	public MultiplayerGameManager mg ;
	public GameObject MultiplayerTextBox ;
	public SoundButton soundButton ;
	public TutorialButton tutorialButton ;
	public SoundFX SoundManager ;

	public void OnPointerDown(PointerEventData data)
	{
		SoundManager.Play("ButtonClick");
		soundButton.enabled = false ;
		tutorialButton.enabled = false ;
		MultiplayerTextBox.SetActive(true);
		MultiplayerGameManager.CancelConnectingAttempt = false ;
		if (!MultiplayerGameManager.ConnectedToServer)
		{
			mg.ConnectToServer();
		}
	}
	
}
