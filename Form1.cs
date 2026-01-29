using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Url = comboBox1.Text;

            //si no contiene https o http le concatena 
            if (!((Url.Contains("https://")) || (Url.Contains("http://"))))
            {
                Url = "https://" + Url;
            }
                         
            webBrowser1.Navigate(new Uri(Url));                        
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void anteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            webBrowser1.GoBack();
        }

        private void siguienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
    }
}
