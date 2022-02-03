using System;
using System.Collections;
using UnityEngine.Networking;

namespace Request
{
    public abstract class RequestBase
    {
        protected string _url;

        public RequestBase(string url)
        {
            _url = url;
        }

        public abstract IEnumerator Send();

    }
}