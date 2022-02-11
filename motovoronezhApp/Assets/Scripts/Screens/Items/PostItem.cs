using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Items
{
	public class PostItem : MonoBehaviour
	{

		[SerializeField] 
		private Text _title;
		
		[SerializeField] 
		private Text _date;
		
		[SerializeField] 
		private Text _name;

		[SerializeField]
		private GameObject _content;
		
		[SerializeField] 
		private GameObject _imagePrefab;

		[SerializeField] 
		private GameObject _textPrefab;
		

		public void SetData(string title, string date, string text, string name)
		{
			_title.text = title;
			_date.text = date;
			_name.text = String.Format(_name.text, name);
			CheckTextAndSpawnUIElements(text);
		}
		

		private void SpawnImageItem(string url)
		{
			if (Instantiate(_imagePrefab, _content.transform).TryGetComponent<ImageItem>(out var imageItem))
			{
				imageItem.SetData(url);
			}
		}
		
		private void SpawnTextItem(string text)
		{
			if (Instantiate(_textPrefab, _content.transform).TryGetComponent<TextItem>(out var textItem))
			{
				textItem.SetData(text);
			}
		}

		private void CheckTextAndSpawnUIElements(string text)
		{
			String tempString = text;
			Regex regex = new Regex(@"\[img].*\[\/img\]");
			var matches = regex.Matches(text);
			tempString = tempString.Replace("[b]", "<b>").Replace("[/b]", "</b>");
			
			if (matches.Count == 0)
			{
				SpawnTextItem(tempString);
			}
			
			foreach (Match match in matches)
			{
				var value = match.Value;
				var textArray = tempString.Split(new []{value}, StringSplitOptions.None);
				SpawnTextItem(textArray[0]);
				if(textArray[0] != String.Empty)
					tempString = tempString.Replace(textArray[0], String.Empty);
				SpawnImageItem(value.Replace("[img]", string.Empty).Replace("[/img]", string.Empty));
				SpawnTextItem(textArray[1]);
			}
		}
		
	}
}