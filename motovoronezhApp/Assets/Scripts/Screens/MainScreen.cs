using System;
using UnityEngine;

namespace Windows
{
	public class MainScreen : Screen
	{
		[Serializable]
		public class MainScreenTabData
		{
			public GameObject Button;
			public GameObject Panel;
			public GameObject ButtonImage;
		}

		[Header("Tabs")]
		[SerializeField]
		private MainScreenTabData[] _tabDatas;

		private GameObject _activePanel;

		private void OnEnable()
		{
			_activePanel = _tabDatas[0].Panel;
			for (int i = 1; i < _tabDatas.Length; i++)
			{
				_tabDatas[i].Panel.SetActive(false);
			}
		}

		public void OnBottomPanelButtonClick(GameObject button)
		{
			var data = Array.Find(_tabDatas, tabData => tabData.Button == button);
			if (data != null)
			{
				_activePanel.SetActive(false);
				_activePanel = data.Panel;
				_activePanel.SetActive(true);
			}
		}
		
	}
}