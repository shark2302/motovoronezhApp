using System;
using UnityEngine;

namespace DefaultNamespace.Screens
{
	public class LoadingScreen : Screen
	{
		[SerializeField] 
		private GameObject _image;

		private Vector3 _rotationEuler;
		private void Update()
		{
			_rotationEuler += Vector3.forward * (30 * Time.deltaTime);
			_image.transform.rotation = Quaternion.Euler(_rotationEuler);
		}
	}
}