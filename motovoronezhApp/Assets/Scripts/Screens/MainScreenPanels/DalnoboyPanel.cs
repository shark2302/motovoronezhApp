using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.UI;

namespace Screens.MainScreenPanels
{
    public class DalnoboyPanel: NewsPanel
    {
        protected override void GetPostsFromServer(int fromIndex)
        {
            AppController.WindowManager.OpenLoadingScreen();
            AppController.RequestManager.SendDalnoboyPostsRequest(fromIndex, (result
                , responcode) =>
            {
                AppController.WindowManager.CloseLoadingScreen();
                switch (responcode)
                {
                    case 200:
                        CreateNews(result);
                        break;
                }
				
            });
        }
    }
}