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
    public partial class FrmOgrenciDuyurular : Form
    {
        public FrmOgrenciDuyurular()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Duyurular", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmOgrenciDuyurular_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
