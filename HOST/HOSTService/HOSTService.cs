using Eweb.Common.CommonLibrary;
using Eweb.Common.DataAccessLayer;
using Eweb.Common.Configurations;
using System;
using System.Threading.Tasks;

namespace Eweb.HOST.HOSTService
{

    public class HOSTService : IHOSTService
    {
        private readonly ConnectionConfiguration _connectionConfig;

        public HOSTService(ConnectionConfiguration connectionConfig)
        {
            _connectionConfig = connectionConfig;
        }

        public async Task<string> ExcuteCmdReturnDatasetByFilter(string v_strFilter)
        {
            var v_result = string.Empty;
            var v_obj = new MongoDbHelper(_connectionConfig);
            v_result = await v_obj.ExecuteCMDReturnDatasetByFilter("", "", v_strFilter);
            return v_result;
        }

        public void DoWork() { }

        public long Message(ref string pv_strMessage)
        {
            //Dim v_strResultData As String = vbNullString
            long v_lngErr = 0;
            //         Dim v_strACTIONFLAG As String = String.Empty
            try
            {
                pv_strMessage = modCommond.TripleDesEncryptData(ref pv_strMessage);
                return v_lngErr;
            }
            catch (Exception e)
            {
                throw e;
            }
            //             pv_strMessage = TripleDesDecryptData(pv_strMessage)
            //             'Read transaction message 
            //             Dim v_xmlDocumentMessage As New XmlDocumentEx
            //             v_xmlDocumentMessage.LoadXml(pv_strMessage)

            //             If Log.IsDebugEnabled Then
            //                 Log.Debug("::Message:: [RECEIVED MESSAGE FROM CLIENT]")
            //             End If

            //             'Get header message.
            //             Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocumentMessage.DocumentElement.Attributes
            //             Dim v_strLOCAL As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            //             Dim v_strMSGTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeMSGTYPE), Xml.XmlAttribute).Value)
            //             If Not (v_attrColl.GetNamedItem(modCommond.gc_AtributeACTFLAG) Is Nothing) Then
            //                 v_strACTIONFLAG = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeACTFLAG), Xml.XmlAttribute).Value)
            //             End If

            //             If Log.IsDebugEnabled Then
            //                 Log.Debug(String.Format("::Message:: [LOCAL] {0} : [MSGTYPE] {1}", v_strLOCAL, v_strMSGTYPE))
            //             End If

            //             If Log.IsDebugEnabled Then
            //                 Log.Debug(String.Format("::Message:: [SEND TO HOST] [{0}] ", pv_strMessage))
            //             End If

            //             'If v_strLOCAL = "Y" Or v_strMSGTYPE = gc_MsgTypeTrans Then
            //             '    Dim v_obj As New Branch.Branch
            //             '    Select Case v_strMSGTYPE
            //             '        Case gc_MsgTypeTrans
            //             '            'Transaction message
            //             '            v_lngErr = v_obj.txTransfer(pv_strMessage)
            //             '        Case gc_MsgTypeObj
            //             '            'Object message
            //             '            v_lngErr = v_obj.objTransfer(pv_strMessage)
            //             '    End Select
            //             'ElseIf v_strLOCAL = "N" And v_strMSGTYPE = gc_MsgTypeObj Then
            //             If v_strLOCAL = "T" Then
            //                 Log.Info("Begin Sleep")
            //                 Threading.Thread.Sleep(5000)
            //                 Log.Info("Sleep Done")
            //             Else
            //                 If v_strACTIONFLAG = modCommond.gc_ActionBatch Then
            //                     v_lngErr = SendMessageWithLongTimeOut2Host(pv_strMessage)
            //                 Else
            //                     v_lngErr = SendMessage2Host(pv_strMessage)
            //                 End If
            //                 If Log.IsDebugEnabled Then
            //                     Log.Debug(String.Format("::Message:: [RECEIVED FROM HOST] [{0}] ", pv_strMessage))
            //                 End If
            //             End If

            //             If Log.IsDebugEnabled Then
            //                 Log.Debug(String.Format("::Message:: [RECEIVED FROM HOST] [{0}] ", pv_strMessage))
            //             End If

            //             'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
            //             Dim v_strErrorSource As String = String.Empty
            //             Dim v_strErrorMessage As String = String.Empty
            //             Dim v_lngErrorCode As Long = v_lngErr
            //             Dim v_strSessionID As String = String.Empty

            //             GetErrorFromMessage(pv_strMessage, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)


            //             If v_lngErrorCode <> ERR_SYSTEM_OK Then
            //                 GetSessionID(pv_strMessage, v_strSessionID)
            //                 'Lấy thông báo lỗi từ bảng DEFERROR đã được replication xuống BDS
            //                 If v_strErrorMessage.Length = 0 Then
            //                     v_strErrorMessage = GetErrorMessage(v_lngErrorCode, v_strSessionID)
            //                 End If
            //                 ReplaceXMLErrorException(pv_strMessage, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
            //                 'Log lỗi
            //                 LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
            //                              & "Error code: " & v_lngErrorCode.ToString() & vbNewLine _
            //                              & "Error message: " & v_strErrorMessage, EventLogEntryType.Error)
            //             End If

            //             pv_strMessage = TripleDesEncryptData(pv_strMessage)

            //             If Log.IsDebugEnabled Then
            //                 Log.Debug(String.Format("::Message:: [RETURN MESSAGE TO CLIENT] [{0}] ", pv_strMessage))
            //             End If

            //             Return v_lngErr
            //         Catch ex As Exception
            //             Log.Error("::Message::", ex)
            //             LogError.Write("Error source: " & ex.Source & vbNewLine _
            //                          & "Error code: System error!" & vbNewLine _
            //                          & "Error message: " & ex.Message, EventLogEntryType.Error)
            //             Throw ex
            //         End Try
            //     End Function
            //     End Sub
        }

