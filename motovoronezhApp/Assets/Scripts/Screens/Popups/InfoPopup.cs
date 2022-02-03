using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Screens.Popups
{
    public class InfoPopup : MonoBehaviour
    {
        [SerializeField]
        private Text _title;

        [SerializeField] 
        private Text _message;
        
        public void SetData(string title, string message)
        {
            _title.text = title;
            _message.text = message;
        }

        public void OnOkButtonClicked()
        {
            Destroy(gameObject);
        }
    }
}