using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Point : MonoBehaviour {
    private int firstPoint=1500;
    private int deacreseAmount = 1;
	public static float point ;
    private Text pointText;
	[HideInInspector]
	public static bool gameStopped ;

	public GameObject EndGameScreen ;

	

	void Start () {
        pointText = GetComponent<Text>();
        pointText.text = firstPoint.ToString();
		point = firstPoint ;
	}
	
	

	void Update () {
        if (PowerButton1.power.Status != Freeze.STATUS.Using)
        {
	        if (!gameStopped)
	        {
		        point = point - deacreseAmount * Time.deltaTime;
		        pointText.text = ((int)point).ToString();
		        if (point <= 0)
		        {
			        gameStopped = true ;
			        if (MultiplayerGameManager.ConnectedToServer)
			        {
				        object[] param = {} ;
				        GameObject.Find("MultiplayerGameManager").GetComponent<MultiplayerGameManager>()
					        .SendMessageToServer("ZeroPoint",param);
			        }
			        else
			        {
				        EndGameScreen.SetActive(true);
				        EndGameScreen.transform.Find("FailSuccessText").gameObject.GetComponent<Text>().text =
					        "You failed !" ;
			        }
			        
		        }
	        }
            
        }
	}
}
