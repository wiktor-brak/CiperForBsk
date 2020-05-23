using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CiperForBsk.Data;
using CiperForBsk.Models;
using Microsoft.AspNetCore.Mvc;

namespace CiperForBsk.Controllers
{
    public class CipherController : Controller
    {

        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private static string Cipher(string input, string key, bool encipher)
        {
            for (int i = 0; i < key.Length; ++i)
                if (!char.IsLetter(key[i]))
                    return null; 

            string output = string.Empty;
            int nonAlphaCharCount = 0;

            for (int i = 0; i < input.Length; ++i)
            {
                if (char.IsLetter(input[i]))
                {
                    bool cIsUpper = char.IsUpper(input[i]);
                    char offset = cIsUpper ? 'A' : 'a';
                    int keyIndex = (i - nonAlphaCharCount) % key.Length;
                    int k = (cIsUpper ? char.ToUpper(key[keyIndex]) : char.ToLower(key[keyIndex])) - offset;
                    k = encipher ? k : -k;
                    char ch = (char)((Mod(((input[i] + k) - offset), 26)) + offset);
                    output += ch;
                }
                else
                {
                    output += input[i];
                    ++nonAlphaCharCount;
                }
            }

            return output;
        }

        public static string Encipher(string input, string key)
        {
            return Cipher(input, key, true);
        }

        public IActionResult Vigenere(Message message)
        {

            

            if (!String.IsNullOrEmpty(message.Msg) && !String.IsNullOrEmpty(message.Key))
            {
                string cipherText = Encipher(message.Msg, message.Key);
                message.Msg = cipherText;
            }
            
            return View(message);
        }

        public IActionResult Caesar(Message message)
        {
            string s = "";     
            var result = message;
            if (!String.IsNullOrEmpty(result.Msg))
            {
                foreach (var znak in result.Msg)
                {
                    int c = 97 + (znak + result.Step - 97) % 26;
                    char znak1 = (char)c;
                    s += znak1;
                }
                result.Msg = s;
            }

            return View(result);
        }

        public IActionResult Atbash(Message message)
        {
            string s = "";
            var result = message;
            if (!String.IsNullOrEmpty(result.Msg))
            {
                foreach (var znak in result.Msg)
                {
                    int c = 97 + (25 - znak + 97) % 26;
                    char znak1 = (char)c;
                    s += znak1;
                }
                result.Msg = s;
            }

            return View(result);
        }
    }
}