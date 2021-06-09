using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {

        //****NOT:****GET er lar readonly yapılardır ancak constructer lar sayesinde set edllebilirler
        //:this(success) islemi: kullanici tek parametre ister ise bu blok iki parametre ister ise asagıdaki blok ile bir calis demek 
        public Result(bool success, string message):this(success)
        {
            Message = message;
        }
        public Result(bool success) 
        {
            Succsess = success;
        }

        public bool Succsess { get; }

        public string Message { get; }
    }
}
