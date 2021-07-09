using System;
using Eweb.Common.CommonLibrary;
using Eweb.BDSService;
namespace Eweb.Appcore.ServiceManagement
{
    public class BDSDeliveryManagement
    {
        private IBDSService _bdsService;
        public BDSDeliveryManagement(IBDSService bdsService)
        {
            _bdsService = bdsService;
        }
        public long Message(ref string pv_strMessage)
        {
            long lngReturn = CommonConst.ERR_SYSTEM_OK;
            try
            {
                pv_strMessage = modCommond.TripleDesEncryptData(ref pv_strMessage);
                // Dim pv_arrByteMessage() As Byte;
                // pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage);
                //Send to BDS
                lngReturn = _bdsService.Message(ref pv_strMessage);

                //pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

                pv_strMessage = modCommond.TripleDesDecryptData(pv_strMessage);
                return lngReturn;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
       
    }

// Public Class BDSDeliveryLongTimeOutManagement
//     'Public Function Message(ByRef pv_strMessage As String) As Long
//     '    'Dim strTemp As String = pv_strMessage
//     '    'Message = CommonLibrary.modCommond.UseServiceClient(Function(client As BDSDelivery.IBDSDelivery) client.Message(strTemp))
//     '    'pv_strMessage = strTemp
//     '    Dim lngReturn As Long = ERR_SYSTEM_OK
//     '    Dim ws As New BDSService.BDSServiceClient
//     '    Try
//     '        ws.InnerChannel.OperationTimeout = System.TimeSpan.FromMilliseconds(gc_WEB_SERVICE_TIMEOUT)
//     '        pv_strMessage = TripleDesEncryptData(pv_strMessage)
//     '        lngReturn = ws.Message(pv_strMessage)
//     '        pv_strMessage = TripleDesDecryptData(pv_strMessage)
//     '        Return lngReturn
//     '    Catch ex As Exception
//     '        ws.Abort()
//     '    Finally
//     '        ws.Close()
//     '    End Try
//     'End Function
//     Public Function Message(ByRef pv_strMessage As String) As Long
//         'Dim strTemp As String = pv_strMessage
//         'Message = CommonLibrary.modCommond.UseServiceClient(Function(client As BDSDelivery.IBDSDelivery) client.Message(strTemp))
//         'pv_strMessage = strTemp
//         Dim lngReturn As Long = ERR_SYSTEM_OK
//         Dim ws As New BDSService.BDSServiceClient
//         Try
//             ws.InnerChannel.OperationTimeout = System.TimeSpan.FromMilliseconds(gc_WEB_SERVICE_TIMEOUT)
//             pv_strMessage = TripleDesEncryptData(pv_strMessage)

//             Dim pv_arrByteMessage() As Byte
//             pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

//             'lngReturn = ws.Message(pv_strMessage)
//             lngReturn = ws.MessageBytes(pv_arrByteMessage)
//             'Decompress
//             pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)

//             pv_strMessage = TripleDesDecryptData(pv_strMessage)
//             Return lngReturn
//         Catch ex As Exception
//             ws.Abort()
//             Throw ex
//         Finally
//             ws.Close()
//         End Try
//     End Function

// End Class

// Public Class BDSRptDeliveryManagement
//     'Public Function Message(ByRef pv_strMessage As String) As Long
//     '    'Return (New BDSDelivery.BDSDeliveryClient).Message(pv_strMessage)
//     '    'Dim strTemp As String = pv_strMessage
//     '    'Message = CommonLibrary.modCommond.UseServiceClient(Function(client As BDSDelivery.IBDSDelivery) client.Message(strTemp))
//     '    'pv_strMessage = strTemp
//     '    Dim lngReturn As Long = ERR_SYSTEM_OK
//     '    Dim ws As New BDSRptService.BDSRptServiceClient
//     '    Try
//     '        'Dim ws As New HOSTDelivery.HOSTDeliveryClient
//     '        pv_strMessage = TripleDesEncryptData(pv_strMessage)
//     '        lngReturn = ws.Message(pv_strMessage)
//     '        pv_strMessage = TripleDesDecryptData(pv_strMessage)
//     '        Return lngReturn
//     '    Catch ex As Exception
//     '        ws.Abort()
//     '    Finally
//     '        ws.Close()
//     '    End Try
//     '    Return lngReturn
//     'End Function
//     Public Function Message(ByRef pv_strMessage As String) As Long
//         'Return (New BDSDelivery.BDSDeliveryClient).Message(pv_strMessage)
//         'Dim strTemp As String = pv_strMessage
//         'Message = CommonLibrary.modCommond.UseServiceClient(Function(client As BDSDelivery.IBDSDelivery) client.Message(strTemp))
//         'pv_strMessage = strTemp
//         Dim lngReturn As Long = ERR_SYSTEM_OK
//         Dim ws As New BDSRptService.BDSRptServiceClient
//         Try
//             'Dim ws As New HOSTDelivery.HOSTDeliveryClient
//             pv_strMessage = TripleDesEncryptData(pv_strMessage)

//             Dim pv_arrByteMessage() As Byte
//             pv_arrByteMessage = ZetaCompressionLibrary.CompressionHelper.CompressString(pv_strMessage)

//             'lngReturn = ws.Message(pv_strMessage)
//             lngReturn = ws.MessageBytes(pv_arrByteMessage)
//             'Decompress
//             pv_strMessage = ZetaCompressionLibrary.CompressionHelper.DecompressString(pv_arrByteMessage)
//             pv_strMessage = TripleDesDecryptData(pv_strMessage)
//             Return lngReturn
//         Catch ex As Exception
//             ws.Abort()
//             Throw ex
//         Finally
//             ws.Close()
//         End Try
//         Return lngReturn
//     End Function

// End Class

// Public Class AuthManagement
//     Public Function Message(ByRef pv_strMessage As String) As Long
//         Dim lngReturn As Long = ERR_SYSTEM_OK
//         Dim ws As New AuthService.AuthServiceClient
//         Try
//             pv_strMessage = TripleDesEncryptData(pv_strMessage)
//             lngReturn = ws.Message(pv_strMessage)
//             pv_strMessage = TripleDesDecryptData(pv_strMessage)
//             Return lngReturn
//         Catch ex As Exception
//             ws.Abort()
//             Throw ex
//         Finally
//             ws.Close()
//         End Try
//     End Function
//     Public Function GetAuthorizationTicket(ByVal pv_strUserName As String, ByVal pv_strPassword As String) As String
//         'GetAuthorizationTicket = CommonLibrary.modCommond.UseServiceClient(Function(client As AuthService.IAuthService) client.GetAuthorizationTicket(pv_strUserName, pv_strPassword))
//         Dim ws As New AuthService.AuthServiceClient
//         Try
//             Return ws.GetAuthorizationTicket(pv_strUserName, pv_strPassword)
//         Catch ex As Exception
//             ws.Abort()
//             Throw ex
//         Finally
//             ws.Close()
//         End Try
//     End Function

//     Public Function GetTellerProfile(ByVal ticket As String) As CTellerProfile
//         'Dim strTemp As String = ticket
//         'GetTellerProfile = CommonLibrary.modCommond.UseServiceClient(Function(client As AuthService.IAuthService) client.GetTellerProfile(strTemp))
//         Dim ws As New AuthService.AuthServiceClient
//         Try
//             Return ws.GetTellerProfile(ticket)
//         Catch ex As Exception
//             ws.Abort()
//             Throw ex
//         Finally
//             ws.Close()
//         End Try
//     End Function
// End Class

}