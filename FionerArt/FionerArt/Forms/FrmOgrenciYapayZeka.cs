using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

using Google.Cloud.AIPlatform.V1;
using System.Data.SqlClient;

namespace FionerArt.Forms
{
    public partial class FrmOgrenciYapayZeka : Form
    {
        string apiKey = "your-api-key"; // API anahtarınızı buraya yazın
        string apiUrl = "https://api.openai.com/v1/chat/completions"; // ChatGPT API URL'si
        public FrmOgrenciYapayZeka()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public int kursiyerID;

        private async Task<string> GetChatGPTResponse(string userMessage)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    // API isteği için JSON gövdesi
                    var requestBody = new
                    {
                        model = "gpt-3.5-turbo",
                        messages = new[] { new { role = "user", content = userMessage } }
                    };

                    string json = JsonConvert.SerializeObject(requestBody);

                    // HTTP isteği oluştur
                    HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, apiUrl);
                    request.Headers.Add("Authorization", $"Bearer {apiKey}"); // API anahtarını header olarak ekleyin
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");

                    // Yanıtı al
                    HttpResponseMessage response = await client.SendAsync(request);
                    response.EnsureSuccessStatusCode();

                    string responseContent = await response.Content.ReadAsStringAsync();

                    // JSON'dan yanıt içeriğini çıkar
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseContent);
                    string chatGPTResponse = jsonResponse.choices[0].message.content;

                    return chatGPTResponse;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "ChatGPT yanıtı alınamadı.";
            }
        }
        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("UPDATE Tbl_Sorgular SET SorguSayisi = SorguSayisi + @p1 WHERE KursiyerID=@p2", bgl.Baglanti());
                komut.Parameters.AddWithValue("@p1", 6);
                komut.Parameters.AddWithValue("@p2", kursiyerID);
                komut.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally 
            {
                bgl.Baglanti().Close();
            }

            // TextBox'tan soruyu al
            string userQuestion = textEdit1.Text;

            // Kullanıcı bir şey yazmadıysa uyarı ver
            if (string.IsNullOrWhiteSpace(userQuestion))
            {
                MessageBox.Show("Lütfen bir soru yazın.");
                return;
            }

            // API'den yanıt al
            string response = await GetChatGPTResponse(userQuestion);

            // Yanıtı RichTextBox'a yazdır
            richTextBox1.AppendText("Kullanıcı: " + userQuestion + Environment.NewLine);
            richTextBox1.AppendText("ChatGPT: " + response + Environment.NewLine);

            // TextBox'ı temizle
            textEdit1.Text="";
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
