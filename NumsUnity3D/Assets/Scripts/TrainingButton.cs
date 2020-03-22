using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems ;
using UnityEngine.SceneManagement ;

public class TrainingButton : MonoBehaviour, IPointerDownHandler
{

	public SoundFX SoundManager ;
	
	public void OnPointerDown(PointerEventData data)
	{
		SoundManager.Play("ButtonClick");
		SceneManager.LoadScene(1);
	}
	
}
