using System;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Items
{
	public class NewItem : MonoBehaviour
	{

		[SerializeField] 
		private Text _title;
		
		[SerializeField] 
		private Text _date;
		
		[SerializeField] 
		private Text _text;

		[SerializeField] 
		private Text _name;

		public void SetData(string title, string date, string text, string name)
		{
			_title.text = title;
			_date.text = date;
			_text.text = text;
			_name.text = String.Format(_name.text, name);
		}
	}
}