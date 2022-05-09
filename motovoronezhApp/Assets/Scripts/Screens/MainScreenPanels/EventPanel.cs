using System;
using System.Collections.Generic;
using DefaultNamespace;
using Request;
using Screens.Items;
using UnityEngine;

namespace Screens.MainScreenPanels
{
	public class EventPanel : MonoBehaviour
	{
		[SerializeField] 
		private GameObject _content;

		[SerializeField] 
		private GameObject _linkPrefab;

		private List<GetAllEvents.EventData> _cachedEvents;

		private void Awake()
		{
			_cachedEvents = new List<GetAllEvents.EventData>();
		}

		public void OnEnable()
		{
			if (_cachedEvents.Count == 0)
			{
				//AppController.WindowManager.OpenLoadingScreen();
				AppController.RequestManager.GetAllEventsRequest((result
					, responcode) =>
				{
					//AppController.WindowManager.CloseLoadingScreen();
					switch (responcode)
					{
						case 200:
							CreateEvents(result.events);
							break;
					}
				
				});
			}
			else
			{
				CreateEvents(_cachedEvents.ToArray());
			}
			
		}

		private void CreateEvents(GetAllEvents.EventData[] events)
		{
			foreach (var ev in events)
			{
				_cachedEvents.Add(ev);
				if (Instantiate(_linkPrefab, _content.transform).TryGetComponent<LinkItem>(out var linkItem))
				{
					var date = DateTimeOffset.FromUnixTimeSeconds(ev.posted).UtcDateTime;
					
					linkItem.SetData(String.Empty, ev.title, () => AppController.WindowManager.OpenPostScreen(ev.title, ev.poster, date.ToString(), ev.message));
				}
			}
		}
		
	}
}