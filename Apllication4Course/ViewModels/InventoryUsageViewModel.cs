using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class InventoryUsageViewModel : BaseViewModel
    {
        public ObservableCollection<Использование_Инвентаря> InventoryUsages { get; set; }

        public InventoryUsageViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                InventoryUsages = new ObservableCollection<Использование_Инвентаря>(context.ИспользованиеИнвентаря.ToList());
            }
        }
    }
}