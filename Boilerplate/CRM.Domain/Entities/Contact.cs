using CRM.Domain.ValueObjects;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Domain.Entities
{
    public class Contact : Entity
    {
        public Contact(string name, Email email)
        {
            Ensure.That(name, nameof(name)).IsNotNullOrWhiteSpace();
            Ensure.That(email, nameof(email)).IsNotNull();

            Name = name;            
            Email = email;
        }

        public string Name { get; private set; } //required property
        public string Title { get; private set; } //optional
        public Email Email { get; private set; } //required property
    }
}
