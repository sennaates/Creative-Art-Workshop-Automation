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
using System.Diagnostics;

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
            string query = @"
        SELECT 
            o.OdemeID, 
            k.KursiyerID,
            k.Ad AS [Kursiyer Adı], 
            k.Soyad AS [Kursiyer Soyadı], 
            k.TcKimlikNo AS [TC Kimlik No], 
            o.Tutar, 
            o.OdemeTarihi, 
            o.OdemeDurumu
        FROM 
            Tbl_Odeme o
        INNER JOIN 
            Tbl_Kursiyerler k ON o.KursiyerID = k.KursiyerID";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, bgl.Baglanti());
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select Bakiye From Tbl_Hazinemiz", bgl.Baglanti());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }
        // ComboBox'a Kursiyer Adı ve TC No yükleme
        void ComboBoxDoldur()
        {


            string query = "SELECT KursiyerID, Ad + ' ' + Soyad + ' - ' + TcKimlikNo AS KursiyerBilgi FROM Tbl_Kursiyerler";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, bgl.Baglanti());
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            cmbKursiyer.DataSource = dataTable;
            cmbKursiyer.DisplayMember = "KursiyerBilgi";  // Görünen kısım: Adı Soyadı - TC No
            cmbKursiyer.ValueMember = "KursiyerID";      // Arka planda tutulan değer: Kursiyer ID
            cmbKursiyer.SelectedIndex = -1;              // Başlangıçta boş gelsin

        }
        private void FrmYoneticiOdeme_Load(object sender, EventArgs e)
        {
            ComboBoxDoldur();  // ComboBox'a kursiyerleri yükle
            GridVeriGetir(0);  // Başlangıçta tüm verileri göster
            Listele();
        }
        void Temizle()
        {
            TxtKursiyerId.Text = "";
            TxtTutar.Text = "";
            mskdTxtOdemeTaihi.Text = "";
            TxtDurumu.Text = "";

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
            SqlCommand komut = new SqlCommand("update Tbl_Odeme set KursiyerID=@P1,Tutar=@P2 where OdemeID=@p4)", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtKursiyerId.Text);
            komut.Parameters.AddWithValue("@p2", TxtTutar.Text);
            komut.Parameters.AddWithValue("@p3", TxtDurumu.Text);
            
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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            // PDF'yi dışa aktar
            DevExpress.XtraGrid.Views.Grid.GridView View = gridControl1.MainView as DevExpress.XtraGrid.Views.Grid.GridView;
            if (View != null)
            {
                string pdfPath = "OdemeFaturaOzetiFioner.pdf";
                View.ExportToPdf(pdfPath);

                // PDF'yi varsayılan PDF görüntüleyici ile aç
                Process.Start(new ProcessStartInfo
                {
                    FileName = pdfPath,
                    UseShellExecute = true // Bu ayar varsayılan programla açmayı sağlar
                });
            }
        }

        private void cmbKursiyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKursiyer.SelectedValue != null && cmbKursiyer.SelectedValue is int)
            {
                int selectedKursiyerID = (int)cmbKursiyer.SelectedValue;
                GridVeriGetir(selectedKursiyerID);
            }
        }
        // Seçilen KursiyerID'ye göre DataGridView'i güncelle
        void GridVeriGetir(int kursiyerID)
        {
            
            string query = @"
            SELECT 
                o.OdemeID, 
                k.KursiyerID,
                k.Ad AS [Kursiyer Adı], 
                k.Soyad AS [Kursiyer Soyadı], 
                k.TcKimlikNo AS [TC Kimlik No], 
                o.Tutar, 
                o.OdemeTarihi, 
                o.OdemeDurumu
            FROM 
                Tbl_Odeme o
            INNER JOIN 
                Tbl_Kursiyerler k ON o.KursiyerID = k.KursiyerID
            WHERE 
                k.KursiyerID = @KursiyerID";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, bgl.Baglanti());
                dataAdapter.SelectCommand.Parameters.AddWithValue("@KursiyerID", kursiyerID);

                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                gridControl1.DataSource = dataTable;
            
        }
    }
}
