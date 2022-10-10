using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotePad
{
    public partial class Form1 : Form
    {
        bool isBold=false;
        bool isItalic = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<int> fontsize = new List<int>();
            for(int i=8; i < 30;i+=2)
            {
                fontsize.Add(i);
            }
            fontsize.Add(36);
            fontsize.Add(48);
            fontsize.Add(72);
            cboFonts.DataSource = fontsize;
            cboFonts.SelectedItem = fontsize[2];
            cboFamily.DataSource = FontFamily.Families;
            cboFamily.DisplayMember="Name";
            cboFamily.SelectedItem = FontFamily.Families[0];
        }

        private void btnBold_Click(object sender, EventArgs e)
        {
            if(! isBold)
            {
                txtWriteParagraph.Font = new Font(txtWriteParagraph.Font,FontStyle.Bold);
            }
            if(isBold)
            {
                txtWriteParagraph.Font = new Font(txtWriteParagraph.Font, FontStyle.Regular);
            }
            isBold = !isBold;
        }
        private void txtWriteParagraph_TextChanged(object sender, EventArgs e)
        {

        }
        private void btnItalic_Click(object sender, EventArgs e)
        {
            if (!isItalic)
            {
                txtWriteParagraph.Font = new Font(txtWriteParagraph.Font, FontStyle.Italic);
            }
            if (isItalic)
            {
                txtWriteParagraph.Font = new Font(txtWriteParagraph.Font, FontStyle.Regular);
            }
            isItalic = !isItalic;
        }
        private void cboFamily_SelectedValueChanged(object sender, EventArgs e)
        {
            Font myfont = new Font(cboFamily.Text, int.Parse(cboFonts.Text));
            txtWriteParagraph.Font = myfont;
        }

        private void cboFonts_SelectedValueChanged(object sender, EventArgs e)
        {
            txtWriteParagraph.Font = new Font(txtWriteParagraph.Font.FontFamily, int.Parse(cboFonts.SelectedItem.ToString()), txtWriteParagraph.Font.Style);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string path = "D:\\2nd Semester\\OOP\\NotePad\\NotePad Data.txt";
            StreamWriter file = new StreamWriter(path);
            file.Write(txtWriteParagraph.Text);
            file.Close();
        }
    }
}
