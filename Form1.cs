using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;

namespace NICExtractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string webserverpath;
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                if (webBrowser1.Url.ToString() == "https://www.nic.ir/Just_Released?captcha=" + textBox1.Text){
                string source = webBrowser1.DocumentText;
                System.IO.File.WriteAllText(@"C:\wamp64\www\list.txt", source);
                WebClient extractor = new WebClient();
                extractor.DownloadFile("http://localhost/domainex.php", "extracted.txt");
                string extracted = System.IO.File.ReadAllText("extracted.txt");
                var array = extracted.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string i in array)
                {
                    textBox2.Text += i + "\r\n";
                }
                Clipboard.SetText(textBox2.Text);
                MessageBox.Show(textBox2.Lines.Count().ToString() + " Domains Copied to Clip Board", "Succeded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
                else
                {
                   // MessageBox.Show(webBrowser1.Url.ToString());
                }
            }
            catch(Exception ex1)
            {
                MessageBox.Show(ex1.ToString(), "FATAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.nic.ir/Show_CAPTCHA");
            if (System.IO.File.Exists("webserverp.txt"))
            {
                webserverpath = File.ReadAllText("webserverp.txt"); 
            }
            else
            {
                webserverpath = textBox3.Text;
                File.WriteAllText("webserverp.txt", textBox3.Text);
            }
        }
     
        private void button1_Click(object sender, EventArgs e)
        {
            //   webBrowser1.Navigate("https://www.nic.ir/Just_Released?captcha=" + textBox1.Text);
            //webBrowser1.Encoding = Encoding.UTF8;
            // CookieContainer cookies = new CookieContainer();
             webBrowser1.Navigate("https://www.nic.ir/Just_Released?captcha=" + textBox1.Text);
          




        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.nic.ir/Show_CAPTCHA");
            textBox1.Text = "";
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
           

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webserverpath = textBox3.Text;
            File.WriteAllText("webserverp.txt", textBox3.Text);
        }
    }
}
