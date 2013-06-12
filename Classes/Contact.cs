/*
 * by Stefan Bijen aka Freakypain - stefan.bijen@gmail.com 
 * by Swen Kooij aka Kirk - swenkooij@gmail.com
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Represents a contact
/// </summary>
public class Contact
{
    /// <summary>
    /// The phone number belonging to this account.
    /// </summary>
    public string PhoneNumber { get; set; }

    /// <summary>
    /// The country code
    /// </summary>
    public string CountryCode { get; set; }

    /// <summary>
    /// The name of the contact
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Initiliazes the class.
    /// </summary>
    /// <param name="_PhoneNumber">Phonenumber without country code</param>
    /// <param name="_CountryCode">The country code in + format, eg, +31</param>
    /// <param name="_Name">The name of the contact person</param>
    public Contact(string _PhoneNumber, string _CountryCode, string _Name)
    {
        // Make global
        PhoneNumber = _PhoneNumber;
        CountryCode = _CountryCode;
        Name = _Name;

        // Checks
        if (isValidPhoneNumber() == false) throw new Exception("Phone number is invalid format. Make sure it's without the country code.");
        if (CountryCode.Contains("+") == false) throw new Exception("Country code is invalid.");
    }

    /// <summary>
    /// Checks if the phone number is valid.
    /// </summary>
    /// <param name="_Phonenumber">The full phone umber, including country code.</param>     
    private bool isValidPhoneNumber()
    {
        if (PhoneNumber.Contains("+")) 
            return false;
        return true;
    }
}
