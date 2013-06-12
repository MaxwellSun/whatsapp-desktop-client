/*
 * by Swen Kooij aka Kirk - swenkooij@gmail.com 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Represents a WhatsApp account
/// </summary>
public class WhatsappAccount
{
    /// <summary>
    /// The country code
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// The phone number belonging to this account.
    /// </summary>
    public string Phonenumber { get; set; }

    /// <summary>
    /// The phone numbers with the country code
    /// </summary>
    public string FullPhonenumber { get; set; }

    /// <summary>
    /// The password that belongs to this account
    /// </summary>
    public string Password { get; set; }

    /// <summary>
    /// The nickname, can be changed every time
    /// </summary>
    public string Nickname { get; set; }

    /// <summary>
    /// Default class constructor
    /// </summary>
    /// <param name="_Phonenumber">The full phonenumber, including country code.</param>
    /// <param name="_Password">The password assigned to the phone number.</param>
    public WhatsappAccount(string _CountryCode, string _Phonenumber, string _Password, string _Nickname)
    {
        CountryCode = _CountryCode;
        FullPhonenumber = CountryCode + _Phonenumber.Replace("0", "");
        Phonenumber = _Phonenumber;
        Password = _Password;
        Nickname = _Nickname;
    }

    /// <summary>
    /// Returns the full jabber id
    /// </summary>
    /// <returns>Jabber ID (Jid)</returns>
    public string GetFullJid()
    {
        return string.Format("{0}@{1}", FullPhonenumber, WhatsConstants.WhatsAppServer);
    }
}
