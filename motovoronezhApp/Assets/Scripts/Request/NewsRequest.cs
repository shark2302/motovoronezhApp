using System;
using System.Collections;
using System.Text;
using DefaultNamespace.Managers;
using UnityEngine;
using UnityEngine.Networking;

namespace Request
{
    public class NewsRequest : RequestBase
    {

        [System.Serializable]
        public struct NewsRequestResult
        {
            public PostData[] posts;
        }
        

        private int _fromIndex;
        private Action<NewsRequestResult, int> _callback;
        
        public NewsRequest(string url, int fromIndex,Action<NewsRequestResult, int> callback ) : base(url)
        {
            _fromIndex = fromIndex;
            _callback = callback;
        }

        public override IEnumerator Send()
        {

            UnityWebRequest request = UnityWebRequest.Get(_url+_fromIndex);
            

            request.SetRequestHeader("Authorization", "Bearer " + UserManager.GetUserToken());

            yield return request.SendWebRequest();
            Debug.Log(request.downloadHandler.text);
            string json = "{\"posts\":" + request.downloadHandler.text + "}";
            if (request.responseCode == 200)
            {
                NewsRequestResult result = JsonUtility.FromJson<NewsRequestResult>(json);
            
                _callback(result, 200);
            }
            else if(request.responseCode == 401)
            {
                _callback(new NewsRequestResult(), 401);
            }
            else
            {
                _callback(new NewsRequestResult(), 500);
            }
        }
    }
}