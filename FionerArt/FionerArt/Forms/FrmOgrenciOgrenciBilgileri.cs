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
    public partial class FrmOgrenciOgrenciBilgileri : Form
    {
        public FrmOgrenciOgrenciBilgileri()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public int kursiyerID;
        

      
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

            if (chcSifreKontrol.Checked && TxtSifre.Text != "")
            {
                SqlCommand komut2 = new SqlCommand("update Tbl_KursiyerSifre set Sifre=@p1 where KursiyerID=@p2", bgl.Baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtSifre.Text);
                komut2.Parameters.AddWithValue("@p2", txtId.Text);
                komut2.ExecuteNonQuery();
                MessageBox.Show("Şifre bilgisi güncellendi. Yeni şifre: " + TxtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            bgl.Baglanti().Close();

            MessageBox.Show("Kursiyer bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
    
        }

        private void FrmOgrenciOgrenciBilgileri_Load(object sender, EventArgs e)
        {
            KisiselBilgileriGetir();
            KurslariGetir();
        }
        private void KisiselBilgileriGetir()
        {
            DataTable dt = new DataTable();

            // SqlCommand oluşturuluyor
            SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Kursiyerler WHERE KursiyerID = @p1", bgl.Baglanti());

            // Parametre ekleniyor (örnek olarak KursiyerID = 1 verilmiştir)
            command.Parameters.AddWithValue("@p1", kursiyerID);  // Buraya dinamik değer verebilirsiniz

            // SqlDataAdapter'a komut atanıyor
            SqlDataAdapter da = new SqlDataAdapter(command);

            // DataTable dolduruluyor
            da.Fill(dt);

            // GridControl'e veri atanıyor
            gridControl2.DataSource = dt;
        }
        private void BilgileriKartaEkle()
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
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
        private void KurslariGetir()
        {
            SqlCommand komut = new SqlCommand(
                "SELECT k.KursAdi " +
                "FROM Tbl_KursiyerVeEgitmen ke " +
                 "INNER JOIN Tbl_Kurslar k ON ke.KursID = k.KursID " +
                 "WHERE ke.KursiyerID = @p1",
                 bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", kursiyerID);

            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            BilgileriKartaEkle();
        }

        private void gridView2_Click(object sender, EventArgs e)
        {
            
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            BilgileriKartaEkle();
        }

    }
}
