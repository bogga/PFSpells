using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Web;

namespace PFSpells
{
    public partial class GeneratorWindow : Form
    {
        enum DataSource
        {
            AoN,
            D20
        }

        public GeneratorWindow()
        {
            InitializeComponent();
        }

        private StringWriter writer;
        private List<string> failedSpells;
        private HtmlWeb web;
        private string[] spellNames;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void InsertHead()
        {
            if (d20Radio.Checked)
            {
                writer.WriteLine("<link rel='stylesheet' id='ogncustom-css-css'  href='https://www.d20pfsrd.com/wp-content/plugins/ogncustom/css/ogncustom.css?ver=1551434665' type='text/css' media='all' />");
                writer.WriteLine("<link rel='stylesheet' id='toc-screen-css'  href='https://www.d20pfsrd.com/wp-content/plugins/table-of-contents-plus/screen.min.css?ver=1509' type='text/css' media='all' />");
                writer.WriteLine("<link rel='stylesheet' id='quickstrap-css'  href='https://www.d20pfsrd.com/wp-content/themes/quickstrap/style.css?ver=741751694b0c23cb369738b3058aae5a' type='text/css' media='all' />");
                writer.WriteLine("<link rel='stylesheet' id='child-style-css'  href='https://www.d20pfsrd.com/wp-content/themes/srdtheme/css/style.css?ver=1.5.2.7' type='text/css' media='all' />");
                writer.WriteLine("<link rel='stylesheet' id='quickstrap-bootstrap-css'  href='https://www.d20pfsrd.com/wp-content/themes/quickstrap/css/bootstrap.min.css?ver=3.3.6' type='text/css' media='all' />");
                writer.WriteLine("<link rel='stylesheet' id='child-dynamic-css'  href='https://www.d20pfsrd.com/wp-content/themes/srdtheme/css/sites/12.css?ver=1546817288' type='text/css' media='all' />");
                writer.WriteLine("<link rel='stylesheet' id='quickstrap-fontawesome-css'  href='https://www.d20pfsrd.com/wp-content/themes/quickstrap/font-awesome/css/font-awesome.min.css?ver=4.5.0' type='text/css' media='all' />");
            }

            else
            {
                writer.WriteLine("<link href='https://aonprd.com/Styles/layout.css' rel='stylesheet' type='text/css' />");
                writer.WriteLine("<link href='https://aonprd.com/Styles/typography.css' rel='stylesheet' type='text/css' />");
                writer.WriteLine("<link href='https://fonts.googleapis.com/css?family=Julee' rel='stylesheet' type='text/css' />");
                writer.WriteLine("<link href='http://fonts.googleapis.com/css?family=Julee' rel='stylesheet' type='text/css' />");
            }

            writer.WriteLine("<script>function show(id){var x=document.getElementById(id);if(x.style.display===\"none\"){x.style.display=\"block\"}else{x.style.display=\"none\"}}</script>");
        }

        private void InsertData(string spellName)
        {
            if (d20Radio.Checked)
                InsertDataD20(spellName);
            else
                InsertDataAoN(spellName);
        }

        private void InsertDataD20(string spellName)
        {
            string nameForURL = Regex.Replace(spellName, "[^0-9a-zA-Z'’ ]", "");
            nameForURL = Regex.Replace(nameForURL, "['’ ]", "-");
            string url;
            try
            {
                url = "https://www.d20pfsrd.com/magic/all-spells/" + nameForURL[0] + "/" + nameForURL;
            }
            catch (IndexOutOfRangeException)
            {
                failedSpells.Add(spellName);
                return;
            }
            url = url.ToLower();

            HtmlAgilityPack.HtmlDocument htmlDoc = web.Load(url);
            HtmlNode spellNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'article-content')]");
            if (spellNode == null)
            {
                nameForURL = spellName.ToLower();
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
                if (spellNode == null)
                {
                    failedSpells.Add(spellName);
                    return;
                }
            }

            HtmlNode productNode = htmlDoc.DocumentNode.SelectSingleNode("//div[contains(@class, 'product-right')]");
            if (productNode != null)
                productNode.Remove();

            int id = Array.FindIndex<string>(spellNames, name => name == spellName);
            writer.WriteLine("<h1 class=\"spell-name\" onclick=\"show(" + id + ")\">" + spellName + "</h1>");
            writer.WriteLine("<div id=" + id + ">");
            spellNode.WriteTo(writer);
            writer.WriteLine("</div>");
        }

        private void InsertDataAoN(string spellName)
        {
            string nameForURL = HttpUtility.UrlEncode(spellName);
            string url = "https://aonprd.com/SpellDisplay.aspx?ItemName=" + nameForURL;

            HtmlAgilityPack.HtmlDocument htmlDoc = web.Load(url);
            HtmlNode spellNode = htmlDoc.DocumentNode.SelectSingleNode("//table[contains(@id, 'ctl00_MainContent_DataListTypes')]");

            if (spellNode == null)
            {
                nameForURL = spellName.ToLower();
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
                        nameForURL = nameForURL.Remove(nameForURL.IndexOf(level.Key), level.Key.Length).Insert(nameForURL.IndexOf(level.Key), level.Value.ToString());
                        break;
                    }
                }

                url = "https://aonprd.com/SpellDisplay.aspx?ItemName=" + nameForURL;
                htmlDoc = web.Load(url);
                spellNode = htmlDoc.DocumentNode.SelectSingleNode("//table[contains(@id, 'ctl00_MainContent_DataListTypes')]");
                if (spellNode == null)
                {
                    failedSpells.Add(spellName);
                    return;
                }
            }

            int id = Array.FindIndex<string>(spellNames, name => name == spellName);
            writer.WriteLine("<h1 class=\"spell-name\" onclick=\"show(" + id + ")\">" + spellName + "</h1>");
            writer.WriteLine("<div id=" + id + ">");
            spellNode.WriteTo(writer);
            writer.WriteLine("</div>");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            button1.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            spellNames = textBox1.Lines;
            string charName = textBox2.Lines[0];
            writer = new StringWriter();
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");
            writer.WriteLine("<title>" + charName + "</title>");
            InsertHead();
            writer.WriteLine("</head>");

            if (!d20Radio.Checked)
                if (darkRadio.Checked)
                    writer.WriteLine("<body class=\"dark\">");
                else
                    writer.WriteLine("<body class=\"light\">");
            else
                writer.WriteLine("<body>");

            web = new HtmlWeb();
            failedSpells = new List<string>();
            for (int i = 0; i < spellNames.Length; i++, progressBar1.Increment(((i + 1) / spellNames.Length) * 100))
            {
                InsertData(spellNames[i]);
            }

            writer.WriteLine("</body>");
            writer.WriteLine("</html>");

            ErrorWindow w = new ErrorWindow(failedSpells);
            if (failedSpells.Count > 0)
                w.Show(); w.Focus();

            var addr = @"./chars/" + charName + ".html";
            Directory.CreateDirectory(@"./chars/");
            bool failedAll = failedSpells.Count == spellNames.Length;
            if (!failedAll)
            {
                File.WriteAllText(addr, writer.ToString());
                if (checkBox1.Checked)
                {
                    string fullpath = new FileInfo(addr).FullName;
                    System.Diagnostics.Process.Start("file:///" + fullpath);
                }
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

        private void aonRadio_CheckedChanged(object sender, EventArgs e)
        {
            sourceOptions.Enabled = aonRadio.Checked;
        }
    }
}
