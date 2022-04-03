using System;
using System.Collections;
using DefaultNamespace.Managers;
using UnityEngine;
using UnityEngine.Networking;

namespace Request
{
	public class ShortPostInfoRequest : RequestBase
	{
		[System.Serializable]
		public struct ShortInfoPostData
		{
			public int postId;
			public string title;
			public UserResult user;
			public int data;
		}

		[System.Serializable]
		public struct ShortInfoPostRequestResult
		{
			public ShortInfoPostData[] posts;
		}
		
		private int _fromIndex;
		private Action<ShortInfoPostRequestResult, int> _callback;
		
		public ShortPostInfoRequest(string url, int fromIndex, Action<ShortInfoPostRequestResult, int> callback) : base(url)
		{
			_fromIndex = fromIndex;
			_callback = callback;
		}

		public override IEnumerator Send()
		{
			UnityWebRequest request = UnityWebRequest.Get(_url+_fromIndex +"?jwt=" + UserManager.GetUserToken());
            
			yield return request.SendWebRequest();
			Debug.Log(request.downloadHandler.text);
			string json = "{\"posts\":" + request.downloadHandler.text + "}";
			if (request.responseCode == 200)
			{
				ShortInfoPostRequestResult result = JsonUtility.FromJson<ShortInfoPostRequestResult>(json);
				foreach (var p in result.posts)
				{
					Debug.Log(p.title + " " + p.user.username);
				}
				_callback(result, 200);
			}
			else if(request.responseCode == 401)
			{
				_callback(new ShortInfoPostRequestResult(), 401);
			}
			else
			{
				_callback(new ShortInfoPostRequestResult(), 500);
			}
		}
	}
}