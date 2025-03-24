using Apllication4Course.Models;
using Apllication4Course.Services;
using Apllication4Course.ViewModels;
using System.Collections.ObjectModel;
using System.Linq;


namespace YourApp.ViewModels
{
    public class RequestViewModel : BaseViewModel
    {
        public ObservableCollection<Заявки_на_Платные_Услуги> Requests { get; set; }

        public RequestViewModel()
        {
            using (var context = DatabaseContext.Instance)
            {
                Requests = new ObservableCollection<Заявки_на_Платные_Услуги>(context.ЗаявкиНаПлатныеУслуги.ToList());
            }
        }
    }
}