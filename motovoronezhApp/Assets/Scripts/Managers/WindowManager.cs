using System;
using DefaultNamespace.Screens;
using DefaultNamespace.Screens.Popups;
using Screens;
using UnityEngine;

namespace DefaultNamespace.Managers
{
    public class WindowManager : MonoBehaviour
    {

        [SerializeField]
        private Canvas _canvas;

        [Header("Windwos")] 
        [SerializeField] 
        private GameObject _loginScreen;

        [SerializeField] 
        private GameObject _mainScreen;

        [SerializeField] 
        private GameObject _postScreen;

        [SerializeField] 
        private GameObject _loading;
        
        [Header("Popups")] 
        [SerializeField] 
        private GameObject _infoPopup;


        private GameObject _loadingObject;
        
        public void Awake()
        {
            AppController.WindowManager = this;
        }

        public void OpenLoginWindow()
        {
            OpenScreen<LoginScreen>(_loginScreen, new Screen.ScreenData());
        }

        public void OpenMainScreen()
        {
            _mainScreen.SetActive(true);
        }

        public void OpenPostScreen(string title, string username, string date, string message)
        {
            OpenScreen<PostScreen>(_postScreen, new PostScreen.PostScreenData
            {
                Title = title,
                Username = username,
                Date = date,
                Text = message
            });
        }

        public void OpenLoadingScreen()
        {
            _loadingObject = OpenScreen<LoadingScreen>(_loading, new Screen.ScreenData());
        }

        public void CloseLoadingScreen()
        {
            Destroy(_loadingObject);
        }

        public void ShowInfoPopup(string title, string message)
        {
            OpenScreen<InfoPopup>(_infoPopup, new InfoPopup.InfoPopupData()
            {
                Title = title,
                Message = message
            });
        }
        
        private GameObject OpenScreen<T>(GameObject screen, Screen.ScreenData data) where T:Screen
        {
            var window = Instantiate(screen, _canvas.transform);
            if (window.TryGetComponent<T>(out var screenComponent))
            {
                screenComponent.SetData(data);
            }
            return window;
        }
    }
}