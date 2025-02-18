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
    public partial class FrmKursKayit : Form
    {
        public FrmKursKayit()
        {
            InitializeComponent();
        }
        public int kursiyerID;
        public int egitmenID;
        public int kursID;
        public int kursFiyati;
        SqlBaglantisi bgl = new SqlBaglantisi();

        string karakalemBilgi = "Yetenek Sınavı Eğitimi: Sanatsal Geleceğinize Güvenle Adım Atın" +

"Sanat eğitimi almak isteyen öğrenciler için yetenek sınavları, hayallerine giden yolda önemli bir adımdır.Başarılı" + " bir sınav süreci, teknik bilgi kadar özgünlük ve yaratıcılık da gerektirir.Fioner Art olarak sunduğumuz yetenek" + " sınavı hazırlık kursları, katılımcıların sınavlarda en iyi performansı sergilemeleri için özel olarak tasarlanmıştır." +

"Eğitim programımızda temel çizim teknikleri, oran-orantı, perspektif, kompozisyon ve figür çizimi gibi konular detaylı" + " bir şekilde işlenir.Ayrıca, sınavlarda sıkça karşılaşılan konular üzerine yoğunlaşarak öğrencilerin teknik" + "yeterliliklerini artırırız. Her öğrencinin kişisel gelişim sürecini yakından takip ederek eksik " + "oldukları alanlarda özel destek sağlarız." +


"Deneyimli eğitmenlerimizin rehberliğinde, özgünlük ve yaratıcılığı ön planda tutarak öğrencilerin sınavlara güvenle " + "hazırlanmalarını sağlıyoruz.Fioner Art ailesine katılarak sanatsal geleceğinize sağlam adımlarla ilerleyin" + " ve hayallerinize bir adım daha yaklaşın!";


        string suluboyaBilgi = "Suluboya Eğitimi: Su ve Rengin Büyüleyici Uyumu" +

  "Suluboya, su ve pigmentin dansıyla hayat bulan zarif ve etkileyici bir sanat dalıdır.Fırçanın kağıda dokunuşuyla akıp" + "giden renkler, hayal gücünüzü özgürce ifade etmenizi sağlar. Bu benzersiz teknik, yumuşak geçişleri ve canlı" + "renkleriyle sanatçılara sınırsız yaratıcılık sunar." +

  "Suluboya eğitimi sırasında temel renk bilgisi, karışım teknikleri ve ışık-gölge oyunları öğretilir. 'Islak üzerine ıslak'" + " ve 'ıslak üzerine kuru' gibi farklı tekniklerle eserlere derinlik ve hareket katılır. Her fırça" + " darbesi, sanatçının duygularını tuvale taşır." +

  "Fioner Art olarak, her seviyeden sanatsevere hitap eden suluboya eğitimleri sunuyoruz. Deneyimli eğitmenlerimiz," + "katılımcıların sanatsal yolculuklarına ilham kaynağı oluyor. Suyun ve rengin büyüleyici uyumunu keşfetmek için" + " Fioner Art ailesine katılın ve sanatın huzur dolu dünyasına adım atın!";

        string yagliboyaBilgi = "Yağlı Boya Eğitimi: Renklerin Derinliği ve Dokusu" +

"Yağlı boya, sanatın en köklü ve etkileyici tekniklerinden biridir.Zengin dokusu, derin renkleri ve kalıcı etkisiyle" + "sanatçılara hayal gücünü özgürce ifade etme fırsatı sunar.Fırçanın tuval üzerindeki izleri, her darbede duyguları" + " ve düşünceleri yansıtır. Bu özel teknik, katmanlı yapısı sayesinde eserlere derinlik ve gerçekçilik kazandırır." +

"Yağlı boya eğitimi sürecinde temel malzeme bilgisi, renk karışımları, doku oluşturma ve ışık-gölge kullanımı gibi" + " konular öğretilir.Palet bıçağı ve farklı fırça teknikleriyle eserlere dinamizm ve hareket katılır." + " 'Islak üzerine ıslak' ve 'katmanlama' gibi yöntemlerle resimlere zengin detaylar eklenir." +

"Fioner Art olarak, her seviyeden sanatsevere özel olarak hazırladığımız yağlı boya eğitimlerimizde, katılımcıların" + " özgün tarzlarını keşfetmelerine yardımcı oluyoruz. Deneyimli eğitmenlerimizin rehberliğinde, katılımcılar renklerin" + " ve dokuların büyülü dünyasında yolculuğa çıkıyor. Siz de fırçanızı alıp, hayal gücünüzü tuvale yansıtmak için" + " Fioner Art ailesine katılın ve sanatın büyüsünü keşfedin!";

        string seramikBilgi = "Seramik Kursu: Toprağın Sanata Dönüşümü" +

"Seramik sanatı, toprağın su ve ateşle buluşarak eşsiz formlara dönüştüğü kadim bir sanattır.Ellerin çamura" + " dokunuşuyla şekillenen seramik eserler, hem işlevsel hem de estetik birer sanat ürünü haline gelir. Bu süreç, sabır, yaratıcılık" + " ve ustalık gerektiren bir yolculuktur." +

"Seramik kursumuzda, temel malzeme bilgisi, şekillendirme teknikleri ve sır uygulamaları gibi konular öğretilir." + " Tornada form verme, elle şekillendirme ve kalıp kullanımı gibi farklı yöntemlerle katılımcılar, çamura istedikleri formu" + " kazandırmayı öğrenirler.Ayrıca, pişirme ve sır uygulamalarıyla eserler daha dayanıklı ve estetik bir görünüm kazanır." +

"Fioner Art olarak, her seviyeden katılımcıya hitap eden seramik kurslarımızda, deneyimli eğitmenlerimiz rehberliğinde" + "özgün tasarımlarınızı hayata geçirmenize destek oluyoruz.Sıcacık bir atölye ortamında, toprağın sanata dönüşümüne" + " şahit olun.Siz de kendi ellerinizle eşsiz seramik eserler yaratmak için Fioner Art ailesine katılın ve sanatın " + "büyüsünü keşfedin!";

        private void BilgiGoster()
        {
            if (rdbSuluBoya.Checked)
            {
                lblBilgi.Text = MetniSatirlaraAyir(suluboyaBilgi);
            }
            else if (radioButton2.Checked)
            {
                lblBilgi.Text = MetniSatirlaraAyir(karakalemBilgi);
            }
            else if (radioButton3.Checked)
            {
                lblBilgi.Text = MetniSatirlaraAyir(yagliboyaBilgi);
            }
            else if (radioButton4.Checked)
            {
                lblBilgi.Text = MetniSatirlaraAyir(seramikBilgi);
            }
        }

        private string MetniSatirlaraAyir(string metin)
        {
            string[] kelimeler = metin.Split(' ');
            StringBuilder yeniMetin = new StringBuilder();

            for (int i = 0; i < kelimeler.Length; i++)
            {
                yeniMetin.Append(kelimeler[i] + " ");


                if ((i + 1) % 12 == 0)
                {
                    yeniMetin.Append("\n");
                }
            }

            return yeniMetin.ToString();
        }

        private void FrmKursKayit2_Load(object sender, EventArgs e)
        {
            rdbSuluBoya.CheckedChanged += rdbSuluBoya_CheckedChanged;
            radioButton2.CheckedChanged += radioButton2_CheckedChanged;
            radioButton3.CheckedChanged += radioButton3_CheckedChanged;
            radioButton4.CheckedChanged += radioButton4_CheckedChanged;
        }

        private void rdbSuluBoya_CheckedChanged(object sender, EventArgs e)
        {
            BilgiGoster();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            BilgiGoster();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            BilgiGoster();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            BilgiGoster();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdbSuluBoya.Checked)
                {
                    kursID = 8;
                    egitmenID = 5;
                    kursFiyati = 1300;
                }
                else if (radioButton2.Checked)
                {
                    kursID = 4;
                    egitmenID = 6;
                    kursFiyati = 1500;
                }
                else if (radioButton3.Checked)
                {
                    kursID = 10;
                    egitmenID = 3;
                    kursFiyati = 1700;


                }
                else if (radioButton4.Checked)
                {
                    kursID = 11;
                    egitmenID = 4;
                    kursFiyati = 1900;

                }
                SqlCommand komut = new SqlCommand("insert into Tbl_KursiyerVeEgitmen(KursiyerID,KursID,EgitmenID) values (@p1,@p2,@p3)"
                    , bgl.Baglanti());
                komut.Parameters.AddWithValue("@p1", kursiyerID);
                komut.Parameters.AddWithValue("@p2", kursID);
                komut.Parameters.AddWithValue("@p3", egitmenID);
                komut.ExecuteNonQuery();

                SqlCommand komut2 = new SqlCommand("insert into Tbl_Odeme(KursiyerID,Tutar) values (@p1,@p2)"
                    , bgl.Baglanti());
                komut2.Parameters.AddWithValue("@p1", kursiyerID);
                komut2.Parameters.AddWithValue("@p2", kursFiyati);
                komut2.ExecuteNonQuery();

                SqlCommand komut3 = new SqlCommand("UPDATE Tbl_Hazinemiz SET Bakiye = Bakiye + @p1 WHERE Numara = 1", bgl.Baglanti());
                komut3.Parameters.AddWithValue("@p1", kursFiyati);
                komut3.ExecuteNonQuery();

                MessageBox.Show("Kayıt başarılı, ödemeniz alındı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("Kayıt başarısız, ödemeniz alınamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                bgl.Baglanti().Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
