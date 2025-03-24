using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class SampleUsageViewModel : BaseViewModel
    {
        public ObservableCollection<Использование_Образцов> SampleUsages { get; set; }

        public SampleUsageViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                SampleUsages = new ObservableCollection<Использование_Образцов>(context.ИспользованиеОбразцов.ToList());
            }
        }
    }
}