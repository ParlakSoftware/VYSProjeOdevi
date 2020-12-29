using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BilgiYarismasi
{
    class Soru
    {
        string sorumuz;
        string a;
        string b;
        string c;
        string d;
        char cevap;
        
        public void SoruEkle(string soru, string a, string b, string c, string d, char cvp) {
            this.sorumuz = soru;
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.cevap = cvp;
        }
        public string GetSoru() {
            return sorumuz;
        }
        public void SoruYazdir(Label soru,Button a, Button b, Button c, Button d,Label cevap) {
            soru.Text = sorumuz;
            a.Text = "A. " + this.a;
            b.Text = "B. " + this.b;
            c.Text = "C. " + this.c;
            d.Text = "D. " + this.d;
            cevap.Text = this.cevap.ToString();
        }
    }
}
