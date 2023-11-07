﻿using MathLearner.Domain.Entities;
using MathLearner.Domain.Repositories;

namespace MathLearner.PersistenceDatabaseEF.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext dbContext) : base (dbContext)
        {
        }
    }
}
