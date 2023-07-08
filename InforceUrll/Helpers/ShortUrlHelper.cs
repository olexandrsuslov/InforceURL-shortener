using System;
using System.Linq;
using System.Text;

namespace InforceUrll.Helpers
{
    public class ShortUrlHelper
    {

        private const string Alphabet = "23456789bcdfghjkmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ-_";
        private static readonly int Base = Alphabet.Length;

        // public static string Encode(int num)
        // {
        //     var sb = new StringBuilder();
        //     while (num > 0)
        //     {
        //         sb.Insert(0, Alphabet.ElementAt(num % Base));
        //         num = num / Base;
        //     }
        //     return sb.ToString();
        // }
        //
        // public static int Decode(string str)
        // {
        //     var num = 0;
        //     for (var i = 0; i < str.Length; i++)
        //     {
        //         num = num * Base + Alphabet.IndexOf(str.ElementAt(i));
        //     }
        //     return num;
        // }
        
        public static string Encode(int n)
        {
            // Map to store 62 possible characters 
            char []map = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray(); 
      
            string shorturl = "";  
       
            // Convert given integer id to a base 62 number 
            while (n > 0) 
            {
                shorturl+=(map[n % 62]);
                n = n / 62; 
            } 
      
            // Reverse shortURL to complete base conversion 
            return reverse(shorturl); 
        }
        
        static String reverse(String input) {
            char[] a = input.ToCharArray();
            int l, r = a.Length - 1;
            for (l = 0; l < r; l++, r--) {
                char temp = a[l];
                a[l] = a[r];
                a[r] = temp;
            }
            return String.Join("",a);
        }

        public static int Decode(string shortURL)
        {
            int id = 0; // initialize result 
      
            // A simple base conversion logic 
            for (int i = 0; i < shortURL.Length; i++) 
            { 
                if ('a' <= shortURL[i] && 
                    shortURL[i] <= 'z') 
                    id = id * 62 + shortURL[i] - 'a'; 
                if ('A' <= shortURL[i] && 
                    shortURL[i] <= 'Z') 
                    id = id * 62 + shortURL[i] - 'A' + 26; 
                if ('0' <= shortURL[i] && 
                    shortURL[i] <= '9') 
                    id = id * 62 + shortURL[i] - '0' + 52; 
            } 
            return id; 
        }
        
    }
}