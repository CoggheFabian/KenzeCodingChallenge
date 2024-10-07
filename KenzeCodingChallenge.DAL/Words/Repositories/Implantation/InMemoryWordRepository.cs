using KenzeCodingChallenge.DAL.Words.Repositories.Interface;

namespace KenzeCodingChallenge.DAL.Words.Repositories.Implantation
{
    public class InMemoryWordRepository : IWordRepository
    {
        public IEnumerable<string> GetWords()
        {
            return  new List<string>
            {
                "fo",
                "bar",
                "o",
                "hah",
                "lor",
                "fofoo"
            };
        }

        public IEnumerable<string> GetWords(string filePath)
        {
            throw new InvalidOperationException("The word repository does not support file operations.");
        }
    }
}
