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

    private void Start()
    {
        AppController.RequestManager = this;
    }

    public void SendLoginRequest(string login, string password, Action<LoginRequest.LoginRequestResult> callback)
    {
        StartCoroutine(new LoginRequest(_url + "login", login, password, callback).Send());
    }
}
