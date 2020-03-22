using System ;
using System.Collections;
using System.Collections.Generic;
using UnityEditor ;
using UnityEngine;
using UnityEngine.UI ;

public class TutorialManager : MonoBehaviour
{

	public static bool mainLogic ;
	public static bool point ;
	public static bool moveSkill ;
	public static bool freezeSkill ;
	public static bool correctPositions ;
	public static bool correctDigits ;
	public static bool erase ;
	public static bool submit ;
	public static bool hintSkill ;
	public static bool last4 ;

	public RectTransform TutorialTextBox ;
	public RectTransform TutorialBackground ;
	public RectTransform PointRT ;
	public RectTransform MoveSkillRT ;
	public RectTransform FreezeSkillRT ;
	public RectTransform Last4RT ;
	public RectTransform CorrectPositionsRT ;
	public RectTransform CorrectDigitsRT ;
	public RectTransform EraseRT ;
	public RectTransform SubmitRT ;
	public RectTransform HintRT ;

	public Sprite TutorialBackgroundElips ;
	public Sprite TutorialBackgroundElips2 ;
	public Sprite TutorialBackgroundRectangle ;

	private Vector3 basePos ;
	
	
	private void Start()
	{
		Time.timeScale = 0 ;
		GameManager.TutorialMode = true ;
		mainLogic = false ;
		point = false ;
		moveSkill = false ;
		freezeSkill = false ;
		hintSkill = false ;
		correctPositions = false ;
		correctDigits = false ;
		erase = false ;
		submit = false ;
		last4 = false ;
		basePos = TutorialTextBox.position ;
		StartCoroutine(MainLogic()) ;
	}

	public IEnumerator MainLogic()
	{
		while (true)
		{
			if (mainLogic)
			{
				StartCoroutine(Point()) ;
				break;
			}
			yield return null ;
		}
	}

	public IEnumerator Point()
	{
		TutorialTextBox.gameObject.SetActive(true);
		TutorialTextBox.GetComponentInChildren<Image>().sprite = TutorialBackgroundElips ;
		TutorialTextBox.GetComponentInChildren<Text>().text =
			"This is your point it reduces in every seconds and every submission." ;
		TutorialTextBox.pivot = Vector2.up;
		TutorialTextBox.position = PointRT.position ;
		while (true)
		{
			if (point)
			{
				StartCoroutine(Submit()) ;
				break;
			}
			yield return null ;
		}
	}

	public IEnumerator Submit()
	{
		TutorialTextBox.gameObject.SetActive(true);
		TutorialTextBox.GetComponentInChildren<Text>().text = 
			"This is \"Submit\" button, you can push your number to guess the right number with this button." ;
		TutorialTextBox.pivot = Vector2.one*0.5f;
		TutorialBackground.Rotate(180,180,0);
		TutorialBackground.GetComponent<Shadow>().effectDistance = Vector2.up*9;
		TutorialTextBox.pivot = Vector2.right;
		TutorialTextBox.position = SubmitRT.position ;
		while (true)
		{
			if (submit)
			{
				StartCoroutine(Erase()) ;
				break;
			}
			yield return null ;
		}
	}
	
	public IEnumerator Erase()
	{
		TutorialTextBox.gameObject.SetActive(true);
		TutorialTextBox.GetComponentInChildren<Text>().text = "This is \"Erase\" button, so dont worry if you make mistake." ;
		TutorialTextBox.pivot = Vector2.one * 0.5f ;
		TutorialBackground.Rotate(0,-180,0);
		TutorialTextBox.pivot = Vector2.zero;
		TutorialTextBox.position = EraseRT.position ;
		while (true)
		{
			if (erase)
			{
				StartCoroutine(CorrectPositions()) ;
				break;
			}
			yield return null ;
		}
	}
	
