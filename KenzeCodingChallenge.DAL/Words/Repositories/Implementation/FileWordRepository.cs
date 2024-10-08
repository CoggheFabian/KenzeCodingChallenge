using KenzeCodingChallenge.DAL.Words.Repositories.Interface;

namespace KenzeCodingChallenge.DAL.Words.Repositories.Implantation
{
    public class FileWordRepository : IWordRepository
    {
        public IEnumerable<string> GetWords(string filePath)
        {
            return File.ReadAllLines(filePath)
               .Where(x => !string.IsNullOrEmpty(x))
               .Select(x => x.Trim())
               .ToList();
        }

        public IEnumerable<string> GetWords()
        {
            throw new InvalidOperationException("The word repository does only support file operations.");
        }
    }
}
