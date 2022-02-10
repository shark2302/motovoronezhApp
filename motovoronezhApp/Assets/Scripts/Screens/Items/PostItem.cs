using System;
using System.Collections.Generic;
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
		private Text _text;

		[SerializeField] 
		private Text _name;
		
		[SerializeField]
		private GameObject _photoBlock;

		[SerializeField] 
		private GameObject _imagePrefab;
		
		
		private List<string> _textureUrls;

		public void SetData(string title, string date, string text, string name)
		{
			_textureUrls = new List<string>();
			_title.text = title;
			_date.text = date;
			text = CheckImagesInText(text);
			_text.text = text;
			_name.text = String.Format(_name.text, name);
			
			SpawnImageItems();
		}

		private string CheckImagesInText(string text)
		{
			Regex regex = new Regex(@"\[img].*\[\/img\]");
			var matches = regex.Matches(text);
			foreach (Match match in matches)
			{
				var value = match.Value;
				text = text.Replace(value, string.Empty);
				_textureUrls.Add(value.Replace("[img]", string.Empty).Replace("[/img]", string.Empty));
			}

			return text;
		}

		private void SpawnImageItems()
		{
			_photoBlock.SetActive(_textureUrls.Count > 0);
			
			foreach (var url in _textureUrls)
			{
				if (Instantiate(_imagePrefab, _photoBlock.transform).TryGetComponent<ImageItem>(out var imageItem))
				{
					imageItem.SetData(url);
					Debug.Log(url);
				}
			}
		}
	}
}