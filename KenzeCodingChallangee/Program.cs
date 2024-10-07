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
    //(Note) => I've included the minimumWords in the params only so I could put the check there that it't can't be lower then 0.
    var wordCombinations = wordService.GetWordsCombinations(allWords, new WordCombinationCriteria(maximumLength: 6, minimumWords: 2, maximumWords: int.MaxValue));

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
