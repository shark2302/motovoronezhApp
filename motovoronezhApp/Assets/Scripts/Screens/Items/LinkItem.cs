using TMPro;
using UnityEngine;

namespace Screens.Items
{
    public class LinkItem : MonoBehaviour
    {
        [SerializeField] 
        private TextMeshProUGUI _text;
        
        private string _url;

        public void SetData(string url, string text)
        {
            _text.SetText(text);
            _url = url;
        }

        public void OnLinkButtonClick()
        {
            Application.OpenURL(_url);
        }
        
    }
}