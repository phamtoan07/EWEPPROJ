using System;
using System.Text;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Eweb.Common.CommonLibrary
{
    public static class modCommond
    {
        public static CommonConst commonConst = new CommonConst();
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

        public static string BuildXMLObjMsg(string pv_strTxDate = "",
                                   string pv_strBranchId = "",
                                   string pv_strTxTime = "",
                                   string pv_strTellerId = "",
                                   string pv_strLocal = "",
                                   string pv_strMsgType = "",
                                   string pv_strObjName = "",
                                   string pv_strActionFlag = "",
                                   string pv_strCmdInquiry = "",
                                   string pv_strClause = "",
                                   string pv_strFuncName = "",
                                   string pv_strAutoId = "",
                                   string pv_strTxNum = "",
                                   string pv_strReference = "",
                                   string pv_strReserver = "",
                                   string pv_strIPAddress = "",
                                   string pv_strCmdType = "T",
                                   string pv_strPrarentObjName = "",
                                   string pv_strParentClause = "")
        {
            string v_strResult = string.Empty;
            string jsonString;
            v_strResult += commonConst.gc_SCHEMA_OBJMESSAGE_HEADER + "\n{";
            try
            {
                foreach (var i in commonConst.gc_KeyMsg)
                {
                    jsonString = string.Empty;
                    jsonString += "\"" + i.ToString() + "\"";
                    switch (i.ToString())
                    {
                        case "TXDATE":
                            jsonString += ":\"" + pv_strTxDate + "\",";
                            break;
                        case "BRID":
                            jsonString += ":\"" + pv_strBranchId + "\",";
                            break;
                        case "TXTIME":
                            jsonString += ":\"" + pv_strTxTime + "\",";
                            break;
                        case "TELLERID":
                            jsonString += ":\"" + pv_strTellerId + "\",";
                            break;
                        case "LOCAL":
                            jsonString += ":\"" + pv_strLocal + "\",";
                            break;
                        case "MSGTYPE":
                            jsonString += ":\"" + pv_strMsgType + "\",";
                            break;
                        case "OBJNAME":
                            jsonString += ":\"" + pv_strObjName + "\",";
                            break;
                        case "ACTIONFLAG":
                            jsonString += ":\"" + pv_strActionFlag + "\",";
                            break;
                        case "CMDINQUIRY":
                            jsonString += ":\"" + pv_strCmdInquiry + "\",";
                            break;
                        case "CLAUSE":
                            jsonString += ":" + pv_strClause + ",";
                            break;
                        case "FUNCTIONANE":
                            jsonString += ":\"" + pv_strFuncName + "\",";
                            break;
                        case "AUTOID":
                            jsonString += ":\"" + pv_strAutoId + "\",";
                            break;
                        case "TXNUM":
                            jsonString += ":\"" + pv_strTxNum + "\",";
                            break;
                        case "REFERENCE":
                            jsonString += ":\"" + pv_strReference + "\",";
                            break;
                        case "RESERVER":
                            jsonString += ":\"" + pv_strReserver + "\",";
                            break;
                        case "IPADDRESS":
                            jsonString += ":\"" + pv_strIPAddress + "\",";
                            break;
                        case "CMDTYPE":
                            jsonString += ":\"" + pv_strCmdType + "\",";
                            break;
                        case "PARENTOBJNAME":
                            jsonString += ":\"" + pv_strPrarentObjName + "\",";
                            break;
                        case "PARENTCLAUSE":
                            jsonString += ":\"" + pv_strParentClause + "\",";
                            break;
                    }
                    v_strResult += "\n" + jsonString;
                }

                v_strResult += "\n}" + commonConst.gc_SCHEMA_OBJMESSAGE_FOOTER;
            }
            catch (Exception e)
            {
                v_strResult = null;
            }
            return v_strResult;
        }
    }
    public class JsonElement
    {
        private string _key;
        private string _value;

        public JsonElement()
        {

        }
        public JsonElement(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }

        public string Key { get => _key; set => _key = value; }
        public string Value { get => _value; set => _value = value; }
    }
    public class JsonFilterElement
    {
        private string _key;
        private string _value;
        private string _operator;
        private string _datatype;

        public JsonFilterElement()
        {

        }
        public JsonFilterElement(string key, string value, string v_operator, string datatype)
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
