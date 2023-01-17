using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using CRM.DAL.Common;
using EnsureThat;

namespace CRM.DAL
{
    public class BaseRepository
    {
        protected DataContext dataContext;
        protected string OUTPUT_ID_SQL = "output inserted.id"; //used to return the id of the newly inserted entity in the database
        public BaseRepository(DataContext dataContext)
        {            
            Ensure.That(dataContext, nameof(dataContext)).IsNotNull();            
            this.dataContext = dataContext;
        }
    }
}
