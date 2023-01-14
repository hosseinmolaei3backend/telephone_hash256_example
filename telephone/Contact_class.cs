using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace telephone
{
    class Contact_class
    {
        
        public static void Hash256(string Name,string Family,string Mobile)
        {
            string[] hash = new string[] { };
            byte[] nameascii = Encoding.ASCII.GetBytes(Name);
            byte[] familyascii = Encoding.ASCII.GetBytes(Family);
            int sumname = 0, sumfamily = 0;
            foreach(var nam in nameascii)
            {
                sumname += (int)nam;
            }
            foreach(var famil in familyascii)
            {
                sumfamily += (int)famil;
            }
            int location = (sumname * (sumname + sumfamily) * 30) / ((Name.Length + Family.Length) * 10);
            hash[location] = Mobile;
        }
    }
}
