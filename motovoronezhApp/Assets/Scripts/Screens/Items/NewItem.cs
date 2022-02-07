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

		public void SetData(string title, string date, string text)
		{
			_title.text = title;
			_date.text = date;
			_text.text = text;
		}
	}
}