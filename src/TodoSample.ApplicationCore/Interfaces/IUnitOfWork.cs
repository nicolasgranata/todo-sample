using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TodoSample.ApplicationCore.Interfaces
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();

        int Save();
    }
}
