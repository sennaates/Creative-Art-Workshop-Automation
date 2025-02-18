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
    public partial class FrmYoneticiDuyurular : Form
    {
        public FrmYoneticiDuyurular()
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
        void Temizle()
        {
            txtBaslik.Text="";
            txtYayinlayan.Text = "";
            rchTxtBxIcerik.Text = "";
            maskedTextBox1.Text="";
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Duyurular(DuyuruBaslik,DuyuruYayinlayan,DuyuruIcerik,DuyuruYayinlanmaTarihi) values (@p1,@p2,@p3,@p4)", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p2", txtYayinlayan.Text);
            komut.Parameters.AddWithValue("@p3", rchTxtBxIcerik.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);

            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Duyuru sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void FrmYoneticiDuyurular_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["DuyuruID"].ToString();
            txtBaslik.Text = dr["DuyuruBaslik"].ToString();
            txtYayinlayan.Text = dr["DuyuruYayinlayan"].ToString();
            rchTxtBxIcerik.Text = dr["DuyuruIcerik"].ToString();
            maskedTextBox1.Text = dr["DuyuruYayinlanmaTarihi"].ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Duyurular where DuyuruID=@p1 ", bgl.Baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Duyuru silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Duyurular set DuyuruBaslik=@P1,DuyuruYayinlayan=@P2,DuyuruIcerik=@P3,DuyuruYayinlanmaTarihi=@P4 where DuyuruID=@P5 ", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtBaslik.Text);
            komut.Parameters.AddWithValue("@p2", txtYayinlayan.Text);
            komut.Parameters.AddWithValue("@p3", rchTxtBxIcerik.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.Add("@p5", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Duyurular güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
    }
}
