using Apllication4Course.Models;
using Apllication4Course.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System;

public class ComplaintLogViewModel : SearchSortViewModel<Журнал_Обращений>
{
    public ObservableCollection<Журнал_Обращений> ComplaintLogs => Items;

    public ComplaintLogViewModel()
    {
        AddCommand = new RelayCommand(AddNewItem);
        EditCommand = new RelayCommand(EditSelectedItem, () => IsEditEnabled);
        DeleteCommand = new RelayCommand(DeleteSelectedItem, () => IsDeleteEnabled);
        SaveCommand = new RelayCommand(SaveChanges);

    }

    protected override Dictionary<string, Expression<Func<Журнал_Обращений, object>>> CreateSortProperties()
    {
        return new Dictionary<string, Expression<Func<Журнал_Обращений, object>>>
        {
            ["ФИО"] = x => x.ФИО_Обратившегося,
            ["Дата обращения"] = x => x.Дата_Обращения,
            ["Тип обращения"] = x => x.Тип_Обращения
        };
    }

    protected override bool FilterPredicate(Журнал_Обращений item)
    {
        if (string.IsNullOrWhiteSpace(SearchText))
            return true;

        // Ищем по основным полям (регистронезависимо)
        return (item.ФИО_Обратившегося != null && item.ФИО_Обратившегося.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
               (item.КонтактныйТелефон != null && item.КонтактныйТелефон.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0) ||
               (item.Тип_Обращения != null && item.Тип_Обращения.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0);
    }
}
