using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;
using UnityEngine.EventSystems ;

public class SoundButton : MonoBehaviour,IPointerDownHandler
{

	public Sprite soundActive ;
	public Sprite soundDesactive ;
	public SoundFX SoundManager ;


	public void OnPointerDown(PointerEventData data)
	{
		if (SoundFX.Mute)
		{
			SoundManager.Play("ButtonClick");
			GetComponent<Image>().sprite = soundActive ;
			SoundFX.Mute = false ;
		}
		else
		{
			GetComponent<Image>().sprite = soundDesactive ;
			SoundFX.Mute = true ;
		}
	}
}
