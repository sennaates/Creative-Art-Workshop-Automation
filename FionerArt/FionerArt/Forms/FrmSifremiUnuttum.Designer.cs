namespace FionerArt.Forms
{
    partial class FrmSifremiUnuttum
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSifremiUnuttum));
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.BtnEposta = new DevExpress.XtraEditors.SimpleButton();
            this.BtnWhatsApp = new DevExpress.XtraEditors.SimpleButton();
            this.TxtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKullaniciAdi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(669, 137);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(185, 164);
            this.pictureEdit1.TabIndex = 25;
            // 
            // BtnEposta
            // 
            this.BtnEposta.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnEposta.Appearance.Options.UseForeColor = true;
            this.BtnEposta.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnEposta.ImageOptions.Image")));
            this.BtnEposta.Location = new System.Drawing.Point(667, 536);
            this.BtnEposta.Margin = new System.Windows.Forms.Padding(4);
            this.BtnEposta.Name = "BtnEposta";
            this.BtnEposta.Size = new System.Drawing.Size(185, 46);
            this.BtnEposta.TabIndex = 24;
            this.BtnEposta.Text = "E-Posta ile Yolla!";
            this.BtnEposta.Click += new System.EventHandler(this.BtnEposta_Click);
            // 
            // BtnWhatsApp
            // 
            this.BtnWhatsApp.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnWhatsApp.Appearance.Options.UseForeColor = true;
            this.BtnWhatsApp.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnWhatsApp.ImageOptions.Image")));
            this.BtnWhatsApp.Location = new System.Drawing.Point(669, 482);
            this.BtnWhatsApp.Margin = new System.Windows.Forms.Padding(4);
            this.BtnWhatsApp.Name = "BtnWhatsApp";
            this.BtnWhatsApp.Size = new System.Drawing.Size(185, 46);
            this.BtnWhatsApp.TabIndex = 23;
            this.BtnWhatsApp.Text = "WhatsApp\'a Yolla!";
            this.BtnWhatsApp.Click += new System.EventHandler(this.BtnWhatsApp_Click);
            // 
            // TxtKullaniciAdi
            // 
            this.TxtKullaniciAdi.Location = new System.Drawing.Point(638, 405);
            this.TxtKullaniciAdi.Margin = new System.Windows.Forms.Padding(4);
            this.TxtKullaniciAdi.Name = "TxtKullaniciAdi";
            this.TxtKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.TxtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.TxtKullaniciAdi.Size = new System.Drawing.Size(261, 24);
            this.TxtKullaniciAdi.TabIndex = 21;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(638, 375);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 23);
            this.labelControl1.TabIndex = 19;
            this.labelControl1.Text = "Kullanıcı Adı";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(667, 328);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(183, 23);
            this.labelControl2.TabIndex = 20;
            this.labelControl2.Text = "Şifre Sıfırlama Sayfası";
            // 
            // FrmSifremiUnuttum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1523, 799);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.BtnEposta);
            this.Controls.Add(this.BtnWhatsApp);
            this.Controls.Add(this.TxtKullaniciAdi);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Name = "FrmSifremiUnuttum";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmSifremiUnuttum";
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKullaniciAdi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton BtnEposta;
        private DevExpress.XtraEditors.SimpleButton BtnWhatsApp;
        private DevExpress.XtraEditors.TextEdit TxtKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}