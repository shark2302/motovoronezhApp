using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Request
{
	public class SendImageRequest : RequestBase
	{
        [System.Serializable]
        public struct SendImageRequestStruct
        {
            public Texture2D image;
        }
        
        [Serializable]
        public struct ImageData
        {
            public string url;
        }

        [Serializable]
        public struct RequestData
        {
            public string id;
            public ImageData image;
        }

        [Serializable]
        public struct ResponseResult
        {
            public RequestData data;
        }

        private Texture2D _image;
        private Action<RequestData, int> _callback;

        public SendImageRequest(string url, Texture2D image, Action<RequestData, int> callback) : base(url)
        {
            _image = image;
            _callback = callback;
        }


        public override IEnumerator Send()
        {
            
            byte[] bytes = _image.EncodeToPNG(); //Can also encode to jpg, just make sure to change the file extensions down below
            
            var form = new WWWForm();
            form.AddBinaryData("image", bytes);
 
            //POST the screenshot to GameSparks
            WWW w = new WWW(_url, form); 
            yield return w;
 
            
            if (w.error != null)
            {
                Debug.Log(w.error);
                _callback(new RequestData(), 500);
            }
            else
            {
                ResponseResult result = JsonUtility.FromJson<ResponseResult>(w.text);
                _callback(result.data, 200);
            }
        }
	}
}