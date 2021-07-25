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
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string strFilePath = $"{strPath}\\Templates\\Receipt.html";
            using(StreamReader srReader = new StreamReader(strFilePath))
            {
                return srReader.ReadToEnd();
            }
        }

        public static string LoadInventoryTemplate()
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string strFilePath = $"{strPath}\\Templates\\Inventory-Update.html";
            using (StreamReader srReader = new StreamReader(strFilePath))
            {
                return srReader.ReadToEnd();
            }
        }

        public static string LoadInventoryReportTemplate()
        {
            string strPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            string strFilePath = $"{strPath}\\Templates\\Inventory-Report.html";
            using (StreamReader srReader = new StreamReader(strFilePath))
            {
                return srReader.ReadToEnd();
            }
        }
    }
}
