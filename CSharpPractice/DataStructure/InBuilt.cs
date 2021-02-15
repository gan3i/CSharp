using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class InBuilt
    {
        public static void Start()
        {

            #region Arrays
            int[] intArr = new int[4];
            intArr[1] = 1;
            intArr[2] = 2;
            intArr[3] = 3;
            intArr[4] = 4;

            Array.Sort(intArr);
            Array.Reverse(intArr);

            #endregion
        }
    }
}
