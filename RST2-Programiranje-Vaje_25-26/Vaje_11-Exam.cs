using System.Text.Json;
using System.Text.Json.Serialization;

namespace RST2_Programiranje_Vaje_25_26
{

    /// <summary>
    /// Glavni razred za upravljanje izpitov
    /// </summary>
    public class Vaje_11_Exam
    {
        /// <summary>
        /// Sistem za izdelavo in reševanje izpitov
        /// </summary>
        public static void ExamUI()
        {
            Console.Clear();
            Console.WriteLine("SISTEM ZA IZDELAVO IN REŠEVANJE IZPITOV");
            Console.WriteLine("=====================================\n");

            while (true)
            {
                Console.WriteLine("\nIzberite možnost:");
                Console.WriteLine("1. Ustvari nov izpit");
                Console.WriteLine("2. Naloži obstoječi izpit");
                Console.WriteLine("3. Reši izpit");
                Console.WriteLine("4. Prikaži statistiko rezultatov");
                Console.WriteLine("5. Izhod");
                Console.Write("\nVaša izbira: ");

                string izbira = Console.ReadLine();

                switch (izbira)
                {
                    case "1":
                        CreateExam();
                        break;
                    case "2":
                        LoadExam();
                        break;
                    case "3":
                        SolveExam();
                        break;
                    case "4":
                        ShowStatistics();
                        break;
                    case "5":
                        Console.WriteLine("\nHvala za uporabo sistema!");
                        return;
                    default:
                        Console.WriteLine("\nNeveljavna izbira!");
                        break;
                }
            }
        }

        private static void CreateExam()
        {
            Console.WriteLine("\n--- USTVARJANJE NOVEGA IZPITA ---");

            Exam exam = new Exam();

            Console.Write("Vnesite predmet izpita: ");
            exam.Subject = Console.ReadLine();

            Console.Write("Vnesite opis izpita: ");
            exam.Description = Console.ReadLine();

            bool addQuestions = true;
            while (addQuestions)
            {
                Console.WriteLine("\nIzberite tip vprašanja:");
                Console.WriteLine("1. En pravilen odgovor");
                Console.WriteLine("2. Več pravilnih odgovorov");
                Console.WriteLine("3. Vprašanje odprtega tipa");
                Console.Write("Vaša izbira: ");

                string type = Console.ReadLine();

                Console.Write("Vnesite besedilo vprašanja: ");
                string text = Console.ReadLine();

                List<string> answers = new List<string>();
                List<int> correctAnswers = new List<int>();

                if (type == "1" || type == "2")  // Če ni odprto vprašanje
                {
                    Console.WriteLine("Vnesite možne odgovore (za izhod pritisnite Enter brez vnosa):");
                    int numAnswers = 1;
                    while (true)
                    {
                        Console.Write($"  Odgovor {numAnswers}: ");
                        string answer = Console.ReadLine();
                        if (string.IsNullOrWhiteSpace(answer))
                            break;
                        answers.Add(answer);
                        numAnswers++;
                    }

                    if (answers.Count > 0)
                    {
                        Console.Write("Vnesite številko pravilnega odgovora");
                        if (type == "2") Console.Write(" (ločite z vejico za več pravilnih)");
                        Console.Write(": ");

                        string[] correctArray = Console.ReadLine().Split(',');
                        foreach (string p in correctArray)
                        {
                            if (int.TryParse(p.Trim(), out int correct) && correct >= 1 && correct <= answers.Count)
                            {
                                correctAnswers.Add(correct - 1);
                            }
                        }
                    }
                }

                // Uporabimo factory
                Question question = QuestionFactory.CreateQuestion(type, text, answers, correctAnswers);
                exam.Questions.Add(question);

                Console.Write("\nŽelite dodati še eno vprašanje? (da/ne): ");
                addQuestions = Console.ReadLine().ToLower() == "da";
            }

            // Shranjevanje izpita v JSON
            try
            {
                string filename = $"izpit_{DateTime.Now:yyyyMMdd_HHmmss}.json";
                string json = JsonSerializer.Serialize(exam, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
                File.WriteAllText(filename, json);

                Console.WriteLine($"\n✓ Izpit uspešno shranjen v datoteko: {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"✗ Napaka pri shranjevanju: {ex.Message}");
            }
        }

        private static void LoadExam()
        {
            Console.WriteLine("\n--- NALOŽI IZPIT ---");

            // Poiščemo vse JSON datoteke
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "izpit_*.json");

            if (files.Length == 0)
            {
                Console.WriteLine("Ni najdenih izpitov!");
                return;
            }

            Console.WriteLine("\nNajdeni izpiti:");
            for (int i = 0; i < files.Length; i++)
            {
                try
                {
                    string json = File.ReadAllText(files[i]);
                    var exam = JsonSerializer.Deserialize<Exam>(json);
                    Console.WriteLine($"{i + 1}. {exam.Subject} ({exam.Questions.Count} vprašanj) - {Path.GetFileName(files[i])}");
                }
                catch
                {
                    Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])} (napaka pri branju)");
                }
            }

