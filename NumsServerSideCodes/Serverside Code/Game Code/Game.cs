using System;
using System.Collections.Generic;
using System.Linq ;
using PlayerIO.GameLibrary;

namespace NumsUnity3D {
	public class Player : BasePlayer
	{
		public int score = -1 ;
		public bool pointEnded = false ;
	}


	[RoomType("NumsRoom")]
	public class GameCode2 : Game<Player> {

		// This method is called when an instance of your the game is created
		public override void GameStarted() {
			// anything you write to the Console will show up in the 
			// output window of the development server
			Console.WriteLine("Game is started: " + RoomId);
		}

		private void FinishGame(Player player , bool foundTheNumber) 
		{
			if (foundTheNumber)
			{
				Broadcast("FinishGame",true,player.ConnectUserId);
			}
			else
			{
				foreach (var p in Players)
				{
					if (!p.pointEnded)
					{
						break;
					}
					Broadcast("FinishGame",false);
				}
			}
			
		}

		// This method is called when the last player leaves the room, and it's closed down.
		public override void GameClosed() {
			Console.WriteLine("RoomId: " + RoomId);
		}

		// This method is called whenever a player joins the game
		public override void UserJoined(Player player) {
			if (PlayerCount >= 2)
			{
				Broadcast("StartGame");
			}
		}
		
		public override bool AllowUserJoin(Player player) {
			//Check if there's room for this player.
			if (PlayerCount < 2) {
				return true;
			}
			return false;
		}

		// This method is called when a player leaves the game
		public override void UserLeft(Player player) {
			Broadcast("PlayerLeft");
		}

		// This method is called when a player sends a message into the server code
		public override void GotMessage(Player player, Message message) {
			switch(message.Type) {
				case "PlayerFoundTheNumber":
					FinishGame(player,true);
					break;
				case "pointEnded":
					player.pointEnded = true ;
					FinishGame(player,false);
					break;
			}
		}
	}
	
	[RoomType("Lobby")]
	public class GameCode1 : Game<Player>
	{
		public override void GameStarted() { }
		public override void GameClosed() { }

		public override void UserJoined(Player player)
		{
			Player opponent = null;
			if (PlayerCount >= 2)
			{
				foreach (Player p in Players)
				{
					if (p != player)
					{
						opponent = p;
						break;
					}
				}
			}

			if (opponent != null)
			{
				string id = randomString(20);

				opponent.Send("GameFound", id);
				player.Send("GameFound", id);

				opponent.Disconnect();
				player.Disconnect();
			}
		}

		public override void UserLeft(Player player) { }


		private static string randomString(int length)
		{
			string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
			char[] chars = new char[length];
			Random random = new Random();

			for (int i = 0; i < length; i++)
			{
				chars[i] = allowedChars[random.Next(0, allowedChars.Length)];
			}

			return new string(chars);
		}
	}
	
}