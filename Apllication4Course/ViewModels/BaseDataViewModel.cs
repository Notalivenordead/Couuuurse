using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class BaseDataViewModel<T> : BaseViewModel where T : class
    {
        protected ObservableCollection<T> _items;
        protected ObservableCollection<T> Items
        {
            get
            {
                if (_items == null)
                {
                    LoadData();
                }
                return _items;
            }
        }

        protected virtual void LoadData()
        {
            var context = DatabaseContext.Instance;
            var itemsList = context.Set<T>()
                .AsNoTracking()
                .ToList();  
            _items = new ObservableCollection<T>(itemsList);
        }
    }
}