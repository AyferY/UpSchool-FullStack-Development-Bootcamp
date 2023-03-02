using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Son
{
    public class CreateRandomPassword
    {
        public string chars { get; set; }
        public int lengths { get; set; }

        public string GetRandomPassword(int lengths)
        {
           

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < lengths; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }

    }
}
