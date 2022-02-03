using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Screens.Popups
{
    public class InfoPopup : Screen
    {
        [SerializeField]
        private Text _title;

        [SerializeField] 
        private Text _message;

        public class InfoPopupData : ScreenData
        {
            public string Title;
            public string Message;
        }
        
        public override void SetData(ScreenData data)
        {
            if (data is InfoPopupData popupData)
            {
                _title.text = popupData.Title;
                _message.text = popupData.Message;
            }
            else
            {
                Debug.LogError("[InfoPopup] Not supported data was received");
            }
          
        }

        public void OnOkButtonClicked()
        {
            Destroy(gameObject);
        }
    }
}