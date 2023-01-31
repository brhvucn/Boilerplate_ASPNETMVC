using CRM.Domain.Dto;

namespace CRM.Frontend.Models
{
    public class CompaniesVM
    {
        public CompaniesVM() 
        {
        }
        public IEnumerable<CompanyDto> Companies { get; set; }
    }
}
