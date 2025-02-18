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
    public partial class FrmYoneticiEgitmenler : Form
    {
        public FrmYoneticiEgitmenler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Egitmenler", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void Temizle()
        {
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TxtEmail.Text = "";
            TxtTelefon.Text = "";
            TxtTcKimlikNo.Text = "";
            MskTarih.Text = "";
            RchTxtBxAdres.Text = "";
            PctrFtgrf.Text = "";
            TxtOkul.Text = "";
            TxtBolum.Text = "";
            RchTxtBxYetenekleri.Text = "";
            TxtSubeId.Text = "";
        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void textEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("insert into Tbl_Egitmenler(Ad,Soyad,Email,Telefon,TcKimlikNo,DogumTarihi,Adres,Fotograf,MezunOlduguOkul,MezunOlduguBolum,Yetenekleri,SubeID) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", TxtEmail.Text);
            komut.Parameters.AddWithValue("@p4", TxtTelefon.Text);
            komut.Parameters.AddWithValue("@p5", TxtTcKimlikNo.Text);
            komut.Parameters.AddWithValue("@p6", MskTarih.Text);
            komut.Parameters.AddWithValue("@p7", RchTxtBxAdres.Text);
            komut.Parameters.AddWithValue("@p8", PctrFtgrf.Text);
            komut.Parameters.AddWithValue("@p9", TxtOkul.Text);
            komut.Parameters.AddWithValue("@p10", TxtBolum.Text);
            komut.Parameters.AddWithValue("@p11", RchTxtBxYetenekleri.Text);
            komut.Parameters.AddWithValue("@p12", TxtSubeId.Text);

            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();

            MessageBox.Show("Eğitmen sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
            
        }

        private void FrmYoneticiEgitmenler_Load(object sender, EventArgs e)
        {
            Listele();
            
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["EgitmenID"].ToString();
            TxtAd.Text = dr["Ad"].ToString();
            TxtSoyad.Text = dr["Soyad"].ToString();
            TxtEmail.Text = dr["Email"].ToString();
            TxtTelefon.Text = dr["Telefon"].ToString();
            TxtTcKimlikNo.Text = dr["TcKimlikNo"].ToString();
            MskTarih.Text = dr["DogumTarihi"].ToString();
            RchTxtBxAdres.Text = dr["Adres"].ToString();
            PctrFtgrf.Text = dr["Fotograf"].ToString();
            TxtOkul.Text = dr["MezunOlduguOkul"].ToString();
            TxtBolum.Text = dr["MezunOlduguBolum"].ToString();
            RchTxtBxYetenekleri.Text = dr["Yetenekleri"].ToString();
            TxtSubeId.Text = dr["SubeID"].ToString();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Egitmenler where EgitmenID=@p1 ", bgl.Baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Eğitmen silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Egitmenler set Ad=@P1,Soyad=@P2,Email=@P3,Telefon=@P4,TcKimlikNo=@P5,DogumTarihi=@P6,Adres=@P7,Fotograf=@P8,MezunOlduguOkul=@P9,MezunOlduguBolum=@P10,Yetenekleri=@P11 ,SubeID=@P12 where EgitmenID=@P13", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", TxtEmail.Text);
            komut.Parameters.AddWithValue("@p4", TxtTelefon.Text);
            komut.Parameters.AddWithValue("@p5", TxtTcKimlikNo.Text);
            komut.Parameters.AddWithValue("@p6", MskTarih.Text);
            komut.Parameters.AddWithValue("@p7", RchTxtBxAdres.Text);
            komut.Parameters.AddWithValue("@p8", PctrFtgrf.Text);
            komut.Parameters.AddWithValue("@p9", TxtOkul.Text);
            komut.Parameters.AddWithValue("@p10", TxtBolum.Text);
            komut.Parameters.AddWithValue("@p11", RchTxtBxYetenekleri.Text);
            komut.Parameters.AddWithValue("@p12", TxtSubeId.Text);
            komut.Parameters.Add("@p13", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Eğitmen bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();

        }
    }
}
