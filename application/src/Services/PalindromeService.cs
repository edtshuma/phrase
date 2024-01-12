using Phrase.Entities;
using Phrase.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phrase.Services
{
    public interface IPalindromeService
    {
         bool IsPalindrome(string text);
    }

    public class PalindromeService :  IPalindromeService
    {

        public bool IsPalindrome(string text)
        {
           return text.SequenceEqual(text.Reverse());
        }

        
    }


}