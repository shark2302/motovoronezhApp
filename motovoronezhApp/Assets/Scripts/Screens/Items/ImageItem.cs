using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Items
{
    public class ImageItem : MonoBehaviour
    {

        private const int DEFAULT_WIDTH = 300;
        private const int DEFAULT_HEIGHT = 300;
        [SerializeField] 
        private Image _image;
        
        [SerializeField]
        private RectTransform _rectTransform;

        [SerializeField] 
        private LayoutElement _layoutElement;
       
        public void SetData(string urlForDownload)
        {
            AppController.RequestManager.LoadImage(urlForDownload, texture =>
                {
                    if (texture != null)
                    {
                        _layoutElement.minWidth= texture.width;
                        _layoutElement.minHeight = texture.height;
                        _rectTransform.sizeDelta = new Vector2(texture.width, texture.height);
                        _image.sprite = Sprite.Create((Texture2D) texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
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
    }
}