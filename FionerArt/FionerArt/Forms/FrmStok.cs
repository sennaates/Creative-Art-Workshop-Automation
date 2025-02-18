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
    public partial class FrmStok : Form
    {
        public FrmStok()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Malzeme", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            txtAdi.Text="";
            txtKategori.Text = "";
            txtStok.Text = "";
            txtMinimumStok.Text = "";
            txtId.Text = "";
        }
        private void FrmStok_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
                SqlCommand komut = new SqlCommand("insert into Tbl_Malzeme(MalzemeAdi,Kategori,StokAdedi,MinimumStok) values (@p1,@p2,@p3,@p4)", bgl.Baglanti());
                komut.Parameters.AddWithValue("@p1", txtAdi.Text);
                komut.Parameters.AddWithValue("@p2", txtKategori.Text);
                komut.Parameters.AddWithValue("@p3", txtStok.Text);
                komut.Parameters.AddWithValue("@p4", txtMinimumStok.Text);
                komut.ExecuteNonQuery();
                bgl.Baglanti().Close();
            
                MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["MalzemeID"].ToString();
            txtAdi.Text = dr["MalzemeAdi"].ToString();
            txtKategori.Text = dr["Kategori"].ToString();
            txtStok.Text = dr["StokAdedi"].ToString();
            txtMinimumStok.Text = dr["MinimumStok"].ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Malzeme where txtId=@p1 ", bgl.Baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Stoktan kaldırıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Malzeme set MalzemeAdi=@P1,Kategori=@P2,StokAdedi=@P3,MinimumStok=@P4 where MalzemeID=@P5", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", txtAdi.Text);
            komut.Parameters.AddWithValue("@p2", txtKategori.Text);
            komut.Parameters.AddWithValue("@p3", txtStok.Text);
            komut.Parameters.AddWithValue("@p4", txtMinimumStok.Text);
            komut.Parameters.Add("@p5", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Stok bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
    }
}
