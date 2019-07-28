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
        public RepositoryWrapper(RepositoryContext repositoryContext, IMapper mapper)
        {
            repoContext = repositoryContext;
            Mapper = mapper;
        }
        private readonly IMapper Mapper;

        private RepositoryContext repoContext;
        private IUserRepository user;

        public IUserRepository User
        {
            get
            {
                if (user == null)
                {
                    user = new UserRepository(repoContext, Mapper);
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
