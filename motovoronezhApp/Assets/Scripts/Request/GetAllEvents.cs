using System;
using System.Collections;
using DefaultNamespace.Managers;
using UnityEngine;
using UnityEngine.Networking;

namespace Request
{
	public class GetAllEvents : RequestBase
	{

		[Serializable]
		public struct EventData
		{
			public int post_id;
			public string title;
			public string message;
			public string poster;
			public int posted;
		}

		public struct GetAllEventsResult
		{
			public EventData[] events;
		}
		
		private Action<GetAllEventsResult, int> _callback;
		
		public GetAllEvents(string url, Action<GetAllEventsResult, int> callback) : base(url)
		{
			_callback = callback;
		}

		public override IEnumerator Send()
		{
			UnityWebRequest request = UnityWebRequest.Get(_url + "?jwt=" + UserManager.GetUserToken());
            
			yield return request.SendWebRequest();
			Debug.Log(request.downloadHandler.text);
			string json = "{\"events\":" + request.downloadHandler.text + "}";
			if (request.responseCode == 200)
			{
				GetAllEventsResult result = JsonUtility.FromJson<GetAllEventsResult>(json);
            
				_callback(result, 200);
			}
			else if(request.responseCode == 401)
			{
				_callback(new GetAllEventsResult(), 401);
			}
			else
			{
				_callback(new GetAllEventsResult(), 500);
			}
		}
	}
}