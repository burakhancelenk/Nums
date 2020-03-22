using System.Collections;
using System.Collections.Generic;
using System.Net.Mime ;
using UnityEngine;
using UnityEngine.EventSystems ;
using UnityEngine.UI ;

public class Numpad : MonoBehaviour, IPointerDownHandler
{
	public Text numBarText ;
	public byte digit ;
	public SoundFX SoundManager ;

	private void Start()
	{
		SoundManager = GameObject.Find("SoundFX").GetComponent<SoundFX>() ;
	}

	public void OnPointerDown(PointerEventData data)
	{
		SoundManager.Play("ButtonClick");
		if (numBarText.text.Length < 4)
		{
			numBarText.text = numBarText.text + digit ;
		}
	}
	
	
}
