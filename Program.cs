using System.Reflection.PortableExecutable;

namespace WordOfDay
{
    internal class Program
    {
        static string def = "russian";

        static void Main(string[] args)
        {
            Console.WriteLine("Текущий язык: "+def);
            string PP = Path.GetFullPath("WordOfDay.sln") + @"\dir";
            Console.WriteLine(PP);
            if (!Directory.Exists(PP))
            {
                Directory.CreateDirectory(PP);
                CDir(def, PP);
            }
            else 
            {
                if(!File.Exists(PP+@$"\filter_profanity_{def}_cached.txt")) 
                {
                    CDir(def, PP);
                }
            }
            PP += @$"\filter_profanity_{def}_cached.txt";
            List<string> words = File.ReadLines(PP).ToList();
            bool end = false;
            int k = 1;
            while (!end)
            {
                Console.WriteLine($"Попытка №{k}");
                end = Slovo(words, Bukva());
                k++;
            }
        }
        static public void CDir(string lang,string pp)
        {
            //string PF = Path.GetFullPath($"filter_profanity_{lang}_cached.txt");
            string PF = $"C:\\Users\\1\\Desktop\\filter_profanity_{lang}_cached.txt";
            Console.WriteLine( PF );
            FileInfo fi = new FileInfo(PF);
            fi.CopyTo(pp+ @$"\\filter_profanity_{def}_cached.txt");
        }
        static public char Bukva()
        {
            Random rnd = new();
            int a = 1104;
            while (a == 1104)
            { a = rnd.Next(1072, 1105); }
            Console.WriteLine($"Буква - {Convert.ToChar(a)}");
            return (char)a;
        }
        static public bool Slovo(List<string> slovarb, char a)
        {
            List<int> nums = new();
            for (int i = 0; i<slovarb.Count(); i++)
            {
                string s = slovarb[i];
                if (s[0] == a)
                {
                    nums.Add(i);
                }
            }
            if (nums.Count == 0) 
            {
                return false;
            }
            Random rnd = new();
            Console.WriteLine($"{slovarb[nums[rnd.Next(0,nums.Count)]]}");
            return true;
        }
    }
}