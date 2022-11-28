using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace IdentityTest.Models
{
    public class DocumentLine
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string amount { get; set; }
        public int DocumentID { get; set; }
        public Document Docuemnt { get; set; }
        public List<Taxes> Taxe { get; set; }
    }
}
