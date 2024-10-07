namespace KenzeCodingChallenge.DAL.Words.Repositories.Interface
{
    public interface IWordRepository
    {
        IEnumerable<string> GetWords();
        IEnumerable<string> GetWords(string filePath);
    }
}
