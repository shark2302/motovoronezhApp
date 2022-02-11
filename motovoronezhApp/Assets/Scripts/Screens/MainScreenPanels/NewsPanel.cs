using System;
using System.Collections.Generic;
using DefaultNamespace;
using Request;
using Screens.Items;
using UnityEngine;
using UnityEngine.UI;

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
		
		[SerializeField]
		private GameObject _showMoreButton;

		private GameObject _spawnedShowMoreButton;


		private List<PostData> _news;


		private void Awake()
		{
			_news = new List<PostData>();
		}

		private void OnEnable()
		{
			if(_news.Count == 0)
				GetPostsFromServer(0);
		}

		
		protected virtual void GetPostsFromServer(int fromIndex)
		{
			
			AppController.WindowManager.OpenLoadingScreen();
			AppController.RequestManager.SendNewsRequest(fromIndex, (result
				, responcode) =>
			{
				AppController.WindowManager.CloseLoadingScreen();
				switch (responcode)
				{
					case 200:
						CreateNews(result);
						break;
				}
				
			});
		}

		public void OnShowMoreButtonCLicked()
		{
			GetPostsFromServer(_news.Count);
		}
		
		protected void CreateNews(PostsRequest.NewsRequestResult responceResult)
		{
			if (responceResult.posts.Length > 0 && _spawnedShowMoreButton != null)
			{
				Destroy(_spawnedShowMoreButton);
			}
			
			_news.AddRange(responceResult.posts);
			foreach (var result in responceResult.posts)
			{
				var go = Instantiate(_newPrefab, _content.transform);
				if (go.TryGetComponent<PostItem>(out var item))
				{
					var date = DateTimeOffset.FromUnixTimeSeconds(result.data).UtcDateTime;
					item.SetData(result.title, date.ToString(), result.message, result.user.username);
				}
				Instantiate(_separator, _content.transform);
			}

			_spawnedShowMoreButton = Instantiate(_showMoreButton, _content.transform);
			if (_spawnedShowMoreButton.TryGetComponent<Button>(out var button))
			{
				button.onClick.AddListener(OnShowMoreButtonCLicked);
			}
		}
	}
}