using Apllication4Course.Models.Reports;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Input;

namespace Apllication4Course.ViewModels
{
    public class FinancialOperationReportViewModel : SearchSortViewModel<FinancialOperationReport>
    {
        public ObservableCollection<FinancialOperationReport> FinancialOperationReports => Items;
        public SeriesCollection IncomeExpenseSeries { get; set; }
        public SeriesCollection ServiceRevenueSeries { get; set; }
        public List<string> IncomeExpenseLabels { get; set; }
        public List<string> ServiceRevenueLabels { get; set; }
        public ICommand ExportToExcelCommand { get; }
        public ICommand ExportToWordCommand { get; }

        public FinancialOperationReportViewModel()
        {
            LoadData();
            ExportToExcelCommand = new RelayCommand(ExportToExcel);
            ExportToWordCommand = new RelayCommand(ExportToWord);
            InitializeCharts();
        }

        private void InitializeCharts()
        {
            // 1. Круговая диаграмма: Приход/Возврат
            var income = FinancialOperationReports
                .Where(x => x.Тип_Операции == "Оплата")
                .Sum(x => x.Сумма);

            var refund = FinancialOperationReports
                .Where(x => x.Тип_Операции == "Возврат")
                .Sum(x => x.Сумма);

            IncomeExpenseSeries = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Приход",
                    Values = new ChartValues<double> { Convert.ToDouble(income) }, 
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Возврат",
                    Values = new ChartValues<double> { Convert.ToDouble(refund) },   
                    DataLabels = true
                }
            };

            IncomeExpenseLabels = new List<string> { "Приход", "Возврат" };

            // 2. Столбчатая диаграмма: Доходы по видам услуг
            var serviceRevenue = FinancialOperationReports
                .Where(x => x.Тип_Операции == "Оплата")
                .GroupBy(x => x.Услуга)
                .Select(g => new { Service = g.Key, TotalRevenue = g.Sum(x => x.Сумма) })
                .ToList();

            ServiceRevenueSeries = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Доходы",
                    Values = new ChartValues<double>(serviceRevenue.Select(x => Convert.ToDouble(x.TotalRevenue))),
                    DataLabels = true
                }
            };

                    ServiceRevenueLabels = serviceRevenue.Select(x => x.Service).ToList();
                }

        private void ExportToExcel()
        {
            var result = MessageBox.Show(
                "Вы хотите экспортировать данный отчёт в Excel?",
                "Подтверждение экспорта",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Financial Operations");

                // Заголовки
                worksheet.Cell(1, 1).Value = "ID Операции";
                worksheet.Cell(1, 2).Value = "Услуга";
                worksheet.Cell(1, 3).Value = "Сумма";
                worksheet.Cell(1, 4).Value = "Тип операции";
                worksheet.Cell(1, 5).Value = "Дата операции";
                worksheet.Cell(1, 6).Value = "Способ оплаты";
                worksheet.Cell(1, 7).Value = "ФИО ответственного";

                // Данные
                int row = 2;
                foreach (var item in FinancialOperationReports)
                {
                    worksheet.Cell(row, 1).Value = item.ID_Операции;
                    worksheet.Cell(row, 2).Value = item.Услуга;
                    worksheet.Cell(row, 3).Value = item.Сумма;
                    worksheet.Cell(row, 4).Value = item.Тип_Операции;
                    worksheet.Cell(row, 5).Value = item.Дата_Операции.ToString("dd.MM.yyyy HH:mm:ss");
                    worksheet.Cell(row, 6).Value = item.Способ_Оплаты;
                    worksheet.Cell(row, 7).Value = item.ФИО_Ответственного;
                    row++;
                }

                // Сохранение файла
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = $"FinancialOperationsReport_{DateTime.Now:yyyy_MM_dd}"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                }
            }
        }

        private void ExportToWord()
        {
            var result = MessageBox.Show(
                "Вы хотите экспортировать данный отчёт в Word?",
                "Подтверждение экспорта",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Word Files|*.docx",
                    FileName = $"FinancialOperationsReport_{DateTime.Now:yyyy_MM_dd}"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(saveFileDialog.FileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                    {
                        var mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        var body = new Body();

                        // Заголовок
                        var paragraph = new Paragraph(new Run(new Text("Financial Operations Report")));
                        paragraph.ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center });
                        body.Append(paragraph);

                        // Таблица
                        var table = new Table();
                        var headerRow = new TableRow(
                            new TableCell(new Paragraph(new Run(new Text("ID Операции")))),
                            new TableCell(new Paragraph(new Run(new Text("Услуга")))),
                            new TableCell(new Paragraph(new Run(new Text("Сумма")))),
                            new TableCell(new Paragraph(new Run(new Text("Тип операции")))),
                            new TableCell(new Paragraph(new Run(new Text("Дата операции")))),
                            new TableCell(new Paragraph(new Run(new Text("Способ оплаты")))),
                            new TableCell(new Paragraph(new Run(new Text("ФИО ответственного"))))
                        );
                        table.Append(headerRow);

                        foreach (var item in FinancialOperationReports)
                        {
                            var dataRow = new TableRow(
                                new TableCell(new Paragraph(new Run(new Text(item.ID_Операции.ToString())))),
                                new TableCell(new Paragraph(new Run(new Text(item.Услуга)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Сумма.ToString())))),
                                new TableCell(new Paragraph(new Run(new Text(item.Тип_Операции)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Дата_Операции.ToString("dd.MM.yyyy HH:mm:ss"))))),
                                new TableCell(new Paragraph(new Run(new Text(item.Способ_Оплаты)))),
                                new TableCell(new Paragraph(new Run(new Text(item.ФИО_Ответственного))))
                            );
                            table.Append(dataRow);
                        }

                        body.Append(table);
                        mainPart.Document.Body = body;
                        mainPart.Document.Save();
                    }
                }
            }
        }

        protected override Dictionary<string, Expression<Func<FinancialOperationReport, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<FinancialOperationReport, object>>>
            {
                ["Услуга"] = x => x.Услуга,
                ["Сумма"] = x => x.Сумма,
                ["Тип операции"] = x => x.Тип_Операции,
                ["Дата операции"] = x => x.Дата_Операции,
                ["Способ оплаты"] = x => x.Способ_Оплаты,
                ["ФИО ответственного"] = x => x.ФИО_Ответственного
            };
        }

        protected override bool FilterPredicate(FinancialOperationReport item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;

            // Поиск по дате
            if (item.Дата_Операции != null)
            {
                if (item.Дата_Операции.Day.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Month.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Year.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Операции.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Операции.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Операции.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Поиск по сумме
            if (decimal.TryParse(SearchText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal searchTemp))
            {
                if (item.Сумма == searchTemp)
                    return true;
            }

            if (item.Сумма.ToString(CultureInfo.InvariantCulture).Contains(SearchText))
                return true;

            // Поиск по текстовым полям
            return item.Услуга?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Тип_Операции?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Способ_Оплаты?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.ФИО_Ответственного?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}