using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Labb2_Db.Entities;

namespace Labb2_DbWPF.Services
{
    public class StoreService: IStoreService
    {
        private readonly Labb1BookShopContext context;

        public StoreService(Labb1BookShopContext context)
        {
            this.context = context;
        }
        public IQueryable<Store> GetStores()
        {
            return context.Stores;
        }
    }
}
