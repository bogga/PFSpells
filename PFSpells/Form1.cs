using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
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

        async private void button1_Click(object sender, EventArgs e)
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
            writer.WriteLine("<script>function show(id){var x=document.getElementById(id);if(x.style.display===\"none\"){x.style.display=\"block\"}else{x.style.display=\"none\"}}</script>");
            writer.WriteLine("</head>");
            writer.WriteLine("<body>");

            HtmlWeb web = new HtmlWeb();
            for (int i = 0; i < spellNames.Length; i++)
            {
                string name = spellNames[i];
                string nameForURL = Regex.Replace(name, "[^0-9a-zA-Z' ]", "");
                nameForURL = Regex.Replace(nameForURL, "[' ]", "-");
                string url = "https://www.d20pfsrd.com/magic/all-spells/" + nameForURL[0] + "/" + nameForURL;
                url = url.ToLower();

                HtmlAgilityPack.HtmlDocument htmlDoc = web.Load(url);
                HtmlNode spellNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'article-content')]");
                if (spellNode == null)
                {
                    nameForURL = name.ToLower();
                    string[] toRemove = { ", greater", ", lesser", ", communal", ", mass" };

                    foreach (string term in toRemove)
                    {
                        if (nameForURL.Contains(term))
                        {
                            nameForURL = nameForURL.Remove(nameForURL.IndexOf(term), term.Length);
                        }
                    }

                    string[] levelRemovals = { " I", " II", " III", " IV", " V", " VI", " VII", " VIII", " IX" };
                    foreach (string term in levelRemovals)
                    { 
                        if (nameForURL.Contains(term.ToLower()))
                        {
                            nameForURL = nameForURL.Remove(nameForURL.IndexOf(term.ToLower()), term.Length);
                            break;
                        }
                    }

                    url = "https://www.d20pfsrd.com/magic/all-spells/" + nameForURL[0] + "/" + nameForURL;
                    htmlDoc = web.Load(url);
                    spellNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'article-content')]");
                }
                HtmlNode productNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'product-right')]");
                if (productNode != null)
                    productNode.Remove();
                writer.WriteLine("<h1 onclick=\"show(" + i + ")\">" + name + "</h1>");
                writer.WriteLine("<div id=" + i + ">");
                spellNode.WriteTo(writer);
                writer.WriteLine("</div>");
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
