using System.Collections.ObjectModel;
using System.Linq;
using Apllication4Course.Models;
using Apllication4Course.Services;

namespace Apllication4Course.ViewModels
{
    public class PaidResearchViewModel : BaseViewModel
    {
        private ObservableCollection<Платные_Исследования> _paidResearches;

        public ObservableCollection<Платные_Исследования> PaidResearches
        {
            get
            {
                if (_paidResearches == null)
                {
                    LoadData();
                }
                return _paidResearches;
            }
        }

        private void LoadData()
        {
            using (var context = DatabaseContext.Instance)
            {
                System.Diagnostics.Debug.WriteLine("Loading paid researches...");
                var paidResearchesList = context.ПлатныеИсследования.AsNoTracking().ToList();
                System.Diagnostics.Debug.WriteLine($"Loaded {paidResearchesList.Count} paid researches.");
                _paidResearches = new ObservableCollection<Платные_Исследования>(paidResearchesList);
            }
        }
    }
}