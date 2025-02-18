using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace FionerArt.Forms
{
    public partial class FrmYoneticiSubeler : Form
    {
        public FrmYoneticiSubeler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Sube", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmYoneticiSubeler_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Temizle()
        {
            txtAdi.Text="";
            richtxtAdres.Text ="";
            txtKonumKoordinati.Text="";
            mskdTarih.Text="";
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Sube(SubeAdi,Adres,KonumKoordinat,AcilisTarihi) values (@p1,@p2,@p3,@p4)", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAdi.Text);
            komut.Parameters.AddWithValue("@p2", richtxtAdres.Text);
            komut.Parameters.AddWithValue("@p3", txtKonumKoordinati.Text);
            komut.Parameters.AddWithValue("@p4", mskdTarih.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Şube sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            textEdit4.Text = dr["SubeID"].ToString();
            txtAdi.Text=dr["SubeAdi"].ToString();
            richtxtAdres.Text=dr["Adres"].ToString();
            txtKonumKoordinati.Text= dr["KonumKoordinat"].ToString();
            mskdTarih.Text = dr["AcilisTarihi"].ToString();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Sube set SubeAdi=@P1,Adres=@P2,KonumKoordinat=@P3,AcilisTarihi=@P4 where SubeID=@P5", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAdi.Text);
            komut.Parameters.AddWithValue("@p2", richtxtAdres.Text);
            komut.Parameters.AddWithValue("@p3", txtKonumKoordinati.Text);
            komut.Parameters.AddWithValue("@p4", mskdTarih.Text);
            komut.Parameters.Add("@p5", textEdit4.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Şube bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Sube where SubeID=@p1 ", bgl.Baglanti());
            komutsil.Parameters.AddWithValue("@p1", textEdit4.Text);
            komutsil.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Ürün silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();

        }
    }
}
