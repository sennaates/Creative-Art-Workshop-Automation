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
    public partial class FrmYoneticiKurslar : Form
    {
        public FrmYoneticiKurslar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Kurslar", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void FrmYoneticiKurslar_Load(object sender, EventArgs e)
        {
            Listele();
        }
        void Temizle()
        {
            TxtAdi.Text="";
            TxtKontenjan.Text = "";
            TxtSubeId.Text = "";
            

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Kurslar(KursAdi,Kontenjan,SubeID) values (@p1,@p2,@p3)", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAdi.Text);
            komut.Parameters.AddWithValue("@p2", TxtKontenjan.Text);
            komut.Parameters.AddWithValue("@p3", TxtSubeId.Text);
            
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Kurs sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            textEdit4.Text = dr["KursID"].ToString();
            TxtAdi.Text = dr["KursAdi"].ToString();
            TxtKontenjan.Text = dr["Kontenjan"].ToString();
            TxtSubeId.Text = dr["SubeID"].ToString();
            
            
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Kurslar set KursAdi=@P1,Kontenjan=@P2,SubeID=@P3 where KursID=@P4 ", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAdi.Text);
            komut.Parameters.AddWithValue("@p2", TxtKontenjan.Text);
            komut.Parameters.AddWithValue("@p3", TxtSubeId.Text);
            
            komut.Parameters.Add("@p4", textEdit4.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Eğitmen bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Kurslar where KursID=@p1 ", bgl.Baglanti());
            komutsil.Parameters.AddWithValue("@p1", textEdit4.Text);
            komutsil.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Kurs silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
