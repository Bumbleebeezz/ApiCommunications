using Labb2_Db.Entities;
using Labb2_DbWPF.Managers;
using Labb2_DbWPF.Services;
using Microsoft.EntityFrameworkCore;

namespace Labb2_DbWPF.ViewModels;

public class AddProductViewModel : ViewModel
{
    private readonly IStoreService storeService;
    private List<Store> stores = new();


    public AddProductViewModel(IStoreService storeService)
    {
        this.storeService = storeService;
    }

    public async Task<List<Store>> GetStores()
    {
        return await storeService.GetStores().ToListAsync();
    }
}