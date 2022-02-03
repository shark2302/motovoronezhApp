using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Request
{
    public class LoginRequest : RequestBase
    {
        [System.Serializable]
        public struct LoginRequestStruct
        {
            public string login;
            public string password;
        }

        [Serializable]
        public struct LoginRequestResult
        {
            public int id;
            public string login;
            public string password;
            public string token;
        }

        private string _login;
        private string _password;
        private Action<LoginRequestResult, int> _callback;

        public LoginRequest(string url, string login, string password, Action<LoginRequestResult, int> callback) : base(url)
        {
            _login = login;
            _password = password;
            _callback = callback;
        }


        public override IEnumerator Send()
        {
            Debug.Log("[LoginRequest] Sending...");
            WWWForm formData = new WWWForm();

            LoginRequestStruct postData = new LoginRequestStruct()
            {
                login = _login,
                password = _password
            };

            string json = JsonUtility.ToJson(postData);
            
            UnityWebRequest request = UnityWebRequest.Post(_url, formData);

            byte[] postBytes = Encoding.UTF8.GetBytes(json);

            UploadHandler uploadHandler = new UploadHandlerRaw(postBytes);
            
            request.uploadHandler = uploadHandler;
            
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();
            if (request.responseCode == 200)
            {
                Debug.Log("[Login Request]:"  + request.downloadHandler.text);
                LoginRequestResult result = JsonUtility.FromJson<LoginRequestResult>(request.downloadHandler.text);
            
                _callback(result, 200);
            }
            else if(request.responseCode == 401)
            {
                _callback(new LoginRequestResult(), 401);
            }
            else
            {
                _callback(new LoginRequestResult(), 500);
            }
        }
    }
}