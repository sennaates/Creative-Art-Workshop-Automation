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

namespace FionerArt.Forms
{
    public partial class FrmYoneticiOdeme : Form
    {
        public FrmYoneticiOdeme()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Odeme", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select Bakiye From Tbl_Hazinemiz", bgl.Baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        private void FrmYoneticiOdeme_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Temizle()
        {
            TxtKursiyerId.Text="";
            TxtTutar.Text="";
            mskdTxtOdemeTaihi.Text="";
            TxtDurumu.Text="";

        }


        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Odeme(KursiyerID,Tutar,OdemeDurumu) values (@p1,@p2,@p3)", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKursiyerId.Text);
            komut.Parameters.AddWithValue("@p2", TxtTutar.Text);
            komut.Parameters.AddWithValue("@p3", TxtDurumu.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Ödeme Alındı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            textEdit4.Text = dr["OdemeID"].ToString();
            TxtKursiyerId.Text = dr["KursiyerID"].ToString();
            TxtTutar.Text = dr["Tutar"].ToString();
            mskdTxtOdemeTaihi.Text = dr["OdemeTarihi"].ToString();
            TxtDurumu.Text = dr["OdemeDurumu"].ToString();
  
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Odeme set KursiyerID=@P1,Tutar=@P2,OdemeDurumu=@P3 where OdemeID=@p4)", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKursiyerId.Text);
            komut.Parameters.AddWithValue("@p2", TxtTutar.Text);
            komut.Parameters.AddWithValue("@p3", TxtDurumu.Text);
            komut.Parameters.Add("@4", textEdit4.Text);
            komut.ExecuteNonQuery();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Odeme where OdemeID=@p1 ", bgl.Baglanti());
            komutsil.Parameters.AddWithValue("@p1", textEdit4.Text);
            komutsil.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Odeme silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnHazineGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Hazinemiz set Bakiye=@p1 where Numara=1", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", Decimal.Parse(TxtYeniBakiye.Text));
            komut.ExecuteNonQuery();
            MessageBox.Show("Bakiye güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
