using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Test_WPF
{
    public static class Bdd
    {
        public static Datas.EducationAllEntities _db = new Datas.EducationAllEntities();      

        public static String SHA1(string ipString)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            byte[] ipBytes = Encoding.Default.GetBytes(ipString.ToCharArray());
            byte[] opBytes = sha1.ComputeHash(ipBytes);

            StringBuilder stringBuilder = new StringBuilder(40);
            for (int i = 0; i < opBytes.Length; i++)
            {
                stringBuilder.Append(opBytes[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
