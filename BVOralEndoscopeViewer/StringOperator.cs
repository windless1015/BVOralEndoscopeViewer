using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BVOralEndoscopeViewer
{
    class StringOperator
    {
        static public byte[] ConvertStringToHEXByte(string text)
        {
            System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
            byte[] tmpBytes = enc.GetBytes(text);
            for (int i = 0; i < text.Length; i++)
            {
                tmpBytes[i] = Convert.ToByte(text.Substring(i, 1), 16);
            }
            return tmpBytes;
        }

        static public bool CompareByteArraysEqual(ref byte[] b1, ref byte[] b2)
        {
            if (b1 == null || b2 == null) return false;
            if (b1.Length != b2.Length) return false;
            for (int i = 0; i < b1.Length; i++)
                if (b1[i] != b2[i])
                    return false;
            return true;
        }
    }
}
