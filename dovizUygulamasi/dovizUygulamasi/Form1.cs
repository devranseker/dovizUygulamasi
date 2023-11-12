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


namespace dovizUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string bugun = "https://tcmb.gov.tr/kurlar/today.xml";
            var xmldosya = new XmlDocument();
            // bu gunun degerlerini hafızaya yukler
            xmldosya.Load(bugun);

            // Dolar alıs satıs 
            string dolaralis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            LblDolarAlis.Text = dolaralis;

            string dolarsatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'USD']/BanknoteSelling").InnerXml.ToString();
            LblDolarSatis.Text = dolarsatis;

            // Euro alıs ve satıs

            string euroalis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'EUR']/BanknoteBuying").InnerXml.ToString();
            LblEuroAlis.Text = euroalis;

            string eurosatis = xmldosya.SelectSingleNode("Tarih_Date/Currency[@Kod = 'EUR']/BanknoteSelling").InnerXml.ToString();
            LblEuroSatis.Text = eurosatis;

        }
        // Dolar al Butonu
        private void BtnDolarAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolarAlis.Text;

        }

        private void BtnDolarSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblDolarSatis.Text;

        }

        private void BtnEuroAl_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroAlis.Text;
        }

        private void BtnEuroSat_Click(object sender, EventArgs e)
        {
            TxtKur.Text = LblEuroSatis.Text;
        }

        // Satıs Yap Butonu 
        private void BtnSatisYap1_Click_1(object sender, EventArgs e)
        {
            double kur, miktar, tutar;
            kur = Convert.ToDouble(TxtKur.Text);
            miktar = Convert.ToDouble(TxtMiktar.Text);
            tutar = kur * miktar;
            TxtTutar.Text = tutar.ToString();
            // kalan para 
            // ornek olarak adam 100$ aldı ve kalan parası ,'den sonrası 
            double kalan;
            kalan = miktar % tutar;
            TxtKalan.Text = kalan.ToString();

        }

        //TextChanged degisiklik 
        // Formadaki ondalık kısmından girilirken , (virgül) ile kod kısmında nokta (.) ile 
        private void TxtKur_TextChanged(object sender, EventArgs e)
        {
            TxtKur.Text = TxtKur.Text.Replace(".", ",");  // ("X1", "X2") == Mimari : X1 --> X2    Algorithm : X2 = X1     
        }

        // Al
        private void BtnSatisYap2_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(TxtKur.Text);
            int miktar = Convert.ToInt32(TxtMiktar.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            TxtTutar.Text = tutar.ToString();

            // kalan para 
            // ornek olarak adam 100$ aldı ve kalan parası ,'den sonrası 
            double kalan;
            kalan = miktar % tutar;
            TxtKalan.Text = kalan.ToString();
        }

    }
}
