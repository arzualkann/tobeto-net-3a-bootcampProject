using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFramework.Contexts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.Repositories
{
    public class ApplicationRepository : EfRepositoryBase<Application, int, BaseDbContext>, IApplicationRepository
    {
        public ApplicationRepository(BaseDbContext context) : base(context)
        {
        }

    }
}
