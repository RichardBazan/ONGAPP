using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace WebApiONG.Models
{
    public class Hash
    {
        public static string ComputeHash(string input, HashAlgorithm algorithm)

        {

            var inputBytes = Encoding.UTF8.GetBytes(input);

            var hashedBytes = algorithm.ComputeHash(inputBytes);

            var sBuilder = new StringBuilder();

            for (int i = 0; i < hashedBytes.Length; i++)

            {

                sBuilder.Append(hashedBytes[i].ToString("x2"));

            }

            return sBuilder.ToString();

        }
    }
}