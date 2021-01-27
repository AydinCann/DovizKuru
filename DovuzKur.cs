using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DovizKuru
{
    class DovuzKur
    {
        public string KurAdi { get; set; }
        public string AlisFiyati { get; set; }
        public string SatisFİyati { get; set; }
        public string BankaAlisFiyati { get; set; }
        public string BankaSatisFiyati { get; set; }

        public DovuzKur()
        {


        }
        public DovuzKur(string kuradi ,string alisFiyati, string satisFiyati,string bankaalisFİyati,string bankasatisFiyati)
        {
            this.KurAdi = kuradi;
            this.AlisFiyati = alisFiyati;
            this.SatisFİyati = satisFiyati;
            this.BankaAlisFiyati = bankaalisFİyati;
            this.BankaSatisFiyati = bankasatisFiyati;

        }
    }
}
