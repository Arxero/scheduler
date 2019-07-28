using Contracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            repoContext = repositoryContext;
        }

        private RepositoryContext repoContext;
        private IUserRepository user;

        public IUserRepository User
        {
            get
            {
                if (user == null)
                {
                    user = new UserRepository(repoContext);
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
