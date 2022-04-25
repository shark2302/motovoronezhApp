using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Screens
{
	public class PostEditScreen : Screen
	{
		[SerializeField] 
		private Image _image;

		[SerializeField]
		private Image _image1;


		public void OnLoadImageButtonClick()
		{
			PickImage(1000);
		}
		
		
		private void PickImage( int maxSize )
		{
			NativeGallery.GetImageFromGallery( ( path ) =>
			{
				Debug.Log( "Image path: " + path );
				if( path != null )
				{
					// Create Texture from selected image
					Texture2D texture = NativeGallery.LoadImageAtPath( path, maxSize );
					if( texture == null )
					{
						Debug.Log( "Couldn't load texture from " + path );
						return;
					}

					_image.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height),
						new Vector2(0.5f, 0.5f), 100.0f);
					AppController.RequestManager.SendImageRequest(texture, (data, i) =>
					{
						AppController.RequestManager.LoadImage(data.image.url, texture1 =>
						{
							_image1.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height),
								new Vector2(0.5f, 0.5f), 100.0f);
						});
					});

				}
			} , mime: "/");
			
		}
	}
}