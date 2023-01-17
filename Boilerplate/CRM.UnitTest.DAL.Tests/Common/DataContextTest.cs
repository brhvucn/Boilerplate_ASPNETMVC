using CRM.DAL.Common;
using Microsoft.Extensions.Configuration;
using Moq;

namespace CRM.UnitTest.DAL.Tests.Common
{
    public class DataContextTest
    {
        [Fact]
        public void Ctor_DataContxt_ExpectFailure()
        {
            Assert.Throws<ArgumentNullException>(()=>new DataContext(null));
        }
    }
}