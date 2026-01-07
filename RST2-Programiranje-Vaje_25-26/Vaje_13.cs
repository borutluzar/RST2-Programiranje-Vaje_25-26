using System.Collections;
using System.Diagnostics;

namespace RST2_Programiranje_Vaje_25_26
{
    public enum Vaje_13_Naloge
    {
        Naloga724 = 1,
        Naloga725 = 2,
    }

    /// <summary>
    /// Rešitve vaj - 7. januar 2025
    /// </summary>
    public class Vaje_13
    {
        public static void Naloga724()
        {
            Node<int> root = new Node<int>(7);
            MyTree<int> tree = new MyTree<int>();
            tree.Root = root;
            Node<int> node1 = new Node<int>(47);
            Node<int> node2 = new Node<int>(10);
            Node<int> node3 = new Node<int>(1);
            Node<int> node4 = new Node<int>(19);
            Node<int> node5 = new Node<int>(23);

            tree.Add(node1);
            tree.Add(node2);
            tree.Add(node3);
            tree.Add(node4);
            tree.Add(node5);

            Console.WriteLine($"Drevo ima naslednja vozlišča: {tree.Root}");
        }

        public static void Naloga725()
        {
            Dictionary<string, Author> dicAuthors = new Dictionary<string, Author>();
            Dictionary<string, Publication> dicPublications = new Dictionary<string, Publication>();
            Dictionary<int, List<string>> dicYearPubs = new Dictionary<int, List<string>>();

            StreamReader sr = new StreamReader("tblAuthors.txt");
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split("\t");

                string id = line[1];
                string name = line[2] + " " + line[3];

                Author a = new Author() { Id = id, Name = name };

                if (!dicAuthors.ContainsKey(id))
                {
                    dicAuthors.Add(id, a);
                }
            }
            sr.Close();

            StreamReader sr3 = new StreamReader("tblPubs.txt");
            while (!sr3.EndOfStream)
            {
                string[] line = sr3.ReadLine().Split("\t");

                string id = line[0];
                int year = int.Parse(line[1]);

                Publication pub = new Publication() { Id = id, Year = year };

                dicPublications.Add(id, pub);

                if (!dicYearPubs.ContainsKey(year))
                {
                    dicYearPubs.Add(year, new List<string>());
                }
                dicYearPubs[year].Add(id);
            }
            sr3.Close();

            StreamReader sr2 = new StreamReader("tblPubsAuthors.txt");
            while (!sr2.EndOfStream)
            {
                string[] line = sr2.ReadLine().Split("\t");

                string pubId = line[0];
                string autId = line[1];
                bool sec = Convert.ToBoolean(int.Parse(line[2]));

                if (!sec)
                {
                    if (dicAuthors.ContainsKey(autId))
                    {
                        dicAuthors[autId].Publications.Add(pubId);
                    }

                    if (dicPublications.ContainsKey(pubId))
                    {
                        dicPublications[pubId].Authors.Add(autId);
                    }
                }
            }
            sr2.Close();

            // a) funkcijo, ki bo učinkovito izračunala povprečno število publikacij na avtorja.
            double avgPubs = dicAuthors.Values.Average(x => x.Publications.Count);
            Console.WriteLine($"Povprecno stevilo publikacij na avtorja je: {avgPubs}");

            // b) funkcijo, ki bo učinkovito izračunala povprečno število avtorjev na publikacijo.
            double avgAuth = dicPublications.Values.Average(x => x.Authors.Count);
            Console.WriteLine($"Povprecno stevilo avtorjev na publikacijo je: {avgAuth}");

            // c) funkcijo, ki bo učinkovito izračunala povprečno število avtorjev na publikacijo za dano leto objave.

            // Naiven pristop
            Stopwatch sw = Stopwatch.StartNew();
            double avgAuthYear = dicPublications.Values
                .Where(x => x.Year == 2015)
                .Average(x => x.Authors.Count);
            Console.WriteLine($"Povprecno stevilo avtorjev na publikacijo v letu 2015 je: {avgAuthYear}. Cas: {sw.Elapsed.TotalSeconds:0.000}");

            // Izboljšan je 2x hitrejši
            sw.Restart();
            double avgAuthYearFast = dicYearPubs[2015]
                .Average(x => dicPublications[x].Authors.Count);
            Console.WriteLine($"Povprecno stevilo avtorjev na publikacijo v letu 2015 je: {avgAuthYearFast}. Cas: {sw.Elapsed.TotalSeconds:0.000}");

            // Izračun za vsa leta v danem intervalu
            for (int i = 1990; i < 2023; i++)
            {
                double avgAuthYearLoop = dicYearPubs[i]
                   .Average(x => dicPublications[x].Authors.Count);
                Console.WriteLine($"Povprecno stevilo avtorjev na publikacijo v letu {i} je: {avgAuthYearLoop: 0.00}.");
            }
        }
    }

    public class Author
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Publications { get; set; } = new List<string>();
    }

    public class Publication
    {
        public string Id { get; set; }
        public int Year { get; set; }
        public List<string> Authors { get; set; } = new List<string>();
    }

    public class Node<T>
    {
        public T Value { get; }
        public Node<T> Left { get; set; }

        public Node<T> Middle { get; set; }

        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value} [{(Left != null ? Left : "/")},{(Middle != null ? Middle : "/")},{(Right != null ? Right : "/")}]";
        }

    }
    public class MyTree<T> : ICollection<Node<T>>
    {
        public Node<T> Root { get; set; }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(Node<T> item)
        {

            Queue<Node<T>> queue = new Queue<Node<T>>() { Root };
            while (queue.Count > 0)
            {
                Node<T> tmp = queue.Dequeue();
                if (tmp.Left == null)
                {
                    tmp.Left = item;
                    return;
                }
                if (tmp.Middle == null)
                {
                    tmp.Middle = item;
                    return;
                }
                if (tmp.Right == null)
                {
                    tmp.Right = item;
                    return;
                }
                queue.Enqueue(tmp.Left);
                queue.Enqueue(tmp.Middle);
                queue.Enqueue(tmp.Right);

            }
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(Node<T> item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Node<T>[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Node<T>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(Node<T> item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
