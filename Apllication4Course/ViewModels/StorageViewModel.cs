using System.Collections.ObjectModel;
using Apllication4Course.Models;

namespace Apllication4Course.ViewModels
{
    public class StorageViewModel : BaseDataViewModel<Камеры_Хранения>
    {
        public ObservableCollection<Камеры_Хранения> Storage => Items as ObservableCollection<Камеры_Хранения>;
    }
}