using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PFSpells
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            string[] spellNames = textBox1.Lines;
            string charName = textBox2.Lines[0];
            StringWriter writer = new StringWriter();
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<title>" + charName + "</title>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");

            HtmlWeb web = new HtmlWeb();
            foreach (string name in spellNames)
            {
                string nameForURL = Regex.Replace(name, "[^0-9a-zA-Z' ]", "");
                nameForURL = Regex.Replace(nameForURL, "[' ]", "-");
                string url = "https://www.d20pfsrd.com/magic/all-spells/" + nameForURL[0] + "/" + nameForURL;
                url = url.ToLower();

                HtmlAgilityPack.HtmlDocument htmlDoc = web.Load(url);
                HtmlNode spellNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'article-content')]");
                if (spellNode == null)
                {
                    nameForURL = Regex.Replace(name, "[^0-9a-zA-Z' ]", "");
                    url = "https://cse.google.com/cse?cx=006680642033474972217%3A6zo0hx_wle8&q=" + nameForURL + "#gsc.tab=0&gsc.q=" + nameForURL + "&gsc.ref=more%3Aspells&gsc.sort=";
                    WebBrowser wb = new WebBrowser();
                    wb.Navigate(url);
                    while (wb.ReadyState != WebBrowserReadyState.Complete)
                        Application.DoEvents();
                    HtmlAgilityPack.HtmlDocument searchDoc = new HtmlAgilityPack.HtmlDocument();
                    searchDoc.LoadHtml(wb.DocumentText);
                    searchDoc.Save("./html.html");
                    HtmlNode linkNode = searchDoc.DocumentNode.SelectSingleNode("//a[contains(@class, 'gs-title')]");
                    htmlDoc = web.LoadFromBrowser(url);
                    spellNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'article-content')]");
                }
                HtmlNode productNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'product-right')]");
                if (productNode != null)
                    productNode.Remove();
                writer.WriteLine("<h1>" + name + "</h1>");
                spellNode.WriteTo(writer);
            }

            writer.WriteLine("</body>");
            writer.WriteLine("</html>");

            var addr = @"./chars/";
            Directory.CreateDirectory(@"./chars/");
            File.WriteAllText(@"./chars/" + charName + ".html", writer.ToString());
            button1.Enabled = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
