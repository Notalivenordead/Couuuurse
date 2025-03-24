using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class ServiceViewModel : BaseDataViewModel<Услуги>
    {
        public ObservableCollection<Услуги> Services => Items as ObservableCollection<Услуги>;
    }
}