using System;
using System.Collections;
using DefaultNamespace.Managers;
using UnityEngine;
using UnityEngine.Networking;

namespace Request
{
	public class GetPostMessageRequest : RequestBase
	{
		public struct PostMessage
		{
			public string message;
		}

		private int _postId;
		private Action<PostMessage, int> _callback;
		
		public GetPostMessageRequest(string url, int postId, Action<PostMessage, int> callback) : base(url)
		{
			_postId = postId;
			_callback = callback;
		}

		public override IEnumerator Send()
		{
			UnityWebRequest request = UnityWebRequest.Get(_url + _postId +"?jwt=" + UserManager.GetUserToken());
            
			yield return request.SendWebRequest();
			//string json = "{\"posts\":" + request.downloadHandler.text + "}";
			if (request.responseCode == 200)
			{
				PostMessage result = JsonUtility.FromJson<PostMessage>(request.downloadHandler.text);
				_callback(result, 200);
			}
			else if(request.responseCode == 401)
			{
				_callback(new PostMessage(), 401);
			}
			else
			{
				_callback(new PostMessage(), 500);
			}
		}
	}
}