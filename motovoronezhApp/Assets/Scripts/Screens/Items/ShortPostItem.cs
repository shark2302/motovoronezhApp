using System;
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

		public void SetData(string title, string username, string date)
		{
			_title.text = title;
			_username.text = String.Format(_username.text, username);
			_date.text = date;
		}

	}
}