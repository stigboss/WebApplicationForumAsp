﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Utils
{
    static public class Utils
    {
        public static String GetSHA_256(String str)
        {
            using (var hasher = System.Security.Cryptography.SHA256.Create())
            {

                byte[] strBytes = System.Text.Encoding.ASCII.GetBytes(str);

                byte[] hashBytes = hasher.ComputeHash(strBytes);

                var sb = new System.Text.StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                return sb.ToString();
            }
        }
    }
}