	public IEnumerator CorrectPositions()
	{
		TutorialTextBox.gameObject.SetActive(true);
		TutorialTextBox.GetComponentInChildren<Text>().text =
			"You can see how many digits have right value and place in your guess." ;
		TutorialTextBox.pivot = Vector2.one * 0.5f ;
		TutorialBackground.Rotate(0,180,0);
		TutorialTextBox.pivot = Vector2.right;
		TutorialTextBox.position = CorrectPositionsRT.position ;
		while (true)
		{
			if (correctPositions)
			{
				StartCoroutine(CorrectDigits()) ;
				break;
			}
			yield return null ;
		}
	}
	
	public IEnumerator CorrectDigits()
	{
		TutorialTextBox.gameObject.SetActive(true);
		TutorialTextBox.GetComponentInChildren<Text>().text =
			"You can see how many digits have right value but wrong place in your guess." ;
		TutorialTextBox.pivot = Vector2.one * 0.5f ;
		TutorialBackground.Rotate(0,-180,0);
		TutorialTextBox.pivot = Vector2.zero;
		TutorialTextBox.position = CorrectDigitsRT.position ;
		while (true)
		{
			if (correctDigits)
			{
				StartCoroutine(Last4()) ;
				break;
			}
			yield return null ;
		}
	}
	
	public IEnumerator Last4()
	{
		TutorialTextBox.gameObject.SetActive(true);
		TutorialTextBox.GetComponentInChildren<Text>().text =
			"You can see your last 4 guess here." ;
		TutorialTextBox.pivot = Vector2.one * 0.5f ;
		TutorialBackground.Rotate(-180,0,0);
		TutorialTextBox.pivot = new Vector2(0.5f,1);
		TutorialTextBox.GetComponentInChildren<Image>().sprite = TutorialBackgroundElips2 ;
		TutorialBackground.GetComponent<Shadow>().effectDistance = Vector2.up*(-9);
		TutorialTextBox.position = Last4RT.position ;
		while (true)
		{
			if (last4)
			{
				StartCoroutine(MoveSkill()) ;
				break;
			}
			yield return null ;
		}
	}
	
	public IEnumerator MoveSkill()
	{
		TutorialTextBox.gameObject.SetActive(true);
		TutorialTextBox.GetComponentInChildren<Text>().text =
			"This is \"Move Skill\". With this, you can make your guess without losing point." ;
		TutorialTextBox.pivot = Vector2.one * 0.5f ;
		TutorialBackground.Rotate(0,180,0);
		TutorialTextBox.GetComponentInChildren<Image>().sprite = TutorialBackgroundElips ;
		TutorialTextBox.pivot = Vector2.one;
		TutorialTextBox.position = MoveSkillRT.position ;
		while (true)
		{
			if (moveSkill)
			{
				StartCoroutine(FreezeSkill()) ;
				break;
			}
			yield return null ;
		}
	}
	
	public IEnumerator FreezeSkill()
	{
		TutorialTextBox.gameObject.SetActive(true);
		TutorialTextBox.GetComponentInChildren<Text>().text = 
			"This is \"Freeze Skill\". With this, you can freeze the point for 15 seconds." ;
		TutorialTextBox.position = FreezeSkillRT.position ;
		while (true)
		{
			if (freezeSkill)
			{
				StartCoroutine(HintSkill()) ;
				break;
			}
			yield return null ;
		}
	}
	
	public IEnumerator HintSkill()
	{
		TutorialTextBox.gameObject.SetActive(true);
		TutorialTextBox.GetComponentInChildren<Text>().text = "This is \"Hint\". You can take a hint for better guess." ;
		TutorialTextBox.pivot = Vector2.one*0.5f;
		TutorialBackground.Rotate(0,-180,0);
		TutorialTextBox.pivot = Vector2.up;
		TutorialTextBox.position = HintRT.position ;
		while (true)
		{
			if (hintSkill)
			{
				TutorialTextBox.GetComponentInChildren<Text>().text = "Alright! you are ready to play." ;
				TutorialBackground.GetComponent<Image>().sprite = TutorialBackgroundRectangle ;
				TutorialTextBox.pivot = Vector2.one * 0.5f ;
				TutorialTextBox.position = basePos ;
				TutorialTextBox.gameObject.SetActive(true);
				break;
			}
			yield return null ;
		}
	}
	
}
