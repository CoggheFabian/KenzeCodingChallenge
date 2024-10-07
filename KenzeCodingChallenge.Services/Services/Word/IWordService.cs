using KenzeCodingChallenge.Application.Services.Word.Model;
using KenzeCodingChallenge.Application.Services.Word.Models;

namespace KenzeCodingChallenge.Services.Services.Word
{
    public interface IWordService
    {
        Dictionary<string, List<string>> GetWordsCombinations(List<string> words, WordCombinationCriteria wordCombinationCriteria);
        IEnumerable<CombinedWord> FilterOutCombinationsThatAreNotInTheOrginalList(Dictionary<string, List<string>> possibleCombinations, List<string> allWords);
        List<string> GetWords();
    }
}
