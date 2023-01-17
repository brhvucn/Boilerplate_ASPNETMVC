using CRM.DAL.Common;
using CRM.DAL.Contracts;
using CRM.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL
{
    public class ContactRepository : BaseRepository, IContactRepository
    {
        public ContactRepository(DataContext context) : base(context)
        {
        }

        public Task<Contact> CreateAsync(Contact entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Contact>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Contact> GetFromIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Contact entity)
        {
            throw new NotImplementedException();
        }
    }
}
