namespace RST2_Programiranje_Vaje_25_26
{
    public enum StopnjaPravic
    {
        Admin,
        Delavec,
        Gost
    }

    public enum Korak
    {
        Ustvari = 0,
        Pripravi = 1,
        Preveri = 2,
        Potrdi = 3
    }

    public class Porocilo : IDokument, IDelovniTok
    {
        public string Naziv { get; set; }
        public string Avtor { get; set; }
        public DateTime CasUstvarjeno { get; set; }

        public bool Shrani()
        {
            return true;
        }

        public SistemskiUporabnik Pripravljalec { get; set; }
        public SistemskiUporabnik Pregledovalec { get; set; }
        public SistemskiUporabnik Potrjevalec { get; set; }

        public Korak TrenutniKorak { get; set; }

        public Porocilo()
        {
            this.TrenutniKorak = Korak.Ustvari;
        }

        public bool PosljiVNaslednjiKorak()
        {
            this.TrenutniKorak++;
            if (TrenutniKorak > Korak.Potrdi)
            {
                Console.WriteLine("Poročilo je bilo potrjeno");
                this.TrenutniKorak--;
                return false;
            }
            return true;
        }
    }

    public class SistemskiUporabnik
    {
        public Guid Id { get; }
        public string UporabniskoIme { get; set; }
        public StopnjaPravic Pravice { get; set; }

        public SistemskiUporabnik(string uporabniskoIme)
        {
            this.Id = Guid.NewGuid();
            this.UporabniskoIme = uporabniskoIme;
            this.Pravice = StopnjaPravic.Gost;
        }

        public void NadgradiStopnjo(StopnjaPravic pravice)
        {
            this.Pravice = pravice;
        }
    }

    interface IDelovniTok
    {
        SistemskiUporabnik Pripravljalec { get; set; }
        SistemskiUporabnik Pregledovalec { get; set; }
        SistemskiUporabnik Potrjevalec { get; set; }

        Korak TrenutniKorak { get; set; }
        public bool PosljiVNaslednjiKorak();

    }

    interface IDokument
    {
        public DateTime CasUstvarjeno { get; set; }
        public string Avtor { get; set; }

        public bool Shrani();
    }
}
