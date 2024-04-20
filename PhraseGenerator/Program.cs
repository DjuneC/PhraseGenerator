using System.Net.NetworkInformation;

namespace PhraseGenerator
{
    internal class Program
    {
        static (string, string, string) RandomSentences(string[] subjects, string[] verbs, string[] complements)
        {
            Random random = new Random();
            int randomIndex = random.Next(0, subjects.Length);
            return (subjects[randomIndex], verbs[randomIndex], complements[randomIndex]);
        }
        static void Main(string[] args)
        {
            const int NB_SENTENCES = 100;
            var sentences = new List<string>();
            int doublon = 0;

            string[] subjects = { "The cat", "The dog", "I", "We", "They", "A stranger", "The car" };
            string[] verbs = { "ran", "slept", "ate", "jumped", "played", "talked", "drove" };
            string[] complements = { "across the street", "on the couch", "a delicious meal", "over the fence", "with a ball", "to their friend", "to the store" };
            
            for (int i = 0; i < NB_SENTENCES; i++)
            {
                (string randomSubjects, string randomVerbs, string randomComplements) = RandomSentences(subjects, verbs, complements);
                string randomSentences = $"{randomSubjects} {randomVerbs} {randomComplements}";

                if (sentences.Contains(randomSentences))
                {
                    doublon++;
                }
                else
                {
                    sentences.Add(randomSentences);
                }
            }

            foreach (string sentence in sentences)
            {
                Console.WriteLine(sentence);
            }

            Console.WriteLine();
            Console.WriteLine("-------------------");
            Console.WriteLine($"Unique sentences generated: {sentences.Count}");
            Console.WriteLine($"Doublon evite: {doublon}");
        }
    }
}
