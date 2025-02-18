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
    public partial class FrmYoneticiPersonel : Form
    {
        public FrmYoneticiPersonel()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();

        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Personel", bgl.Baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        
        void Temizle()
        {
            TxtAd.Text="";
            TxtSoyad.Text = "";
            TxtGorev.Text = "";
            TxtMaas.Text = "";
            TxtTelefon.Text = "";
            TxtEmail.Text = "";
            RchTxtBxAdres.Text = "";
            TxtTcKimlikNo.Text = "";
            MskTarih.Text = "";
            txtDurum.Text = "";
            PctrFtgrf.Text = "";
            RchTxtBxBilgi.Text = "";
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel(Ad,Soyad,Gorev,Maas,TelefonNumarasi,EPosta,Adres,TcKimlikNo,DogumTarihi,Durum,Fotograf,Bilgi) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", TxtGorev.Text);
            komut.Parameters.AddWithValue("@p4", TxtMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtTelefon.Text);
            komut.Parameters.AddWithValue("@p6", TxtEmail.Text);
            komut.Parameters.AddWithValue("@p7", RchTxtBxAdres.Text);
            komut.Parameters.AddWithValue("@p8", TxtTcKimlikNo.Text);
            komut.Parameters.AddWithValue("@p9", MskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtDurum.Text);
            komut.Parameters.AddWithValue("@p11", PctrFtgrf.Text);
            komut.Parameters.AddWithValue("@p12", RchTxtBxBilgi.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();

            MessageBox.Show("Personel sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void FrmYoneticiPersonel_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_Personel where ID=@p1 ", bgl.Baglanti());
            komutsil.Parameters.AddWithValue("@p1", txtId.Text);
            komutsil.ExecuteNonQuery();
            bgl.Baglanti().Close();
            MessageBox.Show("Personel silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_Personel set Ad=@P1,Soyad=@P2,Gorev=@P3,Maas=@P4,TelefonNumarasi=@P5,EPosta=@P6,Adres=@P7,TcKimlikNo=@P8,DogumTarihi=@P9,Durum=@P10,Fotograf=@P11 ,Bilgi=@P12 where ID=@P13", bgl.Baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", TxtGorev.Text);
            komut.Parameters.AddWithValue("@p4", TxtMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtTelefon.Text);
            komut.Parameters.AddWithValue("@p6", TxtEmail.Text);
            komut.Parameters.AddWithValue("@p7", RchTxtBxAdres.Text);
            komut.Parameters.AddWithValue("@p8", TxtTcKimlikNo.Text);
            komut.Parameters.AddWithValue("@p9", MskTarih.Text);
            komut.Parameters.AddWithValue("@p10", txtDurum.Text);
            komut.Parameters.AddWithValue("@p11", PctrFtgrf.Text);
            komut.Parameters.AddWithValue("@p12", RchTxtBxBilgi.Text);
            komut.Parameters.Add("@p13", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.Baglanti().Close();


            MessageBox.Show("Personel bilgisi güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            txtId.Text = dr["ID"].ToString();
            TxtAd.Text = dr["Ad"].ToString();
            TxtSoyad.Text = dr["Soyad"].ToString();
            TxtGorev.Text = dr["Gorev"].ToString();
            TxtMaas.Text = dr["Maas"].ToString();
            TxtTelefon.Text = dr["TelefonNumarasi"].ToString();
            TxtEmail.Text = dr["EPosta"].ToString();
            RchTxtBxAdres.Text = dr["Adres"].ToString();
            TxtTcKimlikNo.Text = dr["TcKimlikNo"].ToString();
            MskTarih.Text = dr["DogumTarihi"].ToString();
            txtDurum.Text = dr["Durum"].ToString();
            PctrFtgrf.Text = dr["Fotograf"].ToString();
            RchTxtBxBilgi.Text = dr["Bilgi"].ToString();
        }
    }
}
