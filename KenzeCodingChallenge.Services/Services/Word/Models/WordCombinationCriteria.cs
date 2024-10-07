namespace KenzeCodingChallenge.Application.Services.Word.Models
{
    public class WordCombinationCriteria
    {
        public int MaximumLength { get; }
        public int MinimumWords { get; }
        public int MaximumWords { get; }

        public WordCombinationCriteria(int maximumLength, int minimumWords = 2, int maximumWords = int.MaxValue)
        {
            if (maximumLength <= 0)
            {
                throw new ArgumentException("Maximum length must be greater than 0.", nameof(maximumLength));
            }
            if (minimumWords <= 0)
            {
                throw new ArgumentException("Minimum words must be greater than 0.", nameof(minimumWords));
            }

            MaximumLength = maximumLength;
            MinimumWords = minimumWords;
            MaximumWords = maximumWords;
        }
    }

}
