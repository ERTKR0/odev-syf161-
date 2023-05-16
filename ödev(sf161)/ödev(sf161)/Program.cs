using NYP_GB_POLY01;

namespace NYP_GB_POLY01
{
    public class Urun //Temel sınıf
    {
        public string UrunAdi { get; set; }
        public double Fiyat { get; set; }
        public virtual double KDVUygula()//Metodun çok biçimli olduğunu bildirmek için virtual yazılır!
        {
            return Fiyat * 1.08;//default olarak calışır buna dikat et t-yani atanmayan yerde bu calışır
        }
        public Urun()
        {
        }
        public Urun(string ad, double fiyat)
        {
            UrunAdi = ad;
            Fiyat = fiyat;
        }
    }
    public class Tekstil : Urun
    {
        public string KumasTuru { get; set; }
        public int Beden { get; set; }
        public Tekstil(string ad, double fiyat, string kumasTuru, int beden)
        {
            UrunAdi = ad;
            Fiyat = fiyat; KumasTuru = kumasTuru; Beden = beden;
        }
    }
    public class CepTelefonu : Urun
    {
        public string Ozelllikler { get; set; }
        public string Marka { get; set; }
        public CepTelefonu(string ad, double fiyat, string marka)
        {
            UrunAdi = ad; Fiyat = fiyat; Marka = marka;
        }

        public override double KDVUygula()//Farklı davranması gerektiği override ile belirtiliyor.
        {
            return Fiyat * 1.18;
        }
    }
    public class Ekmek : Urun
    {
        public string EkmekTuru { get; set; }
        public int Gramaj { get; set; }
        public Ekmek(string urunAdi, double fiyat, string ekmekTuru, int gramaj)
        {
            UrunAdi = urunAdi; Fiyat = fiyat; EkmekTuru = ekmekTuru; Gramaj = gramaj;
        }
        public override double KDVUygula()//Farklı davranması gerektiği override ile belirtiliyor.
        {
            return Fiyat * 1.01;
        }
    }
    public class Sepet
    {
        private List<Urun> urunler = new List<Urun>(); public double ToplamTutar()//burası zaten Urun alt dalarına ayit olarn tüm şeyler eklenir
        {
            double toplamFiyat = 0;
            foreach (Urun item in urunler)// buradada Urun ün alt dalında ve kendidsinde olen tüm şeyler cıkartılır
            {
                toplamFiyat += item.KDVUygula();
            }
            return toplamFiyat;
        }
        public void Ekle(Urun yeniUrun)//main metodunu içinde bunu cağırcağım bu sayede gelenler buraya eklenip bunu içini calıştıracak
        {
            urunler.Add(yeniUrun);//buradanda listeye ürünler eklenecek
        }
        public void Döndür()
        {
            foreach (Urun i in urunler)
            {

                Console.WriteLine("Ürün : " + i.UrunAdi);


            }
        }
    }

    public class sut : Urun
    {
        public decimal Litre { get; set; }
        public sut(string urunadı, double fiyat, decimal litre)
        {
            UrunAdi = urunadı;
            Fiyat = fiyat;
            Litre = litre;
        }
        public override double KDVUygula()
        {
            return Fiyat * 5;
        }
    }
    class test
    {
        public static void Main(string[] args)
        {

            Sepet sepet = new Sepet();//bunu aşağılarda cağırarak aldığım şeyleri sepete ekletecem
            Ekmek ekmek = new Ekmek("ekmecik", 14, "tostekmeği", 600);
            sepet.Ekle(ekmek);
            CepTelefonu cepTelefonu = new CepTelefonu("apple", 27000, "12");
            sepet.Ekle(cepTelefonu);
            sut sut = new sut("dost", 18, 1);
            sepet.Ekle(sut);
            sepet.Döndür();

            Console.WriteLine("**Toplam tutar = " + sepet.ToplamTutar().ToString());

            Console.ReadLine();

        }

    }


}
