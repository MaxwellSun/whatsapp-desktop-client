/*
 * by Swen Kooij aka Kirk - swenkooij@gmail.com 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

// test change

/// <summary>
/// Provides a dirty but simple-to-use wrapper for the HttpWebRequest classes.
/// </summary>
class DirtyHttp
{
    /// <summary>
    /// The URL the request should be made at.
    /// </summary>
    public string Url;

    /// <summary>
    /// The timeout value in mili-seconds.
    /// </summary>
    public int Timeout;

    /// <summary>
    /// Provides an interface for selected the HTTP method.
    /// </summary>
    public enum HttpMethod { GET, POST };

    /// <summary>
    /// Holds what HTTP method should be used.
    /// </summary>
    public HttpMethod Method;

    /// <summary>
    /// Holds the default Whatsapp useragent string
    /// </summary>
    public string Useragent = "WhatsApp/2.6.7 iPhone_OS/6.0.1 Device/Unknown(iPhone4,1)";

    /// <summary>
    /// Class constructor, initializes the class.
    /// </summary>
    /// <param name="_Url">The URL the request should be made at.</param>
    /// <param name="_Timeout">The timeout value in mili-seconds.</param>
    /// <param name="_Method">The HTTP method that should be used.</param>
    public DirtyHttp(string _Url, int _Timeout, HttpMethod _Method)
    {
        Url = _Url;
        Timeout = _Timeout;
        Method = _Method;
    }

    /// <summary>
    /// Class constructor, initializes the class. This is an overload for the default class constructor.
    /// Uses HTTP GET with a timeout value of 30000 mili-seconds.
    /// </summary>
    /// <param name="_Url"></param>
    public DirtyHttp(string _Url)
    {
        Url = _Url;
        Timeout = 30000;
        Method = HttpMethod.GET;
    }

    /// <summary>
    /// Executes the HTTP request.
    /// </summary>
    /// <returns>The body of the HTTP response.</returns>
    public string doRequest()
    {
        if (Method == HttpMethod.GET)
        {
            HttpWebRequest Request = (HttpWebRequest)WebRequest.Create(Url);
            Request.Timeout = Timeout;
            Request.Method = Method.ToString();
            
            HttpWebResponse Response = (HttpWebResponse)Request.GetResponse();
            return new StreamReader(Response.GetResponseStream()).ReadToEnd();
        }
        else throw new NotImplementedException();
    }
}