        public long MessageBytes(ref byte[] pv_arrByteMessage)
        {
            string v_strResultData = string.Empty;
            long v_lngErr = 0;
            string v_strACTIONFLAG = string.Empty;
            try
            {
                return v_lngErr;
            }
            catch (Exception e)
            {
                throw e;
            }
            //             Dim pv_strMessage As String
            //             pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

            //             pv_strMessage = TripleDesDecryptData(pv_strMessage)
            //             'Read transaction message 
            //             Dim v_xmlDocumentMessage As New XmlDocumentEx
            //             v_xmlDocumentMessage.LoadXml(pv_strMessage)

            //             If Log.IsDebugEnabled Then
            //                 Log.Debug("::Message:: [RECEIVED MESSAGE FROM CLIENT]")
            //             End If

            //             'Get header message.
            //             Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocumentMessage.DocumentElement.Attributes
            //             Dim v_strLOCAL As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeLOCAL), Xml.XmlAttribute).Value)
            //             Dim v_strMSGTYPE As String = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeMSGTYPE), Xml.XmlAttribute).Value)
            //             If Not (v_attrColl.GetNamedItem(modCommond.gc_AtributeACTFLAG) Is Nothing) Then
            //                 v_strACTIONFLAG = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeACTFLAG), Xml.XmlAttribute).Value)
            //             End If

            //             If Log.IsDebugEnabled Then
            //                 Log.Debug(String.Format("::Message:: [LOCAL] {0} : [MSGTYPE] {1}", v_strLOCAL, v_strMSGTYPE))
            //             End If

            //             If Log.IsDebugEnabled Then
            //                 Log.Debug(String.Format("::Message:: [SEND TO HOST] [{0}] ", pv_strMessage))
            //             End If

            //             If v_strLOCAL = "T" Then
            //                 Log.Info("Begin Sleep")
            //                 Threading.Thread.Sleep(5000)
            //                 Log.Info("Sleep Done")
            //             Else
            //                 If v_strACTIONFLAG = modCommond.gc_ActionBatch Then
            //                     v_lngErr = SendMessageWithLongTimeOut2Host(pv_strMessage)
            //                 Else
            //                     v_lngErr = SendMessage2Host(pv_strMessage)
            //                 End If
            //                 If Log.IsDebugEnabled Then
            //                     Log.Debug(String.Format("::Message:: [RECEIVED FROM HOST] [{0}] ", pv_strMessage))
            //                 End If
            //             End If

            //             'Kiểm tra thông tin và xử lý lỗi (nếu có) từ message trả về
            //             Dim v_strErrorSource As String = String.Empty
            //             Dim v_strErrorMessage As String = String.Empty
            //             Dim v_lngErrorCode As Long = v_lngErr
            //             Dim v_strSessionID As String = String.Empty

            //             GetErrorFromMessage(pv_strMessage, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)


            //             If v_lngErrorCode <> ERR_SYSTEM_OK Then
            //                 GetSessionID(pv_strMessage, v_strSessionID)
            //                 'Lấy thông báo lỗi từ bảng DEFERROR đã được replication xuống BDS
            //                 If v_strErrorMessage.Length = 0 Then
            //                     v_strErrorMessage = GetErrorMessage(v_lngErrorCode, v_strSessionID)
            //                 End If
            //                 ReplaceXMLErrorException(pv_strMessage, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
            //                 'Log lỗi
            //                 LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
            //                              & "Error code: " & v_lngErrorCode.ToString() & vbNewLine _
            //                              & "Error message: " & v_strErrorMessage, EventLogEntryType.Error)
            //             End If

            //             pv_strMessage = TripleDesEncryptData(pv_strMessage)

            //             If Log.IsDebugEnabled Then
            //                 Log.Debug(String.Format("::Message:: [RETURN MESSAGE TO CLIENT] [{0}] ", pv_strMessage))
            //             End If

            //             pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)
            //             Return v_lngErr
            //         Catch ex As Exception
            //             Log.Error("::Message::", ex)
            //             LogError.Write("Error source: " & ex.Source & vbNewLine _
            //                          & "Error code: System error!" & vbNewLine _
            //                          & "Error message: " & ex.Message, EventLogEntryType.Error)
            //             Throw ex
            //         End Try
            //     End Function
        }
    }
    //     Implements IBDSService

