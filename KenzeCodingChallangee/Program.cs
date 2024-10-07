//(Note) => For simplicy Sake I will use this as the "Presentation" Layer.
//(Note) => Instead of doing this manually DI should handle the 'summon' of the interface with the implementation.

using KenzeCodingChallenge.Application.Services.Word.Models;
using KenzeCodingChallenge.DAL.Words.Repositories.Implantation;
using KenzeCodingChallenge.DAL.Words.Repositories.Interface;
using KenzeCodingChallenge.Services.Services.Word;

IWordRepository wordRepository = new FileWordRepository();
IWordService wordService = new WordService(wordRepository);

try
{
    var allWords = wordService.GetWords();
    var wordCombinations = wordService.GetWordsCombinations(allWords, new WordCombinationCriteria(maximumLength: 6));

    var wordCombinationsThatAreInTheAllWordsList = wordService.FilterOutCombinationsThatAreNotInTheOrginalList(wordCombinations, allWords);
    foreach (var wordCombinationThatIsInOriginalist in wordCombinationsThatAreInTheAllWordsList)
    {
        Console.WriteLine(wordCombinationThatIsInOriginalist.ToString());
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}
