using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DovizKuru
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listViewKur.View = View.Details;
            listViewKur.GridLines = true;
            listViewKur.FullRowSelect = true;
            listViewKur.Columns.Add("CurrencyName",160);
            listViewKur.Columns.Add("ForexBuying",120);
            listViewKur.Columns.Add("ForexSelling",120);
            listViewKur.Columns.Add("BanknoteBuying",120);
            listViewKur.Columns.Add("BanknoteSelling",120);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            listViewKur.Items.Clear();
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            XmlDocument doc = new XmlDocument();

            doc.Load("https://www.tcmb.gov.tr/kurlar/today.xml");

            XmlNodeList DovuzListesi = doc.SelectNodes("/Tarih_Date/Currency");

            List<DovuzKur> dovuzKurs = new List<DovuzKur>();

            foreach (XmlNode doviz in DovuzListesi)
            {
                string CurrencyName = doviz.SelectSingleNode("CurrencyName").InnerText;
                string ForexBuying = doviz.SelectSingleNode("ForexBuying").InnerText;
                string ForexSelling = doviz.SelectSingleNode("ForexSelling").InnerText;
                string BanknoteBuying = doviz.SelectSingleNode("BanknoteBuying").InnerText;
                string BanknoteSelling = doviz.SelectSingleNode("BanknoteSelling").InnerText;

                dovuzKurs.Add(new DovuzKur(CurrencyName, ForexBuying, ForexSelling, BanknoteBuying, BanknoteSelling));

                string[] satir = { CurrencyName, ForexBuying, ForexSelling, BanknoteBuying, BanknoteSelling };

                var item = new ListViewItem(satir);

                item.Tag = CurrencyName;

                

                listViewKur.Items.Add(item);

            }


        }

        private void listViewKur_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (listViewKur.SelectedItems.Count>0)
            {
                Form1.ActiveForm.Text = listViewKur.SelectedItems[0].Tag.ToString();
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
