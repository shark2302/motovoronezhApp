using DefaultNamespace.Managers;
using Utils;

namespace DefaultNamespace
{
	public class AppController : PrivateSingleton<AppController>
	{
		private RequestManager _requestManager;

		public static RequestManager RequestManager
		{
			get { return Instance._requestManager;}
			set { Instance._requestManager = value; }
		}
		
		private WindowManager _windowManager;

		public static WindowManager WindowManager
		{
			get { return Instance._windowManager;}
			set { Instance._windowManager = value; }
		}
		
	}
}