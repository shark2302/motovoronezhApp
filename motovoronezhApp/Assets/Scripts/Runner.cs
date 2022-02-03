using System;
using UnityEngine;

namespace DefaultNamespace
{
	public class Runner : MonoBehaviour
	{
		private void Awake()
		{
			AppController.InitializedWindowManager += OnInitializedWindowManager;
		}
		
		public void OnInitializedWindowManager()
		{
			AppController.WindowManager.OpenLoginWindow();
		}
		
		private void OnDisable()
		{
			AppController.InitializedWindowManager -= OnInitializedWindowManager;
		}

		
	}
}