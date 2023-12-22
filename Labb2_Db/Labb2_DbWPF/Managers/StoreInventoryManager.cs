using System.Windows;
using Labb2_Db.Entities;
using Labb2_DbWPF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Labb2_DbWPF.Managers;

public class StoreInventoryManager
{
    private readonly IStoreService _storeService;

    public StoreInventoryManager(IStoreService storeService)
    {
        _storeService = storeService;
    }

    public  List<Store> stores = new();

    public async Task<List<Store>> GetStores()
    {
       return await _storeService.GetStores().ToListAsync();
    }
}