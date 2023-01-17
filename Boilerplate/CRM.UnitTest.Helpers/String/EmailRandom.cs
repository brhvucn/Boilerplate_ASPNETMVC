using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UnitTest.Helpers.String
{
    public static class EmailRandom
    {
        public static string GetRandomEmail()
        {            
            Random r = new Random();

            const string allowedChars = "abcdefghijkmnopqrstuvwxyz";            
            string resultEmail = "";

            for (int i = 0; i < 15; i++)
            {
               resultEmail += allowedChars[r.Next(0, allowedChars.Length)];
            }
            resultEmail += "@";
            for (int i = 0; i < 5; i++)
            {
                resultEmail += allowedChars[r.Next(0, allowedChars.Length)];
            }
            resultEmail += ".com";
            return resultEmail;
        }
    }
}
