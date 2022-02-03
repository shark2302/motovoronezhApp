using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Managers;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
	[SerializeField] 
	private String SignUpURL;
	
	[SerializeField] 
	private InputField _loginField;
	
	[SerializeField] 
	private InputField _passwordField;

	public void OnSignInButtonClicked()
	{
		var login = _loginField.text;
		var password = _passwordField.text;
		Debug.Log(login);
		Debug.Log(password);
		AppController.RequestManager.SendLoginRequest(login, password, result => {UserManager.SaveUserData(result);} );
	}

	public void OnSignUpButtonClicked()
	{
		Application.OpenURL(SignUpURL);
	}
}
