using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : MonoBehaviour
{
	
	[SerializeField]
	private RequestManager _requestManager;
	
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
		_requestManager.SendLoginRequest(login, password, result => { Debug.Log(result.token);} );
	}

	public void OnSignUpButtonClicked()
	{
		Application.OpenURL(SignUpURL);
	}
}
