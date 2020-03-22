using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EraseButton : MonoBehaviour,IPointerUpHandler {

    public Text numText;
    public SoundFX SoundManager ;

    private void Start()
    {
        SoundManager = GameObject.Find("SoundFX").GetComponent<SoundFX>() ;
    }


    public void OnPointerUp(PointerEventData data)
    {
        SoundManager.Play("Erase");
        if (GameManager.TutorialMode)
        {
            TutorialManager.erase = true ;
            GetComponent<Button>().enabled = false ;
        }
        if (numText.text.Length > 0)
        {
            numText.text = numText.text.Substring(0, numText.text.Length - 1);
        }
    }

}
