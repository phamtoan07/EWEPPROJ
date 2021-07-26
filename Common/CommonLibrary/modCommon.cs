using System;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;

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

        public static string TripleDesDecryptData(string encodedText)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();
            try
            {
                string v_strKey1, v_strKey2, v_strKey3, v_strKey4, v_strKey5;
                v_strKey1 = "VND";
                v_strKey2 = "SBnG";
                v_strKey3 = "USD";
                v_strKey4 = "EUR";
                v_strKey5 = "F31";
                byte[] byteBuff;
                desCryptoProvider.Key = hashMD5Provider.ComputeHash(Encoding.Unicode.GetBytes(v_strKey1 + v_strKey2 + v_strKey3 + v_strKey4 + v_strKey5));
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

        public static void BuildJsonFormat(Object input, ref string output)
        {
            output = JsonConvert.SerializeObject(input);
        }

        public static void BuildJsonFormat(List<JsonElement> v_listInput, ref string v_strOutput)
        {
            string v_return = String.Empty;
            int v_count = v_listInput.Count;
            if (v_count > 0)
            {
                v_strOutput = JsonConvert.SerializeObject(v_listInput);
            }
        }
    }
    public class JsonElement
    {
        private string _key;
        private string _value;
        private string _operator;
        private string _datatype;

        public JsonElement()
        {

        }
        public JsonElement(string key, string value, string v_operator, string datatype)
        {
            this.Key = key;
            this.Value = value;
            this.Operator = v_operator;
            this.Datatype = datatype;
        }

        public string Key { get => _key; set => _key = value; }
        public string Value { get => _value; set => _value = value; }
        public string Operator { get => _operator; set => _operator = value; }
        public string Datatype { get => _datatype; set => _datatype = value; }
    }
}
