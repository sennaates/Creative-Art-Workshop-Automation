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

namespace FionerArt
{
    public partial class FrmYoneticiNotlar : Form
    {
        public FrmYoneticiNotlar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Notlar", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmYoneticiNotlar_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Temizle()
        {
            MskTarih.Text="";
            MskSaat.Text = "";
            txtBaslik.Text = "";
            txtOlusturan.Text = "";
           
            RchDetay.Text = "";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Notlar(NOTTARİH,NOTSAAT,NOTBASLIK,NOTOLUSTURAN,NOTDETAY) values (@p1,@p2,@p3,@p4,@p5)", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", MskTarih.Text);
            komut.Parameters.AddWithValue("@p2", MskSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p5", RchDetay.Text);

            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Not sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["NotID"].ToString();
            MskTarih.Text = dr["NOTTARİH"].ToString();
            MskSaat.Text = dr["NOTSAAT"].ToString();
            txtBaslik.Text = dr["NOTBASLIK"].ToString();
            RchDetay.Text = dr["NOTDETAY"].ToString();
            txtOlusturan.Text = dr["NOTOLUSTURAN"].ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Notlar where NotID=@p1 ", bgl.Baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Notlar silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Notlar set NOTTARİH=@P1,NOTSAAT=@P2,NOTBASLIK=@P3,NOTDETAY=@P4,NOTOLUSTURAN=@P5  where NotID=@P6", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", MskTarih.Text);
            komut.Parameters.AddWithValue("@p2", MskSaat.Text);
            komut.Parameters.AddWithValue("@p3", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p4", txtOlusturan.Text);
            komut.Parameters.AddWithValue("@p5", RchDetay.Text);
            komut.Parameters.Add("@p6", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Not bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
    }
}
