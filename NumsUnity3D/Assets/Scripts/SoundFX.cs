using System.Collections;
using System.Collections.Generic;
using System.Net ;
using System.Threading ;
using UnityEngine;

public class SoundFX : MonoBehaviour
{
	public AudioClip[] SoundFXs ;
	/*
	 * 0- Button Click
	 * 1- Win
	 * 2- Lose
	 * 3- OKButton
	 * 4- Erase
	 * */
	public static bool Mute ;
	private AudioSource _audioSource;

	public void Play(string SoundFXName)
	{
		if (!Mute)
		{
			switch (SoundFXName)
			{
				case "ButtonClick":
					_audioSource.clip = SoundFXs[0] ;
					break;
				case "Win":
					_audioSource.clip = SoundFXs[1] ;
					break;
				case "Lose":
					_audioSource.clip = SoundFXs[2] ;
					break;
				case "OKButton":
					_audioSource.clip = SoundFXs[3] ;
					break;
				case "Erase":
					_audioSource.clip = SoundFXs[4] ;
					break;
			}

			_audioSource.time = 0.03f ;
			_audioSource.Play();
		}
	}


	void Start ()
	{
		_audioSource = GetComponent<AudioSource>() ;
		DontDestroyOnLoad(gameObject);
	}

}
