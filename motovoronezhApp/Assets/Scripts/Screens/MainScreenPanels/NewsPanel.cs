using System;
using DefaultNamespace;
using Request;
using Screens.Items;
using UnityEngine;

namespace Screens.MainScreenPanels
{
	public class NewsPanel : MonoBehaviour
	{
		[SerializeField]
		private GameObject _content;

		[SerializeField] 
		private GameObject _newPrefab;

		[SerializeField] 
		private GameObject _separator;
		
		private void OnEnable()
		{
			AppController.RequestManager.SendNewsRequest(0, (result
				, responcode) =>
			{
				switch (responcode)
				{
					case 200:
						CreateNews(result);
						break;
				}
				
			});
		}

		private void CreateNews(NewsRequest.NewsRequestResult responceResult)
		{
			Instantiate(_separator, _content.transform);
			foreach (var result in responceResult.posts)
			{
				var go = Instantiate(_newPrefab, _content.transform);
				if (go.TryGetComponent<NewItem>(out var item))
				{
					var date = DateTimeOffset.FromUnixTimeSeconds(result.data).UtcDateTime;
					item.SetData(result.title, date.ToString(), result.message, result.user.username);
				}
				Instantiate(_separator, _content.transform);
			}
		}
	}
}