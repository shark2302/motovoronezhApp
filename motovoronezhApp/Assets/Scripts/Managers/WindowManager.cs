using System;
using DefaultNamespace.Screens.Popups;
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
        
        [Header("Popups")] 
        [SerializeField] 
        private GameObject _infoPopup;


        public void Awake()
        {
            AppController.WindowManager = this;
        }

        public void OpenLoginWindow()
        {
            OpenScreen<LoginScreen>(_loginScreen, new Screen.ScreenData());
        }

        public void ShowInfoPopup(string title, string message)
        {
            OpenScreen<InfoPopup>(_infoPopup, new InfoPopup.InfoPopupData()
            {
                Title = title,
                Message = message
            });
        }

        private void OpenScreen<T>(GameObject screen, Screen.ScreenData data) where T:Screen
        {
            var window = Instantiate(screen, _canvas.transform);
            if (window.TryGetComponent<T>(out var screenComponent))
            {
                screenComponent.SetData(data);
            }
        }
    }
}