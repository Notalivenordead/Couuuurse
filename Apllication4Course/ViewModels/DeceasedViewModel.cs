using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class DeceasedViewModel : BaseDataViewModel<Умершие>
    {
        public ObservableCollection<Умершие> Deceased => Items as ObservableCollection<Умершие>;
    }
}