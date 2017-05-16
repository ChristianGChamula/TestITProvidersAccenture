using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExamenAccenture
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************************");
            Console.WriteLine("testHammingDistanceProblem");
            Console.WriteLine("**********************************");

            testHammingDistanceProblem();

            Console.WriteLine("");
            Console.WriteLine("**********************************");
            Console.WriteLine("SimpleTextSearchProblem");
            Console.WriteLine("**********************************");
          
            SimpleTextSearchProblem();

            Console.WriteLine("");

            Console.WriteLine("");
            Console.WriteLine("**********************************");
            Console.WriteLine("CharacterCountProblem");
            Console.WriteLine("**********************************");

            CharacterCountProblem();

            Console.WriteLine("");
            Console.ReadKey();
        }

        private static void testHammingDistanceProblem()
        {
            //"A", "A";// # => 0
            //"A", "G";//                         # => 1
            //"AG", "CT";//                      # => 2
            //"AGG", "AGA";//                     # => 1
            //"GATACA", "GCATAA";//             # => 4
            //"GGACGGATTCTG", "AGGACGGATTCT";//    # => 9
            //string source, target = "";
            //source = "GGACGGATTCTG";
            //target = "AGGACGGATTCT";
            var sourceList = new string[]
            {
                "A", // # => 0
                "A",  // # => 1
                "AG",  // # => 2
                "AGG",  // # => 1
                "GATACA", // # => 4
                "GGACGGATTCTG" // # =>9
            };
            var targetList = new string[]
            {
                "A",
                "G",
                "CT",
                "AGA",
                "GCATAA",
                "AGGACGGATTCT",

            };

            for (int i = 0; i < sourceList.Length; i++)
            {
                var distance = HammingDistanceProblem(sourceList[i],targetList[i]);
                Console.WriteLine(" {0} - {1} // # => {2}", sourceList[i], targetList[i], distance);
            }
            //Console.ReadKey();
        }

        static void CharacterCountProblem()
        {
            var text = "hey there";
            var textOnlyLetter = Regex.Replace(text, @"[^a-z]", "");// Replace(@"[a-z]", "_"); ;

            var textloop = textOnlyLetter.Distinct().ToArray();
            var totalChars = textloop.Count();
            //var countCharacter = text.
            var result = "";
            for (int i = 0; i < totalChars; i++)
            {
                var pat = @"[" + textloop[i] + "]";

                result = result + textloop[i] + ": " + Regex.Matches(text, pat).Count.ToString() + ", ";

            }
            result = text + ": {" + result.Remove(result.LastIndexOf(",")) + "}";
            Console.WriteLine(result);
            
        }

        static int HammingDistanceProblem(string source, string target)
        {
            if (source.Length != target.Length)
                throw new ArgumentException("Both input strings must be of the same length.");

            int distance = 0;
            for (int i = 0, length = source.Length; i < length; i++)
            {
                if (source[i] != target[i])
                    distance++;
            }

            return distance;
        }

        static void SimpleTextSearchProblem()
        {
            
            var hmlText = "wqewqe555-5555qwewqeq  wewq(555) 555-5555sadd fdfdf5555555yyyy 555 555-5555 rrttg ght555-555-5555t htrht 55555555 thtr55555555 5555555555 55555555555";
            var phonePattern = @"(\(?\d{3}\) *\d{3}-? *-\d{4})|(\d{3}-\d{4})|(\d{3}\-*\d{3}-? *-\d{4})";

            var matchCollection = Regex.Matches(hmlText, phonePattern);

            foreach (var item in matchCollection)
            {
                Console.WriteLine(item);
            }
            
            
        }
    }
}
