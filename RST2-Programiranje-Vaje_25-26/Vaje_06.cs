using MyLibrary;

namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_06_Naloge
    {
        Naloga351 = 1,
        Naloga354 = 2
    }

    /// <summary>
    /// Rešitve vaj - 11. november 2025
    /// </summary>
    public class Vaje_06
    {
        public static void Naloga_351()
        {
            Dress dress = new Dress();
            Shoe shoe = new Shoe();
            Accessory accessory = new Accessory();

            Console.WriteLine(dress.GetBarcode());
            Console.WriteLine(shoe.GetBarcode());
            Console.WriteLine(accessory.GetBarcode());
        }

        public static void Naloga_354()
        {
            Square square = new Square(4);
            Circle circle = new Circle(Math.PI);

            SquarePyramid squarePyramid = new SquarePyramid(4,3);

            Console.WriteLine($"Ploščina kvadrata s stranico {square.A} je {square.GetArea():0.00}");
            Console.WriteLine($"Obseg kvadrata s stranico {square.A} je {square.GetPerimeter():0.00}");

            Console.WriteLine($"Ploščina kroga s polmerom {circle.Radius} je {circle.GetArea():0.00}");
            Console.WriteLine($"Obseg kroga s polmerom {circle.Radius} je {circle.GetPerimeter():0.00}");

            Console.WriteLine($"Volumen štiri-strane piramide s stranico {(squarePyramid.BaseShape as Square).A} " +
                $"in višino {squarePyramid.Height} je {squarePyramid.GetVolume():0.00}");
        }
    }

    /// <summary>
    /// Vmesnik, ki naj ga implementirajo razredi, ki uporabljajo črtno kodo
    /// </summary>
    interface IBarcode
    {
        public string GetBarcode();
    }

    public abstract class Article : IBarcode
    {
        // Konstanta, ki določa, s katerega spektra jemljemo vrednost črtne kode.
        protected const int CODE_BASE = 100_000;

        public double Price { get; set; }

        public virtual void Discounted(double discount)
        {
            Price = Price * (1 - discount);
        }

        /// <summary>
        /// Metoda je v tem (nad)razredu definirana samo abstraktno,
        /// implementacije sledijo v podrazredih.
        /// </summary>
        public abstract string GetBarcode();

        public abstract string Type { get; protected set; }

        /// <summary>
        /// Lastnost, s katero določimo predpono črtne kode.
        /// Predpono določimo v konstruktorju, 
        /// vrednost pa pridobimo v podrazredu.
        /// </summary>
        protected string Prefix { get; }

        protected Article(string prefix) { this.Prefix = prefix; }
    }

    public class Dress : Article
    {
        private string type;
        public override string Type
        {
            get { return type; }
            protected set
            {
                // Tukaj preverimo, če gre za ustrezen tip obleke,
                // npr. preverimo seznam s tipi oblek
                type = value; 
            }
        }

        public override string GetBarcode()
        {
            string code = this.Prefix;
            Random rnd = new Random();
            return code + rnd.Next(CODE_BASE);
        }

        public string Size { get; set; }

        public Dress() : base("dre") { }

    }

    public class Shoe : Article
    {
        private string type;
        public override string Type
        {
            get { return type; }
            protected set
            { 
                // Tukaj preverimo, če gre za ustrezen tip čevlja,
                // npr. preverimo seznam s tipi čevljev
                type = value; 
            }
        }

        public override string GetBarcode()
        {
            string code = this.Prefix;
            Random rnd = new Random();
            return code + rnd.Next(CODE_BASE);
        }

        public float Size { get; set; }

        public Shoe() : base("sho") { }
    }

    public class Accessory : Article
    {
        public Accessory() : base("acc") { }

        private string type;
        public override string Type
        {
            get { return type; }
            protected set
            {
                // Tukaj preverimo, če gre za ustrezen tip pripomočka,
                // npr. preverimo seznam s tipi pripomočkov
                type = value;
            }
        }

        public override string GetBarcode()
        {
            string code = this.Prefix;
            Random rnd = new Random();
            return code + rnd.Next(CODE_BASE);
        }
    }

    interface IMeasurableObject
    {
        public abstract double GetArea();
    }

    /// <summary>
    /// Glavni razred za like
    /// </summary>
    public abstract class Shape : IMeasurableObject
    {
        protected Shape() { }

        public abstract double GetPerimeter();

        public abstract double GetArea();
    }

    public class Square : Shape
    {
        public double A { get; set; }

        public Square(double a)
        {
            A = a;
        }

        public override double GetPerimeter()
        {
            return 4 * A;
        }

        public override double GetArea()
        {
            return A * A;
        }
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override double GetArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    /// <summary>
    /// Glavni razred za geometrijska telesa
    /// </summary>
    public abstract class GeometricBody : IMeasurableObject
    {
        public abstract double GetArea();
        public abstract double GetVolume();
    }

    public abstract class Pyramid : GeometricBody
    {
        public Shape BaseShape { get; set; }

        public double Height { get; set; }

    }

    public class SquarePyramid : Pyramid
    {
        public SquarePyramid(double a, double h)
        {
            this.BaseShape = new Square(a);
            this.Height = h;
        }
        public override double GetArea()
        {
            throw new NotImplementedException();
            //Izračunaj doma
        }

        public override double GetVolume()
        {
            return (this.BaseShape.GetArea() * this.Height) / 3;
        }
    }
}
