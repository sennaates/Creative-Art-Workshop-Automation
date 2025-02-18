namespace FionerArt
{
    partial class Baslangic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Baslangic));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.BtnYoneticiGirisi = new DevExpress.XtraEditors.SimpleButton();
            this.BtnOgrenciGirisi = new DevExpress.XtraEditors.SimpleButton();
            this.TxtSifre = new DevExpress.XtraEditors.TextEdit();
            this.TxtKullaniciAdi = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.BtnSifreGoster = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKullaniciAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSifreGoster.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.DisabledLinkColor = System.Drawing.Color.Transparent;
            this.linkLabel1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.linkLabel1.LinkColor = System.Drawing.Color.Blue;
            this.linkLabel1.Location = new System.Drawing.Point(644, 420);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(108, 17);
            this.linkLabel1.TabIndex = 17;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Şifremi Unuttum";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(679, 93);
            this.pictureEdit1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(185, 164);
            this.pictureEdit1.TabIndex = 15;
            // 
            // BtnYoneticiGirisi
            // 
            this.BtnYoneticiGirisi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnYoneticiGirisi.Appearance.Options.UseForeColor = true;
            this.BtnYoneticiGirisi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnYoneticiGirisi.ImageOptions.Image")));
            this.BtnYoneticiGirisi.Location = new System.Drawing.Point(679, 521);
            this.BtnYoneticiGirisi.Margin = new System.Windows.Forms.Padding(4);
            this.BtnYoneticiGirisi.Name = "BtnYoneticiGirisi";
            this.BtnYoneticiGirisi.Size = new System.Drawing.Size(185, 46);
            this.BtnYoneticiGirisi.TabIndex = 14;
            this.BtnYoneticiGirisi.Text = "Kurumsal Giriş";
            this.BtnYoneticiGirisi.Click += new System.EventHandler(this.BtnYoneticiGirisi_Click);
            // 
            // BtnOgrenciGirisi
            // 
            this.BtnOgrenciGirisi.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.BtnOgrenciGirisi.Appearance.Options.UseForeColor = true;
            this.BtnOgrenciGirisi.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnOgrenciGirisi.ImageOptions.Image")));
            this.BtnOgrenciGirisi.Location = new System.Drawing.Point(679, 465);
            this.BtnOgrenciGirisi.Margin = new System.Windows.Forms.Padding(4);
            this.BtnOgrenciGirisi.Name = "BtnOgrenciGirisi";
            this.BtnOgrenciGirisi.Size = new System.Drawing.Size(185, 46);
            this.BtnOgrenciGirisi.TabIndex = 13;
            this.BtnOgrenciGirisi.Text = "Öğrenci Girişi";
            this.BtnOgrenciGirisi.Click += new System.EventHandler(this.BtnOgrenciGirisi_Click);
            // 
            // TxtSifre
            // 
            this.TxtSifre.Location = new System.Drawing.Point(644, 378);
            this.TxtSifre.Margin = new System.Windows.Forms.Padding(4);
            this.TxtSifre.Name = "TxtSifre";
            this.TxtSifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.TxtSifre.Properties.Appearance.Options.UseFont = true;
            this.TxtSifre.Properties.PasswordChar = '*';
            this.TxtSifre.Size = new System.Drawing.Size(261, 24);
            this.TxtSifre.TabIndex = 12;
            // 
            // TxtKullaniciAdi
            // 
            this.TxtKullaniciAdi.Location = new System.Drawing.Point(644, 316);
            this.TxtKullaniciAdi.Margin = new System.Windows.Forms.Padding(4);
            this.TxtKullaniciAdi.Name = "TxtKullaniciAdi";
            this.TxtKullaniciAdi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            this.TxtKullaniciAdi.Properties.Appearance.Options.UseFont = true;
            this.TxtKullaniciAdi.Size = new System.Drawing.Size(261, 24);
            this.TxtKullaniciAdi.TabIndex = 11;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(644, 350);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 23);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Şifre";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(644, 286);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(103, 23);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Kullanıcı Adı";
            // 
            // BtnSifreGoster
            // 
            this.BtnSifreGoster.EditValue = ((object)(resources.GetObject("BtnSifreGoster.EditValue")));
            this.BtnSifreGoster.Location = new System.Drawing.Point(915, 375);
            this.BtnSifreGoster.Name = "BtnSifreGoster";
            this.BtnSifreGoster.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.BtnSifreGoster.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.BtnSifreGoster.Size = new System.Drawing.Size(47, 30);
            this.BtnSifreGoster.TabIndex = 18;
            this.BtnSifreGoster.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnSifreGoster_MouseDown);
            this.BtnSifreGoster.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnSifreGoster_MouseUp);
            // 
            // Baslangic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1523, 799);
            this.Controls.Add(this.BtnSifreGoster);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.BtnYoneticiGirisi);
            this.Controls.Add(this.BtnOgrenciGirisi);
            this.Controls.Add(this.TxtSifre);
            this.Controls.Add(this.TxtKullaniciAdi);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Baslangic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fioner Art";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKullaniciAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BtnSifreGoster.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton BtnYoneticiGirisi;
        private DevExpress.XtraEditors.SimpleButton BtnOgrenciGirisi;
        private DevExpress.XtraEditors.TextEdit TxtSifre;
        private DevExpress.XtraEditors.TextEdit TxtKullaniciAdi;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PictureEdit BtnSifreGoster;
    }
}