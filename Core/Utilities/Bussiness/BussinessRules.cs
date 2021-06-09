using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Bussiness
{
    public class BussinessRules
    {
        //params:Birden fazla parametre verilmesi icin kullanilir ve onlari bir array a atar
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Succsess)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
