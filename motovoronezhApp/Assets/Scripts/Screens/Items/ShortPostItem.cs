using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Items
{
	public class ShortPostItem : MonoBehaviour
	{
		[SerializeField] 
		private Text _title;

		[SerializeField] 
		private Text _username;
		
		[SerializeField] 
		private Text _date;

		private int _postId;
		
		public void SetData(string title, string username, string date, int postId)
		{
			_title.text = title;
			_username.text = String.Format(_username.text, username);
			_date.text = date;
			_postId = postId;
		}

		public void OnGoButtonClick()
		{
			AppController.WindowManager.OpenLoadingScreen();
			AppController.RequestManager.SendMessageFromPostRequest(_postId, (result
				, responcode) =>
			{
				AppController.WindowManager.CloseLoadingScreen();
				switch (responcode)
				{
					case 200:
						AppController.WindowManager.OpenPostScreen(_title.text, _username.text, _date.text, result.message);
						break;
				}
				
			});
		}
	}
}