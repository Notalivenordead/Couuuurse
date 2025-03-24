using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class FinancialOperationViewModel : BaseViewModel
    {
        public ObservableCollection<Финансовые_Операции> FinancialOperations { get; set; }

        public FinancialOperationViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                FinancialOperations = new ObservableCollection<Финансовые_Операции>(context.ФинансовыеОперации.ToList());
            }
        }
    }
}