using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FionerArt.Forms
{
    public partial class FrmOgrenciOnlineEgitimler : Form
    {
        public FrmOgrenciOnlineEgitimler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_EgitimLink", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void FrmOgrenciOnlineEgitimler_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
