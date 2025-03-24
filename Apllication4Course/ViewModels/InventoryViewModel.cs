using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class InventoryViewModel : BaseViewModel
    {
        public ObservableCollection<Инвентарь> Inventory { get; set; }

        public InventoryViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                Inventory = new ObservableCollection<Инвентарь>(context.Инвентарь.ToList());
            }
        }
    }
}