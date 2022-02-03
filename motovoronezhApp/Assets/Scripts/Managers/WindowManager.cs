using System;
using DefaultNamespace.Screens.Popups;
using UnityEngine;

namespace DefaultNamespace.Managers
{
    public class WindowManager : MonoBehaviour
    {
        [SerializeField]
        private Canvas _canvas;

        [Header("Windows")] 
        [SerializeField] 
        private GameObject _infoPopup;


        private void Start()
        {
            AppController.WindowManager = this;
        }

        public void ShowInfoPopup(string title, string message)
        {
            var popup = Instantiate(_infoPopup, _canvas.transform);
            if (popup.TryGetComponent<InfoPopup>(out var infoPopup))
            {
                infoPopup.SetData(title, message);
            }
        }
    }
}