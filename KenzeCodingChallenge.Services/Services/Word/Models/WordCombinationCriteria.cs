namespace KenzeCodingChallenge.Application.Services.Word.Models
{
    public class WordCombinationCriteria
    {
        public int MaximumLength { get; }

        public WordCombinationCriteria(int maximumLength)
        {
            if (maximumLength <= 0)
            {
                throw new ArgumentException("Maximum length must be greater than 0.", nameof(maximumLength));
            }
           

            MaximumLength = maximumLength;
        }
    }

}
