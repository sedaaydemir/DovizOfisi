using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizOfisi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://www.tcmb.gov.tr/kurlar/today.xml";
            //var varıable, bununla sız ınt char vs tanımlayabılırsın. cekecegımız dosyanın type bılmedıgımız ıcın bu tanımı kullanırız
            var xmldosya = new XmlDocument();
            xmldosya.Load(bugun);

            //xml dosyasıdan guncel kurları cekerken net sayfasında sag tık ve sayfa kaynagını goruntuleye tıklarsın
            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying ").InnerXml;
            lblDolarAlis.Text = dolaralis;

            string dolarSatis =xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSatis.Text = dolarSatis;

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying ").InnerXml;
            lblEuroAlis.Text = euroalis;

            string euroSatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSatis.Text = euroSatis;


        }

        private void btnDolarAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarAlis.Text;
        }

        private void btnDolarSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarSatis.Text;
        }

        private void btnEuroAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroAlis.Text;
        }

        private void btnEuroSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroSatis.Text;
        }

        private void btnSatisYap_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur=Convert.ToDouble(txtKur.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = kur * miktar;
            txtTutar.Text = tutar.ToString();
        }

        private void txtKur_TextChanged(object sender, EventArgs e)
        {
            //noktayı vırgulle cevırme sebebımız,işlem esnasında vırgulu gormeyıp noktayı yuvarladıgı ıcın
            txtKur.Text = txtKur.Text.Replace(".", ",");
        }

        private void btnSatisYap2_Click(object sender, EventArgs e)
        {
            //tl para mıktarına gore ne kadar dovız alabılır
            double kur = Convert.ToDouble(txtKur.Text);
            int miktar =Convert.ToInt32(txtMiktar.Text);
            int tutar =Convert.ToInt32( miktar / kur);
            txtTutar.Text = tutar.ToString();
            double kalan;
            kalan =miktar%kur;
            txtKalan.Text = kalan.ToString();
        }
    }
}
