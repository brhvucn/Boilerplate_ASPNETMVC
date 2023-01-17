﻿using CRM.Domain.Common;
using CRM.Domain.Dto;
using CRM.Domain.Request.Company;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BLL.Contracts
{
    public interface ICompanyFacade
    {
        Task<Result<CompanyDto>> CreateCompany(CreateCompanyRequest request);
    }
}
