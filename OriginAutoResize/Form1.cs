using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace OriginAutoResize
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Origin\\";
            openFileDialog1.InitialDirectory = path;

            if (openFileDialog1.ShowDialog() == DialogResult.OK) { 
                String xmlfile = openFileDialog1.FileName;
                XmlDocument doc = new XmlDocument();
                doc.Load(xmlfile);

                IEnumerator ie = doc.SelectNodes("/Settings/Setting").GetEnumerator();

                while (ie.MoveNext())
                {
                if ((ie.Current as XmlNode).Attributes["key"].Value == "AppSizePosition")
                {
                    (ie.Current as XmlNode).Attributes.RemoveAll();
                }
                else if ((ie.Current as XmlNode).Attributes["key"].Value == "ChatSizePosition")
                {
                    (ie.Current as XmlNode).Attributes.RemoveAll();
                }
                else if ((ie.Current as XmlNode).Attributes["key"].Value == "FriendsListSizePosition")
                {
                    (ie.Current as XmlNode).Attributes.RemoveAll();
                }
            }

            doc.Save(xmlfile);

            toolStripStatusLabel1.Text = "Done!";
            System.Media.SystemSounds.Exclamation.Play();
            }
        }
    }
}
