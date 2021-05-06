using System;
using System.Text;
using System.Security.Cryptography;

namespace Eweb.Common.CommonLibrary
{
    public static class modCommond
    {
        public static string TripleDesEncryptData(ref string v_Data) 
        {
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            try
            {
                string v_strKey1, v_strKey2, v_strKey3, v_strKey4, v_strKey5;
                v_strKey1 = "VND";
                v_strKey2 = "SBnG";
                v_strKey3 = "USD";
                v_strKey4 = "EUR";
                v_strKey5 = "F31";
                desCryptoProvider.Key = hashMD5Provider.ComputeHash(Encoding.Unicode.GetBytes(v_strKey1 + v_strKey2 + v_strKey3 + v_strKey4 + v_strKey5));
                desCryptoProvider.Mode = CipherMode.ECB;
                byte[] input = Encoding.Unicode.GetBytes(v_Data);
                string encoded = Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(input, 0, input.Length));
                return encoded;
            }
            catch (Exception ex)
            {
                hashMD5Provider = null;
                desCryptoProvider = null;
                throw ex;
            }
        }

        public static string TripleDesDecryptData(string encodedText, string key)
        {
                TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
                MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
            try
            {
                byte[] byteHash;
                byte[] byteBuff;
                desCryptoProvider.Key = hashMD5Provider.ComputeHash(Encoding.Unicode.GetBytes(key));
                desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
                byteBuff = Convert.FromBase64String(encodedText);

                string plaintext = Encoding.Unicode.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
                return plaintext;
            }
            catch (Exception ex)
            {
                hashMD5Provider = null;
                desCryptoProvider = null;
                throw ex;
            }
        }
    }
}