    // #Region "Log Utils"
    //     Private ReadOnly Log As ILog = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType)

    //     Public Shared Function A(ByVal logString As String, ByVal ParamArray logParams As Object()) As String
    //         Dim sb As New StringBuilder
    //         sb.Append(logString).Append(".:")
    //         For Each s As Object In logParams
    //             sb.Append(", [").Append(s).Append("]")
    //         Next
    //         Return sb.ToString()
    //     End Function
    // #End Region

    //     Private Function GetErrorMessage(ByVal pv_lngErrorCode As Long, ByVal pv_strSessionID As String) As String
    //         Dim v_strErrorMessage As String = String.Empty
    //         Dim v_strErrorENMessage As String = String.Empty
    //         Dim v_obj As New Branch.Branch
    //         Dim v_lngError As Long

    //         Try
    //             Dim v_strClause As String = " ERRNUM = " & pv_lngErrorCode.ToString()
    //             modCommond.SessionID = pv_strSessionID
    //             Dim v_strObjMsg As String = BuildXMLObjMsg(, , , , gc_IsLocalMsg, gc_MsgTypeObj, OBJNAME_SY_DEFERROR, gc_ActionInquiry, , v_strClause)

    //             v_lngError = SendMessage2Host(v_strObjMsg)
    //             'v_lngError = v_obj.objTransfer(v_strObjMsg)

    //             Dim v_xmlDocument As New XmlDocumentEx
    //             Dim v_nodeList As Xml.XmlNodeList
    //             Dim v_strValue, v_strFLDNAME As String

