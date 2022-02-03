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
		
	}
}