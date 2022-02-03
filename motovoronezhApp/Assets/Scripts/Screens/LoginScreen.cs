using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.Managers;
using UnityEngine;
using UnityEngine.UI;

public class LoginScreen : Screen
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
		
		if (login != String.Empty && password != String.Empty)
		{
			AppController.RequestManager.SendLoginRequest(login, password, (result, code) =>
			{
				switch (code)
				{
					case 200:
						UserManager.SaveUserData(result);
						break;
					case 401:
						AppController.WindowManager.ShowInfoPopup("Неправильные данные", "Вы ввели неверный пароль или логин. Попробуйте еще раз");
						break;
					default:
						AppController.WindowManager.ShowInfoPopup("Непредвиденная ошибка", "Проверьте соединение с интернетом");
						break;
				}
			});
		}
		else
		{
			AppController.WindowManager.ShowInfoPopup("Нет данных", "Вы ничего не ввели");
		}
	}

	public void OnSignUpButtonClicked()
	{
		Application.OpenURL(SignUpURL);
	}
}
