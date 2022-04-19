using System;
using System.Collections.Generic;
using DefaultNamespace;
using Request;
using Screens.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.MainScreenPanels
{
    public class DalnoboyPanel: MonoBehaviour
    {
        [SerializeField]
        private GameObject _content;

        [SerializeField] 
        private GameObject _postPrefab;
        
        [SerializeField] 
        private GameObject _separator;
		
        [SerializeField]
        private GameObject _showMoreButton;

        private GameObject _spawnedShowMoreButton;


        protected List<ShortPostInfoRequest.ShortInfoPostData> _posts;
        
        private void Awake()
        {
            _posts = new List<ShortPostInfoRequest.ShortInfoPostData>();
        }

        private void OnEnable()
        {
            if(_posts.Count == 0)
                GetPostsFromServer(0);
        }
        
        public void OnShowMoreButtonCLicked()
        {
            GetPostsFromServer(_posts.Count);
        }
        
        protected void GetPostsFromServer(int fromIndex)
        {
            AppController.WindowManager.OpenLoadingScreen();
            AppController.RequestManager.SendShortInfoPostsRequest(fromIndex, (result
                , responcode) =>
            {
                AppController.WindowManager.CloseLoadingScreen();
                switch (responcode)
                {
                    case 200:
                        CreateShortPosts(result);
                        break;
                }
				
            });
        }

        private void CreateShortPosts(ShortPostInfoRequest.ShortInfoPostRequestResult responseResult) 
        {
            if (responseResult.posts.Length > 0 && _spawnedShowMoreButton != null)
            {
                Destroy(_spawnedShowMoreButton);
            }
			
            _posts.AddRange(responseResult.posts);
            foreach (var result in responseResult.posts)
            {
                var go = Instantiate(_postPrefab, _content.transform);
                if (go.TryGetComponent<ShortPostItem>(out var item))
                {
                    var date = DateTimeOffset.FromUnixTimeSeconds(result.data).UtcDateTime;
                    item.SetData(result.title, result.user.username, date.ToString(), result.postId);
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