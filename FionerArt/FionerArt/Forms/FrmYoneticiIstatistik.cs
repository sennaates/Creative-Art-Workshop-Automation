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
    public partial class FrmYoneticiIstatistik : Form
    {
        public FrmYoneticiIstatistik()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        private void labelControl18_Click(object sender, EventArgs e)
        {

        }

        private void pictureEdit8_EditValueChanged(object sender, EventArgs e)
        {

        }


        private void FrmYoneticiIstatistik_Load(object sender, EventArgs e)
        {
            VerileriDoldur();
        }
        private void VerileriDoldur()
        {
            SqlCommand command = new SqlCommand("SELECT COUNT(DISTINCT Kategori) FROM Tbl_Malzeme", bgl.Baglanti());
            int distinctCount = (int)command.ExecuteScalar();
            labelControl27.Text = distinctCount.ToString();

            SqlCommand command2 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Kursiyerler", bgl.Baglanti());
            int kursiyerSayisi = (int)command2.ExecuteScalar();
            labelControl19.Text = kursiyerSayisi.ToString();

            SqlCommand command3 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Kurslar", bgl.Baglanti());
            int kursSayisi = (int)command3.ExecuteScalar();
            labelControl20.Text = kursSayisi.ToString();

            SqlCommand command4 = new SqlCommand("SELECT COUNT(DISTINCT OdemeID) FROM Tbl_Odeme", bgl.Baglanti());
            int odemeYapanKisiSayisi = (int)command4.ExecuteScalar();
            labelControl23.Text = odemeYapanKisiSayisi.ToString();


            
            SqlCommand command6 = new SqlCommand("SELECT MalzemeAdi FROM Tbl_Malzeme WHERE StokAdedi = (SELECT MIN(StokAdedi) FROM Tbl_Malzeme)", bgl.Baglanti());

            string malzemeAdi = (string)command6.ExecuteScalar();
            labelControl21.Text = malzemeAdi;



            SqlCommand command5 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Egitmenler", bgl.Baglanti());
            int egitmenSayisi = (int)command5.ExecuteScalar();
            labelControl22.Text = egitmenSayisi.ToString();

            SqlCommand command7 = new SqlCommand("SELECT Bakiye FROM Tbl_Hazinemiz WHERE Numara=1", bgl.Baglanti());
            decimal hazine = (decimal)command7.ExecuteScalar();
            labelControl32.Text = hazine.ToString();

          

            SqlCommand command9 = new SqlCommand("SELECT COUNT(*) FROM Tbl_EgitimLink", bgl.Baglanti());
            int linkSayisi = (int)command9.ExecuteScalar();
            labelControl25.Text = linkSayisi.ToString();

            // Toplam kursiyer sayısını al
            SqlCommand totalKursiyerCommand = new SqlCommand("SELECT COUNT(*) FROM Tbl_Kursiyerler", bgl.Baglanti());
            int toplamKursiyerSayisi = (int)totalKursiyerCommand.ExecuteScalar();

            // Ödeme yapan kursiyer sayısını al
            SqlCommand odemeYapanKisiCommand = new SqlCommand("SELECT COUNT(DISTINCT OdemeID) FROM Tbl_Odeme", bgl.Baglanti());
            int odemeler = (int)odemeYapanKisiCommand.ExecuteScalar();
            int odemeYapmayanKursiyerSayisi = toplamKursiyerSayisi - odemeler;
            labelControl26.Text = odemeYapmayanKursiyerSayisi.ToString();

            SqlCommand command11 = new SqlCommand("SELECT MalzemeAdi FROM Tbl_Malzeme WHERE StokAdedi = (SELECT MAX(StokAdedi) FROM Tbl_Malzeme)", bgl.Baglanti());
            string malzemeAdii = (string)command11.ExecuteScalar();
            labelControl24.Text = malzemeAdii;

            SqlCommand command12 = new SqlCommand("SELECT TOP 1 KursAdi FROM Tbl_Kurslar ORDER BY Kontenjan DESC", bgl.Baglanti());

            object result = command12.ExecuteScalar();

            // Sonucu kontrol et ve label'a yaz
            if (result != null)
            {
                labelControl18.Text = result.ToString();
            }
            else
            {
                labelControl18.Text = "No courses found.";
            }

            SqlCommand command14 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Notlar", bgl.Baglanti());
            int toplamNotSayisi = (int)command14.ExecuteScalar();
            labelControl31.Text = toplamNotSayisi.ToString();

            SqlCommand command15 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Personel", bgl.Baglanti());
            int toplamPersonelSayisi = (int)command15.ExecuteScalar();
            labelControl33.Text = toplamPersonelSayisi.ToString();

            SqlCommand command16 = new SqlCommand("SELECT TOP 1 KursiyerID, COUNT(*) AS SoruSayisi FROM Tbl_Sorgular GROUP BY KursiyerID ORDER BY SoruSayisi DESC", bgl.Baglanti());
            SqlDataReader reader = command16.ExecuteReader();

            if (reader.Read())
            {
                string enCokKonusanKullanici = reader["KursiyerID"].ToString();
                labelControl28.Text = enCokKonusanKullanici;
            }

            //SqlCommand command17 = new SqlCommand("SELECT COUNT(*) FROM Tbl_Sorgular", bgl.Baglanti());
            //int toplamKonusmaSayisi = (int)command17.ExecuteScalar();
            //labelControl29.Text = toplamKonusmaSayisi.ToString();

            SqlCommand command17 = new SqlCommand("SELECT SUM(SorguSayisi) AS ToplamSoruSayisi FROM Tbl_Sorgular", bgl.Baglanti());
            object sorguSayisiToplam = command17.ExecuteScalar();
            labelControl29.Text = sorguSayisiToplam.ToString();

            SqlCommand command18 = new SqlCommand("SELECT SUM(FikirAlmaSayisi) AS ToplamFikirSayisi FROM Tbl_CizimFikri", bgl.Baglanti());
            object cizimSayisiToplam = command18.ExecuteScalar();
            labelControl30.Text = cizimSayisiToplam.ToString();
        }
    }
}
