using CRM.DAL.Common;
using CRM.DAL.Contracts;
using CRM.Domain.Entities;
using CRM.Domain.ValueObjects;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DAL
{
    //This repository is a little bit special since it stores 3 different objects in the same table (Company, Email and Address).
    //this is shown in the different methods to read and write
    public class CompanyRepository : BaseRepository, ICompanyRepository
    {
        public CompanyRepository(DataContext context) : base(context)
        {
        }

        public async Task<Company> CreateAsync(Company entity)
        {
            using(var connection = dataContext.CreateConnection())
            {
                string command = $"insert into {TableNames.CompanyTableName} (Name, Street, City, ZipCode, Email) {OUTPUT_ID_SQL} values (@name, @street, @city, @zip, @email)";
                string street = entity.Address != null ? entity.Address.Street : "";
                string city = entity.Address != null ? entity.Address.City : ""; ;
                string zipCode = entity.Address != null ? entity.Address.ZipCode : "";
                string email = entity.Email != null ? entity.Email.Value : ""; //should never happen, there are guard clauses on the Email object to ensure this is never null
                int newId = await connection.QuerySingleAsync<int>(command, new { name = entity.Name, street = street, city = city, zip = zipCode, email = email });
                entity.Id = newId;
                return entity;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using(var connection = dataContext.CreateConnection())
            {
                string command = $"delete from {TableNames.CompanyTableName} where id = @id";
                //construct the email and the Address objects
                await connection.ExecuteAsync(command, new { id = id });
            }
        }

        private Company CreateCompany(dynamic row)
        {
            //extract the data. Do not use the built in converter, since we need to build Email and Address valueObjects
            int id = (int)row.Id;
            string name = row.Name;
            string street = row.Street;
            string city = row.City;
            string zip = row.ZipCode;
            string email = row.Email;
            //construct the object
            Email emailObject = Email.Create(email); //we assume email is always present, since we have guard clauses to prevent it from being null
            Company company = new Company(name, emailObject);
            company.Id = id;
            if(
                !string.IsNullOrEmpty(street) &&
                !string.IsNullOrEmpty(city) &&
                !string.IsNullOrEmpty(zip))
            {
                //only create the address if all fields are present
                Address address = Address.Create(street, city, zip);
                company.Address = address;
            }
            return company;
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            List<Company> result = new List<Company>();
            using (var connection = dataContext.CreateConnection())
            {
                string command = $"select * from {TableNames.CompanyTableName}";
                var dbResult = await connection.QueryAsync(command);
                foreach(var row in dbResult)
                {                   
                    //construct the object and add it to the list
                    Company company = CreateCompany(row);
                    result.Add(company);
                }
            }
            return result;
        }

        public async Task<Company> GetFromIdAsync(int id)
        {
            using(var connection = dataContext.CreateConnection())
            {
                string query = $"select * from {TableNames.CompanyTableName} where id = @id";
                var dbResult = await connection.QueryAsync(query, new {id = id});
                Company result = CreateCompany(dbResult);
                return result;
            }
        }

        public async Task UpdateAsync(Company entity)
        {
            //first update the name
            using(var connection = dataContext.CreateConnection())
            {
                string command = $"update {TableNames.CompanyTableName} set Name = @name where id = @id";
                await connection.ExecuteAsync(command, new {id = entity.Id, name = entity.Name});
            }
            //then update the address
            if (entity.Address != null)
            {
                await UpdateAddressAsync(entity.Address, entity.Id);
            }
            //and then the email
            if (entity.Email != null)
            {
                //this should be impossible, since email can never be null
                await UpdateEmailAsync(entity.Email, entity.Id);
            }
        }

        private async Task UpdateAddressAsync(Address address, int companyId)
        {
            using (var connection = dataContext.CreateConnection())
            {
                string command = $"update {TableNames.CompanyTableName} set Street = @street, City = @city, ZipCode = @zip where id = @id";
                await connection.ExecuteAsync(command, new { street = address.Street, city = address.City, zip = address.ZipCode, id = companyId });
            }
        }

        private async Task UpdateEmailAsync(Email email, int companyId)
        {
            using(var connection = dataContext.CreateConnection())
            {
                string command = $"update {TableNames.CompanyTableName} set email = @email where id = @id";
                await connection.ExecuteAsync(command, new {email = email.Value, id = companyId});
            }
        }
    }
}
