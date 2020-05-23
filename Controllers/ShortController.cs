using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using CiperForBsk.Models;
using Microsoft.AspNetCore.Mvc;

namespace CiperForBsk.Controllers
{
    public class ShortController : Controller
    {


        static string GetMd5Hash(MD5 md5Hash, string input)
        {


            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }


            return sBuilder.ToString();
        }

        public IActionResult ShortMD5(Message message)
        {

            
            using (MD5 md5Hash = MD5.Create())
            {
               
                if (!String.IsNullOrEmpty(message.Msg))
                {
                    string hash = GetMd5Hash(md5Hash, message.Msg);
                    message.Msg = hash;
                }
            }
            return View(message);
        }

        public IActionResult ShortSHA256(Message message)
        {

            using (SHA256 sha256Hash = SHA256.Create())
            {

                if (!String.IsNullOrEmpty(message.Msg))
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(message.Msg);
                    byte[] hashBytes = sha256Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                    message.Msg = hash;
                }
            }
            return View(message);
        }
        public IActionResult ShortSHA512(Message message)
        {

            using (SHA512 sha512Hash = SHA512.Create())
            {

                if (!String.IsNullOrEmpty(message.Msg))
                {
                    byte[] sourceBytes = Encoding.UTF8.GetBytes(message.Msg);
                    byte[] hashBytes = sha512Hash.ComputeHash(sourceBytes);
                    string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                    message.Msg = hash;
                }
            }
            return View(message);
        }
    }
}