namespace Domain
{
    public class Document
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public bool Signed { get; set; }

        public Document()
        {
        }
    }
}