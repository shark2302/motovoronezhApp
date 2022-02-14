using DefaultNamespace;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Items
{
    public class LinkItem : MonoBehaviour
    {

        private const int DEFAULT_WIDTH = 300;
        private const int DEFAULT_HEIGHT = 300;
        [SerializeField] 
        private Button _button;
        
        [SerializeField] 
        private TextMeshProUGUI _text;

        [SerializeField] 
        private Image _image;

        [SerializeField] 
        private LayoutElement _layoutElement;
        
        [SerializeField] 
        private RectTransform _rectTransform;
        
        private string _url;

        public void SetData(string url, string text)
        {
            if (text.Contains("[/img]"))
            {
                _text.enabled = false;
                _image.enabled = true;
                var imageUrl = text.Replace("[/img]]", string.Empty);
                AppController.RequestManager.LoadImage(imageUrl, texture =>
                    {
                        if (texture != null)
                        {
                            _layoutElement.minWidth= texture.width;
                            _layoutElement.minHeight = texture.height;
                            _rectTransform.sizeDelta = new Vector2(texture.width, texture.height);
                            _image.sprite = Sprite.Create((Texture2D) texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                            _button.targetGraphic = _image;
                        }
                        else
                        {
                            _layoutElement.minWidth= DEFAULT_WIDTH;
                            _layoutElement.minHeight = DEFAULT_HEIGHT;
                            _rectTransform.sizeDelta = new Vector2(DEFAULT_WIDTH, DEFAULT_HEIGHT);
                        }
                    
                    }
                );
            }
            else
            {
                _image.enabled = false;
                _text.enabled = true;
                _button.targetGraphic = _text;
                _text.SetText(text);
                
            }
            _url = url;
        }

        public void OnLinkButtonClick()
        {
            Application.OpenURL(_url);
        }
        
    }
}