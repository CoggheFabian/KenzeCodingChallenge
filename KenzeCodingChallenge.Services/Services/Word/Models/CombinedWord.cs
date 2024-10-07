namespace KenzeCodingChallenge.Application.Services.Word.Model
{
    public class CombinedWord
    {
        public string OrginalWord { get; set; } = string.Empty;
        public List<string> Parts { get; set; } = new List<string>();

        public override string ToString()
        {
            return $"{this.OrginalWord} + {string.Join(" + ", Parts)} = {this.OrginalWord}{string.Join("", Parts)}";
        }
    }
}
