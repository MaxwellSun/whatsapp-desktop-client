/*
* by Stefan Bijen aka Freakypain - stefan.bijen@gmail.com 
* by Swen Kooij aka Kirk - swenkooij@gmail.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Text.RegularExpressions;

public class ContactCollection : List<Contact>
{    
    /// <summary>
    /// Represents a collection of contacts
    /// </summary>
    public ContactCollection(string Filename)
    {
        Constructor(Filename);
    }

    /// <summary>
    /// Constructor overload, loads from contacts.xml in the current directory.
    /// </summary>
    public ContactCollection()
    {
        Constructor("contacts.xml");
    }
    
    /// <summary>
    /// Serves as internal constructor, to make correct overloads of the constructor work
    /// </summary>
    /// <param name="Filename">The file path of the XML file.</param>
    private void Constructor(string Filename)
    {
        // Check if the file exists, if not throw an exception
        if (System.IO.File.Exists(Filename) == false)
        {
            ToFile();
        }

        // create an xml document object.
        XmlDocument xmlDoc = new XmlDocument();

        // Load the XML from the specified file.
        xmlDoc.Load(Filename);

        // Get all 'contact' elements
        XmlNodeList XmlContacts = xmlDoc.GetElementsByTagName("contact");

        // Loop through nodes & save them to list
        foreach (XmlNode Node in XmlContacts)
        {
            // Create new instance of Contact class
            Contact Con = new Contact(Node.ChildNodes[1].InnerText, Node.ChildNodes[0].InnerText, Node.Attributes["name"].InnerText);
            this.Add(Con);
        }
    }

    /// <summary>
    /// Ooutputs all contacts to a file
    /// </summary>
    /// <param name="Filename">The name/location of the file the XML should be written to.</param>
    public void ToFile(string Filename)
    {
        List<Contact> AllContacts = this;
        XmlTextWriter writer = new XmlTextWriter(Filename, null);

        //  Set indenting so that its easier to read XML when open in Notepad.
        writer.Formatting = Formatting.Indented;

        //  This will output the XML declaration
        writer.WriteStartDocument();

        //  Now let's add root element.
        writer.WriteStartElement("contacts");

        foreach (Contact Cont in AllContacts)
        {
            //  Let's add a node
            writer.WriteStartElement("contact");

            //  We can also add an attribute to "person" node
            writer.WriteAttributeString("name", Cont.Name);

            //  If you want to add children nodes to "person", here is where you do it.               
            writer.WriteElementString("country_code", Cont.CountryCode);
            writer.WriteElementString("phonenumber", Cont.PhoneNumber);

            //  Close "person" node
            writer.WriteEndElement();
        }

        //  Close "contact" root element
        writer.WriteEndElement();
        writer.WriteEndDocument();

        //  This will write the above elements to the file itself
        writer.Close();
    }

    /// <summary>
    /// Overload, writes to contact.xml
    /// </summary>
    public void ToFile()
    {
        ToFile("contacts.xml");
    }
}

