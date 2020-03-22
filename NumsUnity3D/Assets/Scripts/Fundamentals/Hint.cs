using System ;
using System.Collections;
using System.Collections.Generic;
using System.Globalization ;
using UnityEngine;
using UnityEngine.EventSystems ;
using UnityEngine.UI ;
using Random = UnityEngine.Random ;

namespace Fundamentals
{
    public class Hint : MonoBehaviour , IPointerDownHandler
    {

        public Transform last4DigitsText ;
        public Transform last4PositionsText ;
        public Transform last4NumbersText ;
        public Text HintText ;
        public SoundFX SoundManager ;
        private bool hintIsOpen ;
        private bool hintCreated ;
        
        public static byte Digits = 0 ;
        public static byte Positions = 0 ;

        private void Start()
        {
            SoundManager = GameObject.Find("SoundFX").GetComponent<SoundFX>() ;
        }

        protected string CreateHint()
        {
            string Digits = GameManager.Number.ToString() ;
            byte givenDigit = (byte)Random.Range(0 , 4) ;
            hintCreated = true ;
            return givenDigit+1+". basamağın değeri = "+Digits[3-givenDigit] ;     
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            SoundManager.Play("ButtonClick");
            if (GameManager.TutorialMode)
            {
                TutorialManager.hintSkill = true ;
                GetComponent<Button>().enabled = false ;
            }
            if (hintIsOpen)
            {
                last4DigitsText.gameObject.SetActive(true);
                last4NumbersText.gameObject.SetActive(true);
                last4PositionsText.gameObject.SetActive(true);
                HintText.gameObject.SetActive(false);
                hintIsOpen = false ;
            }
            else
            {
                if (!hintCreated)
                {
                    HintText.text = CreateHint() ;
                }
                last4DigitsText.gameObject.SetActive(false);
                last4NumbersText.gameObject.SetActive(false);
                last4PositionsText.gameObject.SetActive(false);
                HintText.gameObject.SetActive(true);
                hintIsOpen = true ;
            }
            
            
        }
    }
}
