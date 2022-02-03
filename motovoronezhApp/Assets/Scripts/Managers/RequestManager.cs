using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using Request;
using UnityEngine;

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
}
