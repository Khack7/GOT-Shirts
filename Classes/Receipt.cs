using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SU21_Final_Project.Classes
{
    class Receipt
    {
        public static string LoadTemplate()
        {
            string path = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string filePath = $"{path}\\Templates\\Receipt.html";
            using(StreamReader reader = new StreamReader(filePath))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
