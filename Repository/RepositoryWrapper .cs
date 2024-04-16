using Contract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _context;
        private IUserRepository _userRepository;
        
        public RepositoryWrapper(RepositoryContext context)
        {
            _context = context;
        }

        public IUserRepository User 
        {
            
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository(_context);

                return _userRepository;
            }

            /*set
            {
                _userRepository = value;
            }*/
            
           
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void SaveChanges()
        { 
            _context.SaveChanges(); 
        }
    }
}
