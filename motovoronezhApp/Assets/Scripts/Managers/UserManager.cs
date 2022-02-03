using Request;
using UnityEngine;

namespace DefaultNamespace.Managers
{
	public class UserManager
	{
		private const string USER_ID = "user_id";
		private const string USER_LOGIN = "user_login";
		private const string USER_PASSWORD = "user_password";
		private const string USER_TOKEN = "user_token";
		
		public static void SaveUserData(LoginRequest.LoginRequestResult data) 
		{
			PlayerPrefs.SetInt(USER_ID, data.id);
			PlayerPrefs.SetString(USER_LOGIN, data.login);
			PlayerPrefs.SetString(USER_PASSWORD, data.password);
			PlayerPrefs.SetString(USER_TOKEN, data.token);
		}

		public static int GetUserId()
		{
			return PlayerPrefs.GetInt(USER_ID);
		}
		
		public static string GetUserLogin()
		{
			return PlayerPrefs.GetString(USER_LOGIN);
		}
		
		public static string GetUserPassword()
		{
			return PlayerPrefs.GetString(USER_PASSWORD);
		}
		
		public static string GetUserToken()
		{
			return PlayerPrefs.GetString(USER_TOKEN);
		}
	}
}