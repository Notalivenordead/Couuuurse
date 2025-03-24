using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class TemperatureLogViewModel : BaseViewModel
    {
        public ObservableCollection<Журнал_Температур> TemperatureLogs { get; set; }

        public TemperatureLogViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                TemperatureLogs = new ObservableCollection<Журнал_Температур>(context.ЖурналТемператур.ToList());
            }
        }
    }
}