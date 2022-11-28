using IdentityTest.Models;

namespace IdentityTest.Bussiness
{
    public class SeedData
    {
        public SeedingDbTestContext context;
        public SeedData(SeedingDbTestContext _context)
        {
            context = _context;
        }
        public async Task seedData()
        {
            try
            {
                if (!context.Documents.Any())
                {
                    List<Document> documents = new List<Document> {
                    new Document
                    {
                        name = "test",
                        TotalAmount = "200",
                        testChar="test"
                    },
                    new Document
                    {
                        name = "test1",
                        TotalAmount = "400",
                        testChar="test"
                    },
                    new Document
                    {
                        name = "test2",
                        TotalAmount = "300",
                        testChar="test"
                    },
                };
                    context.Documents.AddRange(documents);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
}
