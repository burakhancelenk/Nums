using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations ;
using UnityEngine;
using UnityEngine.EventSystems ;
using UnityEngine.SceneManagement ;
using UnityEngine.UI ;

public class TutorialButton : MonoBehaviour,IPointerDownHandler
{
	public SoundFX SoundManager ;
	public void OnPointerDown(PointerEventData data)
	{
		SoundManager.Play("ButtonClick");
		SceneManager.LoadScene(2);
	}
}