    //             'Read object message 
    //             v_xmlDocument.LoadXml(v_strObjMsg)
    //             v_nodeList = v_xmlDocument.SelectNodes("/ObjectMessage/ObjData")
    //             If v_nodeList.Count = 1 Then
    //                 For i As Integer = 0 To v_nodeList.Count - 1
    //                     For j As Integer = 0 To v_nodeList.Item(i).ChildNodes.Count - 1
    //                         With v_nodeList.Item(i).ChildNodes(j)
    //                             v_strValue = .InnerText.ToString
    //                             v_strFLDNAME = CStr(CType(.Attributes.GetNamedItem("fldname"), Xml.XmlAttribute).Value)

    //                             If Trim(v_strFLDNAME) = "ERRDESC" Then
    //                                 v_strErrorMessage = v_strValue
    //                             ElseIf Trim(v_strFLDNAME) = "EN_ERRDESC" Then
    //                                 v_strErrorENMessage = v_strValue
    //                             End If
    //                         End With
    //                     Next
    //                 Next
    //             Else
    //                 'v_strErrorMessage = "[" & pv_lngErrorCode.ToString() & "]: Undefined error!"
    //                 v_strErrorMessage = "[" & pv_lngErrorCode.ToString() & "]: Lỗi chưa được định nghĩa!"
    //                 v_strErrorENMessage = "[" & pv_lngErrorCode.ToString() & "]: Undefined error!"
    //             End If

    //             Return v_strErrorMessage & ControlChars.NewLine & v_strErrorENMessage
    //             'Return v_strErrorMessage & ControlChars.NewLine & v_strErrorENMessage
    //         Catch ex As Exception
    //             LogError.Write("Error source: " & ex.Source & vbNewLine _
    //                          & "Error code: System error!" & vbNewLine _
    //                          & "Error message: " & ex.Message, EventLogEntryType.Error)
    //             Throw ex
    //         End Try
    //     End Function

    //     Public Function PlaceOrder(ByRef pv_strMessage As String) As Long Implements IBDSService.PlaceOrder
    //         Dim v_strMessage, v_strErrorMessage As String, v_lngErrorCode As Long
    //         Dim v_strErrorSource As String = "TradingEngine.PlaceOrder"
    //         Dim v_obj As New Branch.Branch
    //         Try
    //             pv_strMessage = TripleDesDecryptData(pv_strMessage)
    //             v_strMessage = BuildXMLObjMsg(, "0001", , "0001", gc_IsNotLocalMsg, gc_MsgTypeObj, OBJNAME_FO_FOMAST, gc_ActionAdhoc, , pv_strMessage, "PlaceOrder")
    //             v_lngErrorCode = v_obj.SendMessage2Host(v_strMessage)
    //             If v_lngErrorCode <> ERR_SYSTEM_OK Then
    //                 GetErrorFromMessage(v_strMessage, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
    //                 'them phan xu ly cho nay giong nhu ben kia
    //                 Dim v_strSessionID As String = String.Empty

    //                 If v_strErrorMessage.Length = 0 Then
    //                     GetSessionID(pv_strMessage, v_strSessionID)
    //                     v_strErrorMessage = GetErrorMessage(v_lngErrorCode, v_strSessionID)
    //                 End If
    //                 ReplaceXMLErrorException(v_strMessage, v_strErrorSource, v_lngErrorCode, v_strErrorMessage)
    //                 'Log lỗi
    //                 LogError.Write("Error source: " & v_strErrorSource & vbNewLine _
    //                              & "Error code: " & v_lngErrorCode.ToString() & vbNewLine _
    //                              & "Error message: " & v_strErrorMessage, EventLogEntryType.Error)
    //             End If
    //             pv_strMessage = v_strMessage
    //             pv_strMessage = TripleDesEncryptData(pv_strMessage)
    //             Return v_lngErrorCode
    //         Catch ex As Exception
    //             Throw ex
    //         Finally
    //             'v_obj = Nothing
    //         End Try
    //     End Function
    //     Public Function SendMessage2Host(ByRef pv_strMessage As String) As Long
    //         Dim v_ws As New HostDeliveryManagement

