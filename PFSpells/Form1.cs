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
            Cursor.Current = Cursors.WaitCursor;
            string[] spellNames = textBox1.Lines;
            string charName = textBox2.Lines[0];
            StringWriter writer = new StringWriter();
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<title>" + charName + "</title>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");

            foreach (string name in spellNames)
            {
                string nameForURL = Regex.Replace(name, "[^0-9a-zA-Z' ]", "");
                nameForURL = Regex.Replace(nameForURL, "[' ]", "-");
                string url = "https://www.d20pfsrd.com/magic/all-spells/" + nameForURL[0] + "/" + nameForURL;
                url = url.ToLower();

                HtmlWeb web = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument htmlDoc = web.Load(url);
                HtmlNode spellNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'article-content')]");
                if (spellNode == null)
                    continue;
                HtmlNode productNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'product-right')]");
                if (productNode != null)
                    productNode.Remove();
                writer.WriteLine("<h1>" + name + "</h1>");
                spellNode.WriteTo(writer);
            }

            writer.WriteLine("</body>");
            writer.WriteLine("</html>");

            Directory.CreateDirectory(@"./chars/");
            File.WriteAllText(@"./chars/" + charName + ".html", writer.ToString());
            button1.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
