/*
 * by Swen Kooij aka Kirk - swenkooij@gmail.com 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// A helper class for the WhatsApp protocol
/// </summary>
public class AccountInfo
{
    public string Status { get; private set; }
    public string Kind { get; private set; }
    public string Creation { get; private set; }
    public string Expiration { get; private set; }

    /// <summary>
    /// Default class constructor
    /// </summary>
    /// <param name="status">The status of the user</param>
    /// <param name="kind">Kind of user</param>
    /// <param name="creation">The creation moment.</param>
    /// <param name="expiration">The expiration moment.</param>
    public AccountInfo(string status, string kind, string creation, string expiration)
    {
        this.Status = status;
        this.Kind = kind;
        this.Creation = creation;
        this.Expiration = expiration;
    }

    /// <summary>
    /// Returns information about the account in a string format.
    /// </summary>
    /// <returns>information about the account in a string format.</returns>
    public new string ToString()
    {
        return string.Format("Status: {0}, Kind: {1}, Creation: {2}, Expiration: {3}", this.Status, this.Kind, this.Creation, this.Expiration);
    }
}

