using AutoMapper;
using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public RepositoryWrapper(SchedulerContext repositoryContext, IMapper mapper)
        {
            repoContext = repositoryContext;
            Mapper = mapper;
        }
        private readonly IMapper Mapper;

        private SchedulerContext repoContext;
        private IUserRepository user;

        public IUserRepository User
        {
            get
            {
                if (user == null)
                {
                    user = new UserRepository(repoContext, repoContext.Users, Mapper);
                }
                return user;
            }
        }


        public void Save()
        {
            repoContext.SaveChanges();
        }
    }
}
