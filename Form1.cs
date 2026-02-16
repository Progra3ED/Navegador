using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class Form1 : Form
    {
        List<Direccion> direcciones = new List<Direccion>();
        public Form1()
        {
            InitializeComponent();
            this.Resize += new System.EventHandler(this.Form_Resize);
        }

        private void Guardar(string nombreArchivo)
        {

            FileStream stream = new FileStream(nombreArchivo, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var direccion in direcciones)
            {
                writer.WriteLine(direccion.Url);
                writer.WriteLine(direccion.Veces);
                writer.WriteLine(direccion.FechaAccesso);
            }
            
            writer.Close();
        }
        private void Leer()
        {
            string nombreArchivo = @"historial.txt";
            FileStream stream = new FileStream(nombreArchivo, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            while (reader.Peek() > -1)
            {
                string linea = reader.ReadLine();                
                addressBar.Items.Add(linea);
            }
            reader.Close();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            webView2.Size = this.ClientSize - new System.Drawing.Size(webView2.Location);
            goButton.Left = this.ClientSize.Width - goButton.Width;
            addressBar.Width = goButton.Left - addressBar.Left;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Direccion direccion = new Direccion();

            string Url = addressBar.Text;

            //si no contiene https o http le concatena 
            if (!((Url.Contains("https://")) || (Url.Contains("http://"))))
            {
                Url = "https://" + Url;
            }

            if (webView2 != null && webView2.CoreWebView2 != null)
            {
                webView2.CoreWebView2.Navigate(Url);    
                
                //addressBar.Items.Add (Url);
                direccion.Url = Url;
                direccion.FechaAccesso = DateTime.Now;
                direccion.Veces++;
                //direccion.Veces = direccion.Veces + 1;

                direcciones.Add(direccion);

                Guardar(@"historial.txt");
            }                        
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoHome();
        }

        private void anteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
           // webBrowser1.GoBack();
        }

        private void siguienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //webBrowser1.GoForward();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Leer();
        }
    }
}
