using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2
{
     static class Utilities
    {
        //Generic swap
        public static void Swap<T>(ref T a, ref T b)
        {
            T temp = b; //store b in temp 
            b = a;      //b gets replaced by a
            a = temp;   //then temp which was b is now assigned to a
              
        }
    }
}
