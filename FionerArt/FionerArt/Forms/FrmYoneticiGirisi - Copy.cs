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
    public partial class FrmYoneticiGirisi : Form
    {
        public FrmYoneticiGirisi()
        {
            InitializeComponent();
        }
        FrmYoneticiNotlar fr10;
        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr10 = new FrmYoneticiNotlar();
            fr10.MdiParent = this;
            fr10.Show();

        }
        FrmYoneticiSubeler fr1;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr1 = new FrmYoneticiSubeler
            {
                MdiParent = this
            };
            fr1.Show();

        }
        FrmYoneticiKurslar fr15;
        private void barButtonItem15_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            fr15 = new FrmYoneticiKurslar();
            fr15.MdiParent = this;
            fr15.Show();

        }
        FrmYoneticiOdeme fr5;
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            fr5 = new FrmYoneticiOdeme();
            fr5.MdiParent = this;
            fr5.Show();

        }
        FrmStok fr16;
        private void barButtonItem16_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            fr16 = new FrmStok();
            fr16.MdiParent = this;
            fr16.Show();

        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }
        FrmStok fr19;
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            fr19 = new FrmStok();
            fr19.MdiParent = this;
            fr19.Show();

        }
        FrmYoneticiKursiyerler fr21;
        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            fr21 = new FrmYoneticiKursiyerler();
            fr21.MdiParent = this;
            fr21.Show();
        }

        private void FrmYoneticiGirisi_Load(object sender, EventArgs e)
        {

        }
        
        private void barButtonItem20_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmYoneticiOnlineEgitimler fr20 = new FrmYoneticiOnlineEgitimler();
            fr20.MdiParent = this;
            fr20.Show();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmYoneticiEgitmenler fr3 = new FrmYoneticiEgitmenler();
            fr3.MdiParent = this;
            fr3.Show();
        }

        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmYoneticiDuyurular fr9 = new FrmYoneticiDuyurular();
            fr9.MdiParent = this;
            fr9.Show();
        }

        private void barButtonItem23_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmYoneticiPersonel fr23 = new FrmYoneticiPersonel();
            fr23.MdiParent = this;
            fr23.Show();
        }

        private void barButtonItem24_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmYoneticiIstatistik fr24 = new FrmYoneticiIstatistik();
            fr24.MdiParent = this;
            fr24.Show();
        }

        private void barButtonItem22_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOgrenciCizimFikirleri fr22 = new FrmOgrenciCizimFikirleri();
            fr22.MdiParent = this;
            fr22.Show();
        }

        private void barButtonItem25_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOgrenciYapayZeka fr25 = new FrmOgrenciYapayZeka();
            fr25.MdiParent = this;
            fr25.Show();
        }

        private void FrmYoneticiGirisi_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void barButtonItem21_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmOgrenciMalzemeOnerisi fr21 = new FrmOgrenciMalzemeOnerisi();
            fr21.MdiParent = this;
            fr21.Show();
        }

        private void barButtonItem26_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("mspaint.exe");
        }

        private void barButtonItem27_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("ms-paint:");
        }

        private void barButtonItem28_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("https://tr.pinterest.com/");
        }
    }
}
