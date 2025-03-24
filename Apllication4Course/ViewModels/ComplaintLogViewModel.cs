using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class ComplaintLogViewModel : BaseViewModel
    {
        public ObservableCollection<Журнал_Обращений> ComplaintLogs { get; set; }

        public ComplaintLogViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                ComplaintLogs = new ObservableCollection<Журнал_Обращений>(context.ЖурналОбращений.ToList());
            }
        }
    }
}