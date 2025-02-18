using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FionerArt.Forms
{
    public partial class FrmOgrenciBizeUlasin : Form
    {
        public FrmOgrenciBizeUlasin()
        {
            InitializeComponent();
        }
        MailSender mailSender = new MailSender();
        private void BtnBizeUlasin_Click(object sender, EventArgs e)
        {
            mailSender.MailYollamaIslemiBizeUlasin(richTextBox1.Text);
        }
    }
}
