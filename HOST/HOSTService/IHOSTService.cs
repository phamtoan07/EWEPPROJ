using System;
using System.Collections.Generic;
using System.Text;

namespace Eweb.HOSTService
{

    public interface IHOSTService
    {
        void DoWork();

        long Message(ref string pv_strMessage);

        //long PlaceOrder(ref string pv_strMessage);

        long MessageBytes(ref byte[] v_arrByteMessage);

        //End Namespace
    }
}
