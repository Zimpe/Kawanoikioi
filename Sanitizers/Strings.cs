using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Kawanoikioi.Sanitizers
{
    public class Strings
    {

        public string MakeUrlFriendly(string str, bool ignorePunctiontion = false)
        {
            char[] stringFrags = str.ToCharArray();
            int currentChar = 0;

            while (stringFrags.Count() != currentChar)
            {
                if (char.IsWhiteSpace(stringFrags[currentChar]))
                {
                    stringFrags[currentChar] = '-';
                }
                if (char.IsPunctuation(stringFrags[currentChar]) & !ignorePunctiontion)
                {
                    stringFrags[currentChar] = '-';
                }
                if (char.IsLower(stringFrags[currentChar]) & currentChar == 0)
                {
                    stringFrags[currentChar] = char.ToUpper(stringFrags[currentChar]);
                }

                currentChar++;
            }

            return new string(stringFrags);
        }

        //public string CreateLinksFromUrl(string text, bool useAspNetControls = true)
        //{
        //    string[] words = new string[1000];
        //    char[] characters = text.ToCharArray();
        //    int currentChar = 0;
        //    int currentWord = 0;

        //    while (currentChar != text.Length)
        //    {
        //        char[] word = new char[20];
        //        int current = 0;
        //        if (!char.IsWhiteSpace(characters[currentChar]) & !char.IsPunctuation(characters[currentChar]))
        //        {
        //            word[current] = characters[currentChar];
        //            current++;
        //            currentChar++;
        //        }
        //        else
        //        {
        //            words[currentWord] = new string(word);
        //            current = 0;
        //            currentWord++;
        //            break;
        //        }
        //    }
        //    currentWord = 0;
        //    while (words.Count() != currentWord)
        //    {
        //        try
        //        {
        //            Uri url = new Uri(words[currentWord]);
        //        }
        //        finally
        //        {
        //            string currentString = words[currentWord];
        //            if (useAspNetControls)
        //            {
        //                words[currentWord].Replace(currentString, "<asp:HyperLink ID=\"Link\" runat=\"server\" NavigateUrl=\"" + currentString + "\" Text=\"" + currentString + "\" />");
        //            }
        //            else
        //            {
        //                words[currentWord].Replace(currentString, "<a href=\"" + currentString + "\" alt=\"" + currentString + "\">" + currentString + "</a>");
        //            }
        //        }
        //    }

        //    return words.ToString();
        //}
    }
}