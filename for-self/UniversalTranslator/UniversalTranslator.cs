using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace UniversalTranslator
{
    public class UniversalTranslator
    {
       
        public T DoubleInput<T>(T numericInput)
            where T : INumber<T>
        {
            T multiplier = T.CreateChecked(2);

            return numericInput * multiplier;
        }
    }

}
