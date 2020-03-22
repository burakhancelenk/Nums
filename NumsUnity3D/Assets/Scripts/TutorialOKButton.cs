using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ;
using UnityEngine.UI ;

public class TutorialOKButton : MonoBehaviour
{
	public Button MoveSkillButton ;
	public Button FreezeSkillButton ;
	public Button HintSkillButton ;
	public Button EraseButton ;
	public Button SubmitButton ;
	public SoundFX SoundManager ;
	
	private void Start()
	{
		GetComponent<Button>().onClick.AddListener(MainLogicPass);
		EraseButton.enabled = false ;
		MoveSkillButton.enabled = false ;
		FreezeSkillButton.enabled = false ;
		HintSkillButton.enabled = false ;
		SubmitButton.enabled = false ;
		SoundManager = GameObject.Find("SoundFX").GetComponent<SoundFX>() ;
	}

	public GameObject TutorialTextBox ;

	public void MainLogicPass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		TutorialManager.mainLogic = true ;
		GetComponent<Button>().onClick.AddListener(PointPass);
	}
	
	public void PointPass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		TutorialManager.point = true ;
		GetComponent<Button>().onClick.AddListener(SubmitPass);
	}
	
	public void SubmitPass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		EraseButton.enabled = false ;
		MoveSkillButton.enabled = false ;
		FreezeSkillButton.enabled = false ;
		HintSkillButton.enabled = false ;
		SubmitButton.enabled = true ;
		GetComponent<Button>().onClick.AddListener(ErasePass);

	}
	
	public void ErasePass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		EraseButton.enabled = true ;
		MoveSkillButton.enabled = false ;
		FreezeSkillButton.enabled = false ;
		HintSkillButton.enabled = false ;
		SubmitButton.enabled = false ;
		GetComponent<Button>().onClick.AddListener(CorrectPositionsPass);

	}
	
	public void CorrectPositionsPass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		TutorialManager.correctPositions = true ;
		GetComponent<Button>().onClick.AddListener(CorrectDigitsPass);
	}
	
	public void CorrectDigitsPass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		TutorialManager.correctDigits = true ;
		GetComponent<Button>().onClick.AddListener(Last4Pass);
	}
	
	public void Last4Pass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		TutorialManager.last4 = true ;
		GetComponent<Button>().onClick.AddListener(MoveSkillPass);
	}
	
	public void MoveSkillPass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		MoveSkillButton.enabled = true ;
		GetComponent<Button>().onClick.AddListener(FreezeSkillPass);
	}
	
	public void FreezeSkillPass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		FreezeSkillButton.enabled = true ;
		GetComponent<Button>().onClick.AddListener(HintSkillPass);
	}
	
	public void HintSkillPass()
	{
		SoundManager.Play("ButtonClick");
		TutorialTextBox.SetActive(false);
		HintSkillButton.enabled = true ;
		GetComponent<Button>().onClick.AddListener(FinalTutorial);
		
	}

	public void FinalTutorial()
	{
		SoundManager.Play("ButtonClick");
		SceneManager.LoadScene(0) ;
	}
	
}
