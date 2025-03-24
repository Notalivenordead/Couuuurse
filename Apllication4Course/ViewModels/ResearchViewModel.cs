using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class ResearchViewModel : BaseViewModel
    {
        public ObservableCollection<Исследования> Researches { get; set; }

        public ResearchViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                Researches = new ObservableCollection<Исследования>(context.Исследования.ToList());
            }
        }
    }
}