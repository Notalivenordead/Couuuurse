using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class SampleViewModel : BaseViewModel
    {
        public ObservableCollection<Образцы> Samples { get; set; }

        public SampleViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                Samples = new ObservableCollection<Образцы>(context.Образцы.ToList());
            }
        }
    }
}