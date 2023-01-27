using CRM.Domain.Entities;

namespace CRM.Frontend.Models
{
    public class CompaniesVM
    {
        public CompaniesVM(IEnumerable<Company> companies) 
        {
            Companies= companies;
        }
        public IEnumerable<Company> Companies { get; private set; }
    }
}
