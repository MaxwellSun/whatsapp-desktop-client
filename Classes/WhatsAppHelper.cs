/*
 * by Swen Kooij aka Kirk - swenkooij@gmail.com 
 * by Maarten van der Heijden aka LivernuX - maarten.heijden97@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

/// <summary>
/// A class with some functions to verify accounts, register accounts
/// </summary>
class WhatsAppHelper
{
    /// <summary>
    /// Enum that can be used to identify the Operating System of the user's device.
    /// </summary>
    public enum DeviceOS { iOS, Other };

    /// <summary>
    /// Generates a password based on the IMEI or Wifi Mac adress
    /// </summary>
    /// <param name="ImeiMac">The IMEI number or the Wifi Mac Adress</param>
    /// <param name="OS">The mobile operating system the account was registered on.</param>
    /// <returns>The generated password</returns>
    public string generatePassword(string ImeiMac, DeviceOS OS)
    {
        if (OS == DeviceOS.iOS)
        {
            return md5(ImeiMac.Trim() + ImeiMac.Trim());
        }
        else
        {
            string Reversed = new string(ImeiMac.Trim().ToCharArray().Reverse().ToArray());
            return md5(Reversed);
        }
    }

    /// <summary>
    /// Checks if the account really exists
    /// </summary>
    /// <param name="CountryCode">The country code with a + eg: +31</param>
    /// <param name="Phonenumber">The phone number without the country code eg: 0624115307</param>
    /// <param name="Password">The password of the whatsapp account</param>
    /// <returns>True on existance and false when non-existent</returns>
    public bool verifyAccount(string CountryCode, string Phonenumber, string Password)
    {
        Phonenumber = Phonenumber != "" ? Phonenumber : "Empty";
       
        // Get page
        string Html = new DirtyHttp("https://r.whatsapp.net/v1/exist.php?cc=" + CountryCode.Replace("+", "") + "&in=" + Phonenumber + "&udid=" + Password).doRequest();

        // Verify
        if (Html.Contains("<response status=\"ok\"")) // hier dus..
            return true;
        else
            return false;
    }

    /// <summary>
    /// Retrieves the version number of the latest WhatsApp mobile app.
    /// </summary>
    /// <returns>The version number in a string.</returns>
    public string getVersion()
    {
        string Html = new DirtyHttp("http://www.whatsapp.com/android/").doRequest();
        string[] SplitA = Html.Split(new[] { "<p class=\"version\">" }, StringSplitOptions.None);
        return SplitA[1].Split(new[] { "</p>" }, StringSplitOptions.None)[0].Trim().Replace("Version ", "");
    }

    /// <summary>
    /// Generates a MD5 hash from a string
    /// </summary>
    /// <param name="input">The string that needs to be hashed</param>
    /// <returns>The MD5 hash in a string.</returns>
    public string md5(string input)
    {
        MD5 md5 = MD5.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hash = md5.ComputeHash(inputBytes);
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString().ToLower();
    }
}

