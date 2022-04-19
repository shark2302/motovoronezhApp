using System;
using System.Text.RegularExpressions;
using Screens.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
	public class PostScreen : Screen
	{
		public class PostScreenData : ScreenData
		{
			public string Title;
			public string Username;
			public string Date;
			public string Text;
		}

		[SerializeField] 
		private Text _title;

		[SerializeField] 
		private Text _username;

		[SerializeField] 
		private Text _date;

		[SerializeField]
		private GameObject _content;
		
		[SerializeField] 
		private GameObject _imagePrefab;

		[SerializeField] 
		private GameObject _textPrefab;
		
		[SerializeField] 
		private GameObject _linkPrefab;

		
		private PostScreenData _data;

		public override void SetData(ScreenData data)
		{
			if (data is PostScreenData ps)
			{
				_data = ps;
				UpdateScreen();
			}
		}

		private void UpdateScreen()
		{
			_title.text = _data.Title;
			_date.text = _data.Date;
			_username.text = _data.Username;
			CheckTextAndSpawnUIElements(_data.Text);
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
		
		private void SpawnLinkItem(string url, string text)
		{
			if (Instantiate(_linkPrefab, _content.transform).TryGetComponent<LinkItem>(out var linkItem))
			{
				linkItem.SetData(url, text);
			}
		}

		private void CheckTextAndSpawnUIElements(string text)
		{
			String tempString = text;
			Regex regex = new Regex(@"\[img].*\[\/img\]|\[url=.*].*\[\/url\]");
			var matches = regex.Matches(text);
			
			if (matches.Count == 0)
			{
				tempString = tempString.Replace("[b]", "<b>").Replace("[/b]", "</b>");
				SpawnTextItem(tempString);
				return;
			}

			var firstMatch = matches[0];
			
			var value = firstMatch.Value;
			var textArray = tempString.Split(new []{value}, StringSplitOptions.None);
			CheckTextAndSpawnUIElements(textArray[0]);
			if (value.Contains("[url"))
			{
				var array = value.Split(new [] {"]"}, StringSplitOptions.None);
				if (value.Contains("[img"))
				{
					array = value.Split(new [] {"[img]"}, StringSplitOptions.None);
				}
				SpawnLinkItem(array[0].Replace("[url=", string.Empty), array[1].Replace("[/url", string.Empty));
			}
			else if (value.Contains("[img]"))
			{
				SpawnImageItem(value.Replace("[img]", string.Empty).Replace("[/img]", string.Empty));
			}
			CheckTextAndSpawnUIElements(textArray[1]);
			
		}

		public void OnBackButtonClick()
		{
			Destroy(gameObject);
		}
	}
}