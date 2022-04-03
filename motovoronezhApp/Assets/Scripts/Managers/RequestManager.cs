using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Request;
using UnityEngine;
using UnityEngine.Networking;

public class RequestManager : MonoBehaviour
{

    [SerializeField] 
    private string _url;

    public void Awake()
    {
        AppController.RequestManager = this;
    }

    public void SendLoginRequest(string login, string password, Action<LoginRequest.LoginRequestResult, int> callback)
    {
        StartCoroutine(new LoginRequest(_url + "login", login, password, callback).Send());
    }
    
    
    public void SendNewsRequest(int fromIndex, Action<PostsRequest.NewsRequestResult, int> callback)
    {
        StartCoroutine(new PostsRequest(_url + "get_all_news/", fromIndex, callback).Send());
    }
    
    public void SendDalnoboyPostsRequest(int fromIndex, Action<PostsRequest.NewsRequestResult, int> callback)
    {
        StartCoroutine(new PostsRequest(_url + "get_all_dalnoboy/", fromIndex, callback).Send());
    }

    public void SendShortInfoPostsRequest(int fromIndex,
        Action<ShortPostInfoRequest.ShortInfoPostRequestResult, int> callback)
    {
        StartCoroutine(new ShortPostInfoRequest(_url + "get_all_short_posts_dalnoboy/", fromIndex, callback).Send());
    }

    
    public void LoadImage(string url, Action<Texture> callback)
    {
        StartCoroutine(LoadImageRoutine(url, callback));
    }

    private IEnumerator LoadImageRoutine(string url, Action<Texture> callback)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        
        if (www.isNetworkError || www.isHttpError)
        {
            callback(null);
        }
        else {
            Texture texture= ((DownloadHandlerTexture)www.downloadHandler).texture;
            callback(texture);
        }
        
        
    }
    
}
