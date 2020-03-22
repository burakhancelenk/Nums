using System ;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events ;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement ;

public class OKButton : MonoBehaviour,IPointerUpHandler {

    public Text playerNumberText;
    public Text digitText;
    public Text positionText;
    public Text pointText ;
    public GameObject EndGameScreen ;
    public SoundFX SoundManager ;

    
    // handling last4values
    public Text last4NumbersText ;
    public Text last4DigitsText ;
    public Text last4PositionsText ;
    private int[] last4Numbers  = new int[4];
    private byte[] last4Digits = new byte[4];
    private byte[] last4Positions = new byte[4];
    private byte indice;
    private bool isFull;


    private void Start()
    {
        SoundManager = GameObject.Find("SoundFX").GetComponent<SoundFX>() ;
    }

    public void OnPointerUp(PointerEventData data)
    {
        if (PowerButton.power.Status != FreeMove.STATUS.Using)
        {
            Point.point = Point.point - GameManager.MovePoint[GameManager.MoveIndex] ;
            if (PowerButton1.power.Status == Freeze.STATUS.Using)
            {
                pointText.text = ((int)Point.point).ToString() ;
            }
        }
            if (int.Parse(playerNumberText.text) != GameManager.Number)
            {
                SoundManager.Play("OKButton");
                int playerNumber = int.Parse(playerNumberText.text.Trim());
                Fundamentals.Comparer.Compare(playerNumber, GameManager.Number);
                playerNumberText.text = "";
                digitText.text = Fundamentals.Comparer.OnlyValue.ToString();
                positionText.text = Fundamentals.Comparer.PlaceAndValue.ToString();
                PushOldValues(playerNumber,Fundamentals.Comparer.OnlyValue,Fundamentals.Comparer.PlaceAndValue);
                UpdateLast4Values();
                if (GameManager.TutorialMode)
                {
                    TutorialManager.submit = true ;
                } 
            }
            else
            {
                if (GameManager.TutorialMode)
                {
                    TutorialManager.submit = true ;
                }

                if (MultiplayerGameManager.ConnectedToServer)
                {
                    object[] param = {GameManager.Number,int.Parse(playerNumberText.text) } ;
                    GameObject.Find("MultiplayerGameManager").GetComponent<MultiplayerGameManager>()
                        .SendMessageToServer("NumberFound",param);
                }
                SoundManager.Play("Win");
                Point.gameStopped = true ;
                EndGameScreen.SetActive(true);
                EndGameScreen.transform.Find("FailSuccessText").gameObject.GetComponent<Text>().text =
                    "You find the number!\nScore : " + (int)Point.point ;
            }
        
    }


    private void UpdateLast4Values()
    {
        last4DigitsText.text = String.Empty;
        last4NumbersText.text = String.Empty;
        last4PositionsText.text = String.Empty;
        
        for (byte i = 0; i < 4; i++)
        {
            if (last4Numbers[i] != 0)
            {
                last4NumbersText.text += last4Numbers[i]+"\n" ;
                last4DigitsText.text += last4Digits[i]+"\n" ;
                last4PositionsText.text += last4Positions[i]+"\n" ; 
            } 
        }
    }

    private void PushOldValues(int playerNumber, byte digit , byte position)
    {
        if (isFull)
        {
            for (byte i = 0; i < 3; i++)
            {
                last4Numbers[i] = last4Numbers[i + 1] ;
                last4Digits[i] = last4Digits[i + 1] ;
                last4Positions[i] = last4Positions[i + 1] ;
            }

            last4Numbers[3] = playerNumber ;
            last4Digits[3] = digit ;
            last4Positions[3] = position ;
        }
        else
        {
            if (indice == 3)
            {
                isFull = true ;
            }

            last4Numbers[indice] = playerNumber ;
            last4Digits[indice] = digit ;
            last4Positions[indice] = position ;
            indice++ ;
        }
    }
    
}
