using TMPro;
using UnityEngine;

namespace Screens.Items
{
	public class TextItem : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _text;

		public void SetData(string text)
		{
			_text.SetText(text);
		}
		
	}
}