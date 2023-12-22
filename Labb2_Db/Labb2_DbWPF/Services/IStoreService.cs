using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2_Db.Entities;

namespace Labb2_DbWPF.Services
{
    public interface IStoreService
    {
        IQueryable<Store> GetStores();
    }
}