    //         Dim v_strISCOMPRESSED As String = ConfigurationManager.AppSettings("ISCOMPRESSED")
    //         Dim v_lngErr As Long

    //         'Dim v_xmlDocumentMessage As New XmlDocumentEx
    //         'v_xmlDocumentMessage.LoadXml(pv_strMessage)
    //         'Dim v_attrColl As Xml.XmlAttributeCollection = v_xmlDocumentMessage.DocumentElement.Attributes
    //         'Dim v_strOBJECT As String
    //         'If Not (v_attrColl.GetNamedItem(gc_AtributeOBJNAME) Is Nothing) Then
    //         '    v_strOBJECT = CStr(CType(v_attrColl.GetNamedItem(gc_AtributeOBJNAME), Xml.XmlAttribute).Value)
    //         'Else
    //         '    v_strOBJECT = String.Empty
    //         'End If

    //         pv_strMessage = TripleDesEncryptData(pv_strMessage)

    //         If Log.IsDebugEnabled Then
    //             Log.Debug(String.Format("::SendMessage2Host:: [MESSAGE LENGTH] [{0}]", pv_strMessage.Length))
    //         End If


    //         If v_strISCOMPRESSED = "Y" Then
    //             'Compress message
    //             Dim pv_arrByteMessage() As Byte = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

    //             If Log.IsDebugEnabled Then
    //                 Log.Debug(String.Format("::SendMessage2Host:: [COMPRESSED MESSAGE LENGTH] [{0}]", pv_arrByteMessage.Length))
    //             End If

    //             'Send to host
    //             'TruongLD Add when convert
    //             v_lngErr = v_ws.MessageByte(pv_arrByteMessage)
    //             'End TruongLD

    //             If Log.IsDebugEnabled Then
    //                 Log.Debug(String.Format("::SendMessage2Host:: [COMPRESSED MESSAGE LENGTH FROM HOST] [{0}]", pv_arrByteMessage.Length))
    //             End If

    //             'Decompress
    //             pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

    //             If Log.IsDebugEnabled Then
    //                 Log.Debug(String.Format("::SendMessage2Host:: [DECOMPRESSED MESSAGE LENGTH FROM HOST] [{0}]", pv_strMessage.Length))
    //             End If
    //         Else
    //             'Khong nen
    //             'TruongLD Add when convert
    //             v_lngErr = v_ws.MessageString(pv_strMessage)
    //             'End TruongLD
    //         End If
    //         pv_strMessage = TripleDesDecryptData(pv_strMessage)
    //         Return v_lngErr
    //     End Function
    //     Public Function SendMessageWithLongTimeOut2Host(ByRef pv_strMessage As String) As Long

    //         Dim v_ws As New HostDeliveryLongTimeOutManagement
    //         Dim v_lngErr As Long
    //         Dim v_strISCOMPRESSED As String = ConfigurationManager.AppSettings("ISCOMPRESSED")

    //         Try
    //             If v_strISCOMPRESSED = "Y" Then
    //                 'Compress message
    //                 Dim pv_arrByteMessage() As Byte = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)
    //                 'Send to host
    //                 v_lngErr = v_ws.MessageByte(pv_arrByteMessage)
    //                 'Decompress
    //                 pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
    //             Else
    //                 'Khong nen
    //                 v_lngErr = v_ws.MessageString(pv_strMessage)
    //             End If
    //         Catch ex As Exception
    //             Throw ex
    //         Finally
    //             v_ws = Nothing
    //         End Try
    //         Return v_lngErr
    //     End Function
    // End Class
}
