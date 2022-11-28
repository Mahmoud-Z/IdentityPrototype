namespace IdentityTest.Models
{
    public class Document
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string TotalAmount { get; set; }
        public string testChar { get; set; }
        public List<DocumentLine> DocumentLine { get; set; }
    }
}
