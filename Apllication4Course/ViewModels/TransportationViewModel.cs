using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class TransportationViewModel : BaseViewModel
    {
        public ObservableCollection<Транспортировка> Transportations { get; set; }

        public TransportationViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                Transportations = new ObservableCollection<Транспортировка>(context.Транспортировка.ToList());
            }
        }
    }
}