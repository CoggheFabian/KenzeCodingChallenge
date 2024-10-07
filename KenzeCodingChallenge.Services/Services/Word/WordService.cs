using KenzeCodingChallenge.Application.Services.Word.Model;
using KenzeCodingChallenge.Application.Services.Word.Models;
using KenzeCodingChallenge.DAL.Words.Repositories.Interface;

namespace KenzeCodingChallenge.Services.Services.Word
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordService;

        public WordService(IWordRepository wordService)
        {
            _wordService = wordService;
        }

        public List<string> GetWords()
        {
            //NOTE => In a real world scenario you would get the "Path" from the DB or appsetting file depending on the requirement. Im putting it to keep this example simple
            var path = "input.txt";
            var checkIfPathExist = File.Exists(path);
            if (!checkIfPathExist) throw new FileNotFoundException($"The path {path} was not found");
            return _wordService.GetWords(path).ToList();
        }

        public Dictionary<string, List<string>> GetWordsCombinations(List<string> words, WordCombinationCriteria wordCombinationCriteria)
        {
            Dictionary<string, List<string>> wordCombinations = [];

            foreach (var word in words)
            {
                var key = word;
                var wordCount = word.Length;
                var remainingLength = wordCombinationCriteria.MaximumLength - wordCount;
                var wordsThatCanFit = words.Where(x => x.Length <= remainingLength && x != key).ToList();
                var wordCombinationsThatCanStillFit = FindPossibleWordsThatCanStillFitForWordCombination(wordsThatCanFit, remainingLength);
                if (wordCombinationsThatCanStillFit.Any())
                {
                    if (!wordCombinations.ContainsKey(key))
                    {
                        wordCombinations.Add(key, new List<string>(wordCombinationsThatCanStillFit));
                    }
                }
            }

            return wordCombinations;
        }

        public IEnumerable<CombinedWord> FilterOutCombinationsThatAreNotInTheOrginalList(Dictionary<string, List<string>> possibleCombinations, List<string> allWords)
        {
            foreach (var possibleCombination in possibleCombinations)
            {
                var key = possibleCombination.Key;
                var value = possibleCombination.Value.ToList();
                var combinedWord = key + string.Join("", value);
                if (allWords.Contains(combinedWord))
                {
                    yield return new CombinedWord() { OrginalWord = key, Parts = value };
                }
            }
        }

        private List<string> FindPossibleWordsThatCanStillFitForWordCombination(List<string> words, int remainingCount)
        {
            int index = 0;
            List<string> wordsCombinationsThatArePossible = new List<string>();
            while (remainingCount > 0 && index < words.Count)
            {
                var word = words[index];
                var remainingCountAfterNewWordIsAdded = remainingCount - word.Length;
                if (word.Length <= remainingCount && remainingCountAfterNewWordIsAdded >= 0)
                {
                    wordsCombinationsThatArePossible.Add(word);
                    remainingCount -= word.Length;
                }
                index++;
            }
            return wordsCombinationsThatArePossible;
        }
    }
}
