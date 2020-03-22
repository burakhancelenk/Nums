using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems ;

public class PlayButton : MonoBehaviour, IPointerDownHandler
{

	public GameObject TrainingButton ;
	public GameObject OnlinePlayButton ;
	public SoundFX SoundManager ;

	public void OnPointerDown(PointerEventData data)
	{
		SoundManager.Play("ButtonClick");
		TrainingButton.SetActive(true);
		OnlinePlayButton.SetActive(true);
		gameObject.SetActive(false);
	}
	
}
