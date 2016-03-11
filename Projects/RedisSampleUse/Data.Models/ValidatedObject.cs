namespace Data.Models
{
    public class ValidatedObject
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public ValidationStatus Status { get; set; }
    }
}
