using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MultiQueueTesting;
using MultiQueueModels;
using System.IO;

namespace MultiQueueSimulation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //InitialTesting..
            foreach(string s in Directory.EnumerateFiles(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory().ToString()).ToString()) + "\\TestCases\\"))
            {
                string fileName = s.Substring(s.LastIndexOf("\\") + 1);
                if(fileName.Contains("TestCase"))
                {
                    MessageBox.Show("Press OK to run test #" + fileName[fileName.LastIndexOf('.') - 1]);
                    Simulator.Test(fileName);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
