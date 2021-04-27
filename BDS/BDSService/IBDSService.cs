using System;
namespace Eweb.BDSService
{
    public interface IBDSService
    {
        void DoWork();

        long Message(ref string pv_strMessage);

        //long PlaceOrder(ref string pv_strMessage);

        long MessageBytes(ref byte[] v_arrByteMessage);

        //End Namespace
    }
}


   