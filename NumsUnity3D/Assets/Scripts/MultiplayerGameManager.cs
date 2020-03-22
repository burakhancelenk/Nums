using System ;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml ;
using PlayerIOClient;
using UnityEngine.SceneManagement ;
using UnityEngine.UI ;

public class MultiplayerGameManager : MonoBehaviour {

	public Text MultiplayerText;
	public GameObject MultiplayerGamePlayText ;
	public GameObject cancelButton ;
	public GameObject EndGameScreen ;
	public GameObject TouchBlocker ;
	public SoundFX SoundManager ;
	private Connection pioconnection;
	private Client myClient ;
	private List<Message> msgList = new List<Message>(); //  Messsage queue implementation
	private bool joinedroom = false;
	public static bool ConnectedToServer ;
	public static bool CancelConnectingAttempt ;

	// UI stuff
	private string infomsg = "";

	void Start()
	{
		DontDestroyOnLoad(gameObject);
		Application.runInBackground = true ;
	}

	public void ConnectToServer()
	{
		MultiplayerText.text = "Connecting to server..." ;
		System.Random random = new System.Random();
		string userid = "Guest" + random.Next(0, 10000);
		
		PlayerIO.Authenticate(
			"nums-dfc3u59btko2hq0nmli0g",            //Your game id
			"public",                               //Your connection id
			new Dictionary<string, string> {        //Authentication arguments
				{ "userId", userid },
			},
			null,                                   //PlayerInsight segments
			delegate (Client client) {
				Debug.Log("Successfully connected to Player.IO");
				infomsg = "Successfully connected to Player.IO";
				MultiplayerText.text = "Connected to server..." ;
				ConnectedToServer = true ;
				myClient = client ;
				Debug.Log("Create ServerEndpoint");
				// Comment out the line below to use the live servers instead of your development server
				//client.Multiplayer.DevelopmentServer = new ServerEndpoint("localhost", 8184);
				if (CancelConnectingAttempt)
				{
					MultiplayerText.text = "Disconnecting from server..." ;
					myClient.Logout();
					ConnectedToServer = false ;
				}
				else
				{
					ConnectToLobby();
				}
			},
			delegate (PlayerIOError error) {
				Debug.Log("Error connecting: " + error.ToString());
				MultiplayerText.text = "Connection failed. Please check your internet connection and try again." ;
				ConnectedToServer = false ;
				infomsg = error.ToString();
			}
		);
	}

	void ConnectToLobby()
	{
		myClient.Multiplayer.CreateJoinRoom(
			"Matchmaking Lobby",                    //Room id. If set to null a random roomid is used
			"Lobby",                   //The room type started on the server
			false,                               //Should the room be visible in the lobby?
			null,
			null,
			delegate (Connection connection) {
				Debug.Log("Joined Room.");
				infomsg = "Joined Room.";
				MultiplayerText.text = "Searching for players..." ;
				// We successfully joined a room so set up the message handler
				pioconnection = connection;
				pioconnection.OnMessage += handlemessage;
				if (CancelConnectingAttempt)
				{
					MultiplayerText.text = "Disconnecting from server..." ;
					pioconnection.Disconnect();
					myClient.Logout();
					ConnectedToServer = false ;
				}
				else
				{
					joinedroom = true;
				}
				
			},
			delegate (PlayerIOError error) {
				Debug.Log("Error Joining Room: " + error.ToString());
				infomsg = error.ToString();
			}
		);
	}

	void ConnectToGame(string roomId)
	{
		myClient.Multiplayer.CreateJoinRoom(
			roomId,                    //Room id. If set to null a random roomid is used
			"NumsRoom",                   //The room type started on the server
			false,                               //Should the room be visible in the lobby?
			null,
			null,
			delegate (Connection connection) {
				Debug.Log("Joined Room.");
				infomsg = "Joined Room.";
				cancelButton.SetActive(true);
				// We successfully joined a room so set up the message handler
				pioconnection = connection;
				pioconnection.OnMessage += handlemessage;
				joinedroom = true;
			},
			delegate (PlayerIOError error) {
				Debug.Log("Error Joining Room: " + error.ToString());
				infomsg = error.ToString();
			}
		);
		
	}

	
	public void DisconnectFromServer()
	{
		if (ConnectedToServer)
		{
			if (joinedroom)
			{
				pioconnection.Disconnect();
				joinedroom = false ;
			}
			myClient.Logout();
			ConnectedToServer = false ;
			//CancelConnectingAttempt = false ;
		}
		
	}

	public void SendMessageToServer(string msg, object[] msgparams)
	{
		if (msg == "NumberFound")
		{
			if ((int)msgparams[0] == (int)msgparams[1])
			{
		       pioconnection.Send("PlayerFoundTheNumber");		
			}
		}
		else if (msg == "ZeroPoint")
		{
			pioconnection.Send("pointEnded");
			MultiplayerGamePlayText.SetActive(true);
			MultiplayerGamePlayText.GetComponentInChildren<Text>().text = "Other player still playing..." ;
		}
	}

	void handlemessage(object sender, Message m) {
		msgList.Add(m);
	}
	
	

	void FixedUpdate() {
		// process message queue
		foreach (Message m in msgList) {
			switch (m.Type) {
				case "PlayerLeft":
					Time.timeScale = 0 ;
					MultiplayerGamePlayText.SetActive(true);
					MultiplayerGamePlayText.transform.Find("CalcelButton").gameObject.SetActive(false);
					MultiplayerGamePlayText.transform.Find("MultiplayerText").GetComponent<Text>().text =
						"Other player left the game. You win!" ;
					TouchBlocker.SetActive(true);
					break;
				case "StartGame":
					SceneManager.LoadScene(1);
					break;
				case "FinishGame":
					
					Time.timeScale = 0 ;
					EndGameScreen.SetActive(true);
					
					if (m.GetBoolean(0))
					{
						if (m.GetString(1) == myClient.ConnectUserId)
						{
							EndGameScreen.GetComponentInChildren<Text>().text = "You win!" ;
						}
						else
						{
							EndGameScreen.GetComponentInChildren<Text>().text = "Other player win!" ;
							SoundManager.Play("Lose");
						}
					}
					else
					{
						EndGameScreen.GetComponentInChildren<Text>().text = "Ended in a draw!" ;
					}
					break;
				case "GameFound":
					cancelButton.SetActive(false);
					MultiplayerText.text = "Game found.\nStarting..." ;
					ConnectToGame(m.GetString(0));
					break;
			}
		}

		// clear message queue after it's been processed
		msgList.Clear();
	}

}