using System;
using Screens.Items;
using UnityEngine;

namespace Screens.MainScreenPanels
{
	public class NewsPanel : MonoBehaviour
	{
		[SerializeField]
		private GameObject _content;

		[SerializeField] 
		private GameObject _newPrefab;

		[SerializeField] 
		private GameObject _separator;
		
		private void OnEnable()
		{
			var sep =  Instantiate(_separator, _content.transform);
			var item = Instantiate(_newPrefab, _content.transform);
			item.GetComponent<NewItem>().SetData("asasd", "17.02.2020", "sdgadgfsoaisdgfjoafigjoiasjgoiasjdgfoiajdfsg");
			var sep1 =  Instantiate(_separator, _content.transform);
			var item1 = Instantiate(_newPrefab, _content.transform);
			item1.GetComponent<NewItem>().SetData("dfasdfas", "17.03.2020", "aaaaaassdfasdgadgfsoaisdgfjoafigjoiasjgoiasjdgfoiajdfsg");
			var sep3 =  Instantiate(_separator, _content.transform);
			for (int i = 0; i < 20; i++)
			{
				var item2 = Instantiate(_newPrefab, _content.transform);
				item2.GetComponent<NewItem>().SetData("dfasdfas", "17.03.2020", "aaaaaassdfasdgadgfsoaisdgfjoafigjoiasjgoiasjdgfoiajdfsg");
				var sep4 =  Instantiate(_separator, _content.transform);
			}
		}
	}
}