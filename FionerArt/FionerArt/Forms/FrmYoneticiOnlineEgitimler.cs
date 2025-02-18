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
    public partial class FrmYoneticiOnlineEgitimler : Form
    {
        public FrmYoneticiOnlineEgitimler()
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

        void Temizle()
        {
            textEdit4.Text="";
            textEdit3.Text="";
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into Tbl_EgitimLink(Baslik,URL) values (@p1,@p2)", bgl.Baglanti());
            
            komut2.Parameters.AddWithValue("@p1", textEdit4.Text);
            komut2.Parameters.AddWithValue("@p2", textEdit3.Text);
            komut2.ExecuteNonQuery();
            bgl.Baglanti().Close();

            MessageBox.Show("Eğitim sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_EgitimLink where LinkID=@p1 ", bgl.Baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Eğitim silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["LinkID"].ToString();
            textEdit4.Text = dr["Baslik"].ToString();
            textEdit3.Text = dr["URL"].ToString();
            
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_EgitimLink set Baslik=@P1,URL=@P2 where LinkID=@P3", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", textEdit4.Text);
            komut.Parameters.AddWithValue("@p2", textEdit3.Text);
            komut.Parameters.Add("@p3", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Eğitim bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void FrmYoneticiOnlineEgitimler_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
