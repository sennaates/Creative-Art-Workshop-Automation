using FionerArt.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FionerArt
{
    public partial class FrmOgrenciGirisi : Form
    {
        public FrmOgrenciGirisi()
        {
            InitializeComponent();
        }
        public int kursiyerID;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItem7_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)

        { 
            FrmOgrenciOgrenciBilgileri fr7 = new FrmOgrenciOgrenciBilgileri();
            fr7.kursiyerID = kursiyerID;
            fr7.MdiParent = this;
            fr7.Show();
        }

        private void barButtonItem13_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void FrmOgrenciGirisi_Load(object sender, EventArgs e)
        {
            

        }

        private void BarButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOgrenciYapayZeka fr19 = new FrmOgrenciYapayZeka();
            fr19.kursiyerID = kursiyerID;
            fr19.MdiParent = this;
            fr19.Show();
        }

        private void barButtonItem18_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOgrenciCizimFikirleri fr18 = new FrmOgrenciCizimFikirleri();
            fr18.kursiyerID = kursiyerID;
            fr18.MdiParent = this;
            fr18.Show();
        }

        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            FrmOgrenciOnlineEgitimler fr16 = new FrmOgrenciOnlineEgitimler();
            fr16.MdiParent = this;
            fr16.Show();
        }

        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmKursKayit fr20 = new FrmKursKayit();
            fr20.kursiyerID = kursiyerID;
            fr20.MdiParent = this;
            fr20.Show();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOgrenciDuyurular fr21 = new FrmOgrenciDuyurular();
            fr21.MdiParent = this;
            fr21.Show();
        }

        private void FrmOgrenciGirisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void barButtonItem17_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOgrenciMalzemeOnerisi fr17 = new FrmOgrenciMalzemeOnerisi();
            fr17.MdiParent = this;
            fr17.Show();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("mspaint.exe");
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("ms-paint:");

        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tr.pinterest.com/");

        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOgrenciBizeUlasin fr17 = new FrmOgrenciBizeUlasin();
            
            fr17.Show();
        }
    }
}