            Console.Write("\nIzberite številko izpita za prikaz: ");
            if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= files.Length)
            {
                ShowExam(files[choice - 1]);
            }
            else
            {
                Console.WriteLine("Neveljavna izbira!");
            }
        }

        private static void ShowExam(string filename)
        {
            try
            {
                string json = File.ReadAllText(filename);
                var exam = JsonSerializer.Deserialize<Exam>(json);

                Console.WriteLine($"\n=== {exam.Subject} ===");
                Console.WriteLine(exam.Description);
                Console.WriteLine($"Ustvarjeno: {exam.Created}");
                Console.WriteLine($"Število vprašanj: {exam.Questions.Count}");
                Console.WriteLine("\nVprašanja:");

                for (int i = 0; i < exam.Questions.Count; i++)
                {
                    Console.WriteLine($"\n{i + 1}. [{exam.Questions[i].QuestionType}] {exam.Questions[i].Text}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Napaka pri branju izpita: {ex.Message}");
            }
        }

        private static void SolveExam()
        {
            Console.WriteLine("\n--- REŠEVANJE IZPITA ---");

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "izpit_*.json");

            if (files.Length == 0)
            {
                Console.WriteLine("Ni najdenih izpitnih datotek!");
                return;
            }

            Console.WriteLine("\nIzberite izpit za reševanje:");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {Path.GetFileName(files[i])}");
            }

            Console.Write("\nVaša izbira: ");
            if (!int.TryParse(Console.ReadLine(), out int izbira) || izbira < 1 || izbira > files.Length)
            {
                Console.WriteLine("Neveljavna izbira!");
                return;
            }

            try
            {
                string json = File.ReadAllText(files[izbira - 1]);
                var exam = JsonSerializer.Deserialize<Exam>(json);

                Console.Write("\nVnesite vaše ime: ");
                string userName = Console.ReadLine();

                Console.WriteLine($"\n=== ZAČETEK IZPITA: {exam.Subject} ===");
                Console.WriteLine(exam.Description);
                Console.WriteLine($"\nNavodila: Odgovarjajte na vprašanja. Za več možnosti ločite z vejico.");
                Console.WriteLine("Pritisnite Enter za začetek...");
                Console.ReadLine();

                List<List<int>> userAnswers = new List<List<int>>();
                int correctAnswers = 0;

                for (int i = 0; i < exam.Questions.Count; i++)
                {
                    Console.Clear();
                    Console.WriteLine($"Vprašanje {i + 1} / {exam.Questions.Count}");
                    exam.Questions[i].WriteQuestion();

                    Console.Write("\nVaš odgovor: ");
                    string input = Console.ReadLine();

                    List<int> answers = new List<int>();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        string[] parts = input.Split(',');
                        foreach (string part in parts)
                        {
                            if (int.TryParse(part.Trim(), out int odg))
                            {
                                answers.Add(odg - 1);
                            }
                        }
                    }

                    userAnswers.Add(answers);

                    if (exam.Questions[i].CheckAnswer(answers))
                    {
                        correctAnswers++;
                        Console.WriteLine("✓ Pravilno!");
                    }
                    else
                    {
                        Console.WriteLine("✗ Napačno!");
                    }

                    if (i < exam.Questions.Count - 1)
                    {
                        Console.WriteLine("\nPritisnite Enter za naslednje vprašanje...");
                        Console.ReadLine();
                    }
                }

                // Shranjevanje rezultata
                ExamResults result = new ExamResults
                {
                    Subject = exam.Subject,
                    UserName = userName,
                    NumberOfCorrectAnswers = correctAnswers,
                    TotalQuestions = exam.Questions.Count,
                    Grade = (double)correctAnswers / exam.Questions.Count * 100
                };

                string rezultatJson = JsonSerializer.Serialize(result, new JsonSerializerOptions { WriteIndented = true });
                string rezultatFile = $"rezultat_{DateTime.Now:yyyyMMdd_HHmmss}_{userName}.json";
                File.WriteAllText(rezultatFile, rezultatJson);

                Console.WriteLine($"\n=== REZULTAT IZPITA ===");
                Console.WriteLine($"Ime: {userName}");
                Console.WriteLine($"Izpit: {exam.Subject}");
                Console.WriteLine($"Pravilnih odgovorov: {correctAnswers}/{exam.Questions.Count}");
                Console.WriteLine($"Uspeh: {result.Grade:F1}%");
                Console.WriteLine($"\nRezultat shranjen v: {rezultatFile}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Napaka pri reševanju izpita: {ex.Message}");
            }

            Console.WriteLine("\nPritisnite Enter za vrnitev v glavni meni...");
            Console.ReadLine();
        }

        private static void ShowStatistics()
        {
            Console.WriteLine("\n--- STATISTIKA REZULTATOV ---");

            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "rezultat_*.json");

            if (files.Length == 0)
            {
                Console.WriteLine("Ni najdenih rezultatov!");
                return;
            }

            List<ExamResults> results = new List<ExamResults>();

            foreach (string file in files)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    var result = JsonSerializer.Deserialize<ExamResults>(json);
                    results.Add(result);
                }
                catch
                {
                    // Preskočimo neveljavne datoteke
                }
            }

            if (results.Count == 0)
            {
                Console.WriteLine("Ni veljavnih rezultatov!");
                return;
            }

            // Grupiranje po predmetih
            var bySubjects = new Dictionary<string, List<ExamResults>>();
            foreach (var r in results)
            {
                if (!bySubjects.ContainsKey(r.Subject))
                    bySubjects[r.Subject] = new List<ExamResults>();
                bySubjects[r.Subject].Add(r);
            }

            foreach (var kvp in bySubjects)
            {
                Console.WriteLine($"\n=== {kvp.Key} ===");
                Console.WriteLine($"Število rešitev: {kvp.Value.Count}");

                double averageGrade = 0;
                double bestGrade = 0;
                string bestUser = "";

                foreach (var r in kvp.Value)
                {
                    averageGrade += r.Grade;
                    if (r.Grade > bestGrade)
                    {
                        bestGrade = r.Grade;
                        bestUser = r.UserName;
                    }
                }

                averageGrade /= kvp.Value.Count;

                Console.WriteLine($"Povprečni uspeh: {averageGrade:F1}%");
                Console.WriteLine($"Najboljši uspeh: {bestGrade:F1}% ({bestUser})");
            }

            Console.WriteLine("\nPritisnite Enter za nadaljevanje...");
            Console.ReadLine();
        }
    }

    /// <summary>
    /// Razred vzorca factory za ustvarjanje vprašanj
    /// </summary>
    public static class QuestionFactory
    {
        public static Question CreateQuestion(string type, string questionText, List<string> answers, List<int> correctAnswers)
        {
            Question question = null;

            switch (type)
            {
                case "1":
                    question = new Question_OneCorrectAnswer
                    {
                        Text = questionText,
                        Answers = answers,
                        CorrectAnswers = correctAnswers
                    };
                    break;
                case "2":
                    question = new Question_MultipleCorrectAnswers
                    {
                        Text = questionText,
                        Answers = answers,
                        CorrectAnswers = correctAnswers
                    };
                    break;
                case "3":
                    question = new Question_OpenType
                    {
                        Text = questionText,
                        Answers = new List<string>(),
                        CorrectAnswers = correctAnswers
                    };
                    break;
                default:
                    Console.WriteLine("Neveljavna izbira!");
                    break;
            }
            return question;
        }
    }

    /// <summary>
    /// Osnovni razred za vprašanje
    /// </summary>
    [JsonDerivedType(typeof(Question_OneCorrectAnswer), typeDiscriminator: "enopravilno")]
    [JsonDerivedType(typeof(Question_MultipleCorrectAnswers), typeDiscriminator: "vecpravilnih")]
    [JsonDerivedType(typeof(Question_OpenType), typeDiscriminator: "odprto")]
    public abstract class Question
    {
        public string Text { get; set; }
        public List<string> Answers { get; set; }
        public List<int> CorrectAnswers { get; set; }

        public abstract string QuestionType { get; }
        public abstract bool CheckAnswer(List<int> userAnswers);
        public abstract void WriteQuestion();
    }

    public class Question_OneCorrectAnswer : Question
    {
        public override string QuestionType => "En pravilen odgovor";

        public override bool CheckAnswer(List<int> userAnswers)
        {
            return userAnswers.Count == 1 &&
                   CorrectAnswers.Count == 1 &&
                   userAnswers[0] == CorrectAnswers[0];
        }

        public override void WriteQuestion()
        {
            Console.WriteLine($"\n[En pravilen odgovor] {Text}");
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {Answers[i]}");
            }
        }
    }

    public class Question_MultipleCorrectAnswers : Question
    {
        public override string QuestionType => "Več pravilnih odgovorov";

        public override bool CheckAnswer(List<int> userAnswers)
        {
            if (userAnswers.Count != CorrectAnswers.Count)
                return false;

            var sortedUser = new List<int>(userAnswers);
            var sortedCorrect = new List<int>(this.CorrectAnswers);
            sortedUser.Sort();
            sortedCorrect.Sort();

            for (int i = 0; i < sortedUser.Count; i++)
            {
                if (sortedUser[i] != sortedCorrect[i])
                    return false;
            }
            return true;
        }

        public override void WriteQuestion()
        {
            Console.WriteLine($"\n[Več pravilnih odgovorov] {Text} (izberite vse pravilne)");
            for (int i = 0; i < Answers.Count; i++)
            {
                Console.WriteLine($"  {i + 1}. {Answers[i]}");
            }
        }
    }

    public class Question_OpenType : Question
    {
        public override string QuestionType => "Odprto";

        public override bool CheckAnswer(List<int> userAnswers)
        {
            // Za odprta vprašanja vedno vrnemo true
            // V realni aplikaciji bi to zahtevalo ročen pregled
            return true;
        }

        public override void WriteQuestion()
        {
            Console.WriteLine($"\n[Odprto vprašanje] {Text}");
            Console.WriteLine("  Odgovor: ________________________________");
        }
    }

    /// <summary>
    /// Razred za shranjevanje celotnega izpita
    /// </summary>
    public class Exam
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public List<Question> Questions { get; set; }

        public Exam()
        {
            Questions = new List<Question>();
            Created = DateTime.Now;
        }
    }

    public class ExamResults
    {
        public string Subject { get; set; }
        public DateTime ExaminationDate { get; set; }
        public string UserName { get; set; }
        public int NumberOfCorrectAnswers { get; set; }
        public int TotalQuestions { get; set; }
        public double Grade { get; set; }

        public ExamResults()
        {
            ExaminationDate = DateTime.Now;
        }
    }
}
