using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ravi_Sinha_s_SuccessiveApproximationGUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // Application.Run(new Form1());
            Form f1 = new Form1();
            f1.Text = "Ravi's ADC via Successive Approximation";
            f1.ShowDialog();
        }
    }
}
