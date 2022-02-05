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

		private MainScreenTabData _activePanel;

		private void OnEnable()
		{
			_activePanel = _tabDatas[0];
			_activePanel.Panel.SetActive(true);
			_activePanel.ButtonImage.transform.localScale = new Vector3(1.3f, 1.3f);
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
				_activePanel.Panel.SetActive(false);
				_activePanel.ButtonImage.transform.localScale = new Vector3(1, 1);
				_activePanel = data;
				_activePanel.Panel.SetActive(true);
				_activePanel.ButtonImage.transform.localScale = new Vector3(1.3f, 1.3f);
			}
		}
		
	}
}