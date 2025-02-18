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
    public partial class FrmYoneticiKursiyerler : Form
    {
        public FrmYoneticiKursiyerler()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Kursiyerler", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void labelControl8_Click(object sender, EventArgs e)
        {

        }
        void Temizle()
        {
            TxtAd.Text="";
            TxtSoyad.Text = "";
            TxtEmail.Text = "";
            TxtTelefon.Text = "";
            TxtKatilimTarihi.Text = "";
            PctrFtgrf.Text = "";
            TxtDogumTarihi.Text = "";
            TxtTcKimlikNo.Text = "";
            RchTxtBxAdres.Text = "";
            TxtSifre.Text="";
            txtId.Text="";


        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Kursiyerler (Ad, Soyad, Email, Telefon, KullaniciTipi, KayitTarihi, Fotograf, DogumTarihi, TcKimlikNo, Adres) " +
                                  "VALUES (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10)", bgl.Baglanti());

            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", TxtEmail.Text);
            komut.Parameters.AddWithValue("@p4", TxtTelefon.Text);
            komut.Parameters.AddWithValue("@p5", "kursiyer");  // KullaniciTipi doğrudan parametre olarak eklendi
            komut.Parameters.AddWithValue("@p6", TxtKatilimTarihi.Text);
            komut.Parameters.AddWithValue("@p7", PctrFtgrf.Text);
            komut.Parameters.AddWithValue("@p8", TxtDogumTarihi.Text);
            komut.Parameters.AddWithValue("@p9", TxtTcKimlikNo.Text);
            komut.Parameters.AddWithValue("@p10", RchTxtBxAdres.Text);

            komut.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("select KursiyerID from Tbl_Kursiyerler where TcKimlikNo =@p1", bgl.Baglanti());
            komut2.Parameters.AddWithValue("@p1", TxtTcKimlikNo.Text);
            int yeniKursiyerID = Convert.ToInt32(komut2.ExecuteScalar());

            SqlCommand komut3 = new SqlCommand("insert into Tbl_KursiyerSifre(KullaniciAdi,Sifre,KursiyerID) values (@p1,@p2,@p3)", bgl.Baglanti());
            komut3.Parameters.AddWithValue("@p1", TxtKullaniciAdi.Text);
            komut3.Parameters.AddWithValue("@p2", TxtSifre.Text);
            komut3.Parameters.AddWithValue("@p3", yeniKursiyerID);
            komut3.ExecuteNonQuery();


            SqlCommand komut4 = new SqlCommand("INSERT INTO Tbl_Sorgular(KursiyerID, SorguSayisi) VALUES (@p1, 0)", bgl.Baglanti());
            komut4.Parameters.AddWithValue("@p1", yeniKursiyerID);
            komut4.ExecuteNonQuery();

            SqlCommand komut5 = new SqlCommand("INSERT INTO Tbl_CizimFikri(KursiyerID, FikirAlmaSayisi) VALUES (@p1, 0)", bgl.Baglanti());
            komut5.Parameters.AddWithValue("@p1", yeniKursiyerID);
            komut5.ExecuteNonQuery();
            bgl.Baglanti().Close();

            MessageBox.Show("Kursiyer sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void FrmYoneticiKursiyerler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["KursiyerID"].ToString();
            TxtAd.Text = dr["Ad"].ToString();
            TxtSoyad.Text = dr["Soyad"].ToString();
            TxtEmail.Text = dr["Email"].ToString();
            TxtTelefon.Text = dr["Telefon"].ToString();
            TxtKatilimTarihi.Text = dr["KayitTarihi"].ToString();
            TxtDogumTarihi.Text = dr["DogumTarihi"].ToString();
            TxtTcKimlikNo.Text = dr["TcKimlikNo"].ToString();
            RchTxtBxAdres.Text = dr["Adres"].ToString();
            PctrFtgrf.Text = dr["Fotograf"].ToString();
        }
        
        private void BtnSil_Click(object sender, EventArgs e)
        {
            // İlk olarak Tbl_KursiyerSifre tablosundan sil
            SqlCommand sifreSil = new SqlCommand("DELETE FROM Tbl_KursiyerSifre WHERE KursiyerID = @p1", bgl.Baglanti());
            sifreSil.Parameters.AddWithValue("@p1", txtId.Text);
            sifreSil.ExecuteNonQuery();
            bgl.Baglanti().Close();

            // Ardından Tbl_Kursiyerler tablosundan sil
            SqlCommand kursiyerSil = new SqlCommand("DELETE FROM Tbl_Kursiyerler WHERE KursiyerID = @p1", bgl.Baglanti());
            kursiyerSil.Parameters.AddWithValue("@p1", txtId.Text);
            kursiyerSil.ExecuteNonQuery();
            bgl.Baglanti().Close();

            MessageBox.Show("Kursiyer başarıyla silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
        
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Kursiyerler set Ad=@P1,Soyad=@P2,Email=@P3,Telefon=@P4,KayitTarihi=@P5,Fotograf=@P6,DogumTarihi=@P7,TcKimlikNo=@P8,Adres=@P9 where KursiyerID=@P10", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", TxtEmail.Text);
            komut.Parameters.AddWithValue("@p4", TxtTelefon.Text);
            komut.Parameters.AddWithValue("@p5", TxtKatilimTarihi.Text);
            komut.Parameters.AddWithValue("@p6", PctrFtgrf.Text);
            komut.Parameters.AddWithValue("@p7", TxtDogumTarihi.Text);
            komut.Parameters.AddWithValue("@p8", TxtTcKimlikNo.Text);
            komut.Parameters.AddWithValue("@p9", RchTxtBxAdres.Text);
            komut.Parameters.Add("@p10", txtId.Text); 
            komut.ExecuteNonQuery();

            bgl.Baglanti().Close(); 

            MessageBox.Show("Kursiyer bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }
    }
}
