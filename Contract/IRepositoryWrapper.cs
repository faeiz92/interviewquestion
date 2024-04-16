using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        void Save();

        void SaveChanges();
    }
}
