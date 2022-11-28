namespace IdentityTest.Models
{
    public class Taxes
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string TotalAmount { get; set; }
        public string TaxType { get; set; }
        public DocumentLine DocumentLine { get; set; }
    }
}
