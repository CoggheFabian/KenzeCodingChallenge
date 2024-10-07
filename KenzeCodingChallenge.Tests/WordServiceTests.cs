using KenzeCodingChallenge.Application.Services.Word.Models;
using KenzeCodingChallenge.DAL.Words.Repositories.Implantation;
using KenzeCodingChallenge.DAL.Words.Repositories.Interface;
using KenzeCodingChallenge.Services.Services.Word;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace KenzeCodingChallenge.Tests
{
    [TestFixture]
    public class WordServiceTests
    {
        private WordService _wordService;
        private IWordRepository _wordRepository;

        [SetUp]
        public void Setup()
        {
            //Note => Normally you should mock the Interface here, Not doing here because I'm running against my time limit (And im using a in memory list)
            _wordRepository = new InMemoryWordRepository();
            _wordService = new WordService(_wordRepository);
        }

        [Test]
        public void GetWordsCombinations_WithValidWords_ReturnsCorrectCombinations()
        {
            // Arrange
            var allWords = new List<string> { "foobar", "fo", "bar", "baz", "ob" };
            var criteria = new WordCombinationCriteria(maximumLength: 6);

            // Act
            var combinations = _wordService.GetWordsCombinations(allWords, criteria);

            // Assert
            Assert.That(combinations, Is.Not.Null);
            Assert.That(combinations.Count, Is.GreaterThan(0));
            Assert.That(combinations, Does.ContainKey("fo"));
            Assert.That(combinations["fo"], Has.Member("bar"));
        }

        [Test]
        public void GetWordsCombinations_WithNegativeMaximumLength_ThrowsArgumentException()
        {
            // Arrange
            var allWords = new List<string> { "foobar", "fo", "bar" };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var criteria = new WordCombinationCriteria(maximumLength: -1);
                _wordService.GetWordsCombinations(allWords, criteria);
            });
            Assert.That(ex.Message, Does.Contain("Maximum length must be greater than 0"));
        }

        [Test]
        public void GetWordsCombinations_WithZeroMaximumLength_ThrowsArgumentException()
        {
            // Arrange
            var allWords = new List<string> { "foobar", "fo", "bar" };

            // Act & Assert
            var ex = Assert.Throws<ArgumentException>(() =>
            {
                var criteria = new WordCombinationCriteria(maximumLength: 0);
                _wordService.GetWordsCombinations(allWords, criteria);
            });
            Assert.That(ex.Message, Does.Contain("Maximum length must be greater than 0"));
        }

        [Test]
        public void GetWordsCombinations_WithMinimumWordsGreaterThanAvailableWords_ReturnsEmpty()
        {
            // Arrange
            var allWords = new List<string> { "foo" };
            var criteria = new WordCombinationCriteria(maximumLength: 6);

            // Act
            var combinations = _wordService.GetWordsCombinations(allWords, criteria);

            // Assert
            Assert.That(combinations, Is.Not.Null);
            Assert.That(combinations, Is.Empty);
        }
    }
}
