namespace RST2_Programiranje_Vaje_25_26
{
    public class BelaTehnika : Izdelek
    {
        public int Garancija { get; set; } // Garancija v mesecih
        public string EnergijskiRazred { get; set; }

        // Prazen kontruktor
        public BelaTehnika() : base()
        {
            Garancija = 0;
            EnergijskiRazred = "Ni podatka";
        }

        // Konstruktor z argumenti
        public BelaTehnika(string naziv, string proizvajalec, decimal cena, int garancija, string energijskiRazred)
            : base(naziv, proizvajalec, cena)
        {
            Garancija = garancija;
            EnergijskiRazred = energijskiRazred;
        }

        // Izpišemo - overirde ToString()
        public override string ToString()
        {
            return $"{Naziv} (BelaTehnika) - Proizvajalec: {Proizvajalec}, Cena: {Cena:C}, Garancija: {Garancija} mesecev, Energijski razred: {EnergijskiRazred}";
        }
    }
}
