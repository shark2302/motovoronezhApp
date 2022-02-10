using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.Items
{
    public class ImageItem : MonoBehaviour
    {
        [SerializeField] 
        private Image _image;
        
        [SerializeField]
        private RectTransform _rectTransform;

        public void SetData(string urlForDownload)
        {
            AppController.RequestManager.LoadImage(urlForDownload, texture =>
                {
                    _rectTransform.sizeDelta = new Vector2(texture.width, texture.height);
                    _image.sprite = Sprite.Create((Texture2D) texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
                }
            );
        }
    }
}