using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    public class MathLibrary
    {
        public static double CalculateProduct(int n)
        {
            double product = 1.0;
            for (int i = 1; i <= n; i++)
            {
                product *= (1 + 1.0 / (i * i));
            }
            return product;
        }
    }
}
