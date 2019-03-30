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
using System.Web;

namespace PFSpells
{
    public partial class GeneratorWindow : Form
    {
        public GeneratorWindow()
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
            progressBar1.Value = 0;
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

            HtmlWeb web = new HtmlWeb();
            List<string> failedSpells = new List<string>();
            for (int i = 0; i < spellNames.Length; i++, progressBar1.Increment(((i + 1) / spellNames.Length) * 100))
            {
                string name = spellNames[i];
                string nameForURL = HttpUtility.UrlEncode(name);
                string url;
                url = "https://aonprd.com/SpellDisplay.aspx?ItemName=" + nameForURL;
                
                

                HtmlAgilityPack.HtmlDocument htmlDoc = web.Load(url);
                HtmlNode spellNode = htmlDoc.DocumentNode.SelectSingleNode("//table[contains(@id, 'ctl00_MainContent_DataListTypes')]");
                
                if (spellNode == null)
                {
                    nameForURL = name.ToLower();
                    var levelReplacements = new Dictionary<string, int>();
                    levelReplacements.Add("i", 1);
                    levelReplacements.Add("ii", 2);
                    levelReplacements.Add("iii", 3);
                    levelReplacements.Add("iv", 4);
                    levelReplacements.Add("v", 5);
                    levelReplacements.Add("vi", 6);
                    levelReplacements.Add("vii", 7);
                    levelReplacements.Add("viii", 8);
                    levelReplacements.Add("ix", 9);
                    foreach (var level in levelReplacements)
                    { 
                        if (nameForURL.Contains(level.Key))
                        {
                            nameForURL = nameForURL.Remove(nameForURL.IndexOf(level.Key), level.Key.Length).Insert(nameForURL.IndexOf(level.Key),level.Value.ToString());
                            break;
                        }
                    }

                    url = "https://aonprd.com/SpellDisplay.aspx?ItemName=" +nameForURL;
                    htmlDoc = web.Load(url);
                    spellNode = htmlDoc.DocumentNode.SelectSingleNode("//table[contains(@id, 'ctl00_MainContent_DataListTypes')]");
                    if (spellNode == null)
                    {
                        failedSpells.Add(name);
                        continue;
                    }
                }
                writer.WriteLine("<h1 class=\"spell-name\" onclick=\"show(" + i + ")\">" + name + "</h1>");
                writer.WriteLine("<div id=" + i + ">");
                spellNode.WriteTo(writer);
                writer.WriteLine("</div>");
            }

            writer.WriteLine("</body>");
            writer.WriteLine("</html>");

            ErrorWindow w = new ErrorWindow(failedSpells);
            if (failedSpells.Count > 0)
                w.Show(); w.Focus();

            var addr = @"./chars/" + charName + ".html";
            Directory.CreateDirectory(@"./chars/");
            File.WriteAllText(addr, writer.ToString());
            if (checkBox1.Checked)
            {
                string fullpath = new FileInfo(addr).FullName;
                System.Diagnostics.Process.Start("file:///" + fullpath);
            }
            button1.Enabled = true;
            Cursor.Current = Cursors.Default;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
