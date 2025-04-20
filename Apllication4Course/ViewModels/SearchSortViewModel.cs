using Apllication4Course.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Windows.Input;
using System;
using System.Linq;

public abstract class SearchSortViewModel<T> : BaseDataViewModel<T> where T : class, new()
{
    private string _searchText;
    private string _selectedSortProperty;
    private ListSortDirection _sortDirection = ListSortDirection.Ascending;
    private Dictionary<string, Expression<Func<T, object>>> _sortProperties;

    public string SearchText
    {
        get => _searchText;
        set => Set(ref _searchText, value);
    }

    public string SelectedSortProperty
    {
        get => _selectedSortProperty;
        set => Set(ref _selectedSortProperty, value);
    }

    public ListSortDirection SortDirection
    {
        get => _sortDirection;
        set => Set(ref _sortDirection, value);
    }

    public ObservableCollection<string> SortProperties { get; }
    public ICommand ApplyFilterCommand { get; }
    public ICommand SortAscendingCommand { get; protected set; }
    public ICommand SortDescendingCommand { get; protected set; }

    protected SearchSortViewModel()
    {
        _sortProperties = CreateSortProperties();
        SortProperties = new ObservableCollection<string>(_sortProperties.Keys);
        SelectedSortProperty = SortProperties.FirstOrDefault();

        ApplyFilterCommand = new RelayCommand(ApplyFilterAndSort);
        SortAscendingCommand = new RelayCommand(() =>
        {
            SortDirection = ListSortDirection.Ascending;
            ApplyFilterAndSort();
        });

        SortDescendingCommand = new RelayCommand(() =>
        {
            SortDirection = ListSortDirection.Descending;
            ApplyFilterAndSort();
        });
    }

    protected abstract Dictionary<string, Expression<Func<T, object>>> CreateSortProperties();
    protected abstract bool FilterPredicate(T item);

    protected virtual void ApplyFilterAndSort()
    {
        if (_items == null) return;

        var result = new ObservableCollection<T>();

        // Применяем фильтрацию
        foreach (var item in _items)
        {
            if (string.IsNullOrWhiteSpace(SearchText) || FilterPredicate(item))
                result.Add(item);
        }

        // Применяем сортировку
        if (_sortProperties.TryGetValue(SelectedSortProperty, out var sortExpression))
        {
            var sorted = SortDirection == ListSortDirection.Ascending
                ? result.OrderBy(sortExpression.Compile())
                : result.OrderByDescending(sortExpression.Compile());

            result = new ObservableCollection<T>(sorted);
        }

        // Полностью заменяем коллекцию Items
        Items.Clear();
        foreach (var item in result)
            Items.Add(item);

        OnPropertyChanged(nameof(Items));
    }

    protected override void LoadData() => base.LoadData();
}