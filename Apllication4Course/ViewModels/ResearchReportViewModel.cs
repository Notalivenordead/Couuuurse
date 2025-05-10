using Apllication4Course.Models.Reports;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Windows;
using System.Windows.Input;

namespace Apllication4Course.ViewModels
    {
        public class ResearchReportViewModel : SearchSortViewModel<ResearchReport>
        {
            public ObservableCollection<ResearchReport> ResearchReports => Items;

        public ICommand ExportToExcelCommand { get; }
        public ICommand ExportToWordCommand { get; }

        public ResearchReportViewModel()
        {
            LoadData();
            ExportToExcelCommand = new RelayCommand(ExportToExcel);
            ExportToWordCommand = new RelayCommand(ExportToWord);
        }

        private void ExportToExcel()
        {
            // Подтверждение экспорта
            var result = MessageBox.Show(
                "Вы хотите экспортировать данный отчёт в Excel?",
                "Подтверждение экспорта",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Research Reports");

                // Заголовки
                worksheet.Cell(1, 1).Value = "ID Исследования";
                worksheet.Cell(1, 2).Value = "ФИО умершего";
                worksheet.Cell(1, 3).Value = "Тип исследования";
                worksheet.Cell(1, 4).Value = "Дата проведения";
                worksheet.Cell(1, 5).Value = "Описание";
                worksheet.Cell(1, 6).Value = "Результаты";
                worksheet.Cell(1, 7).Value = "ФИО исполнителя";

                // Данные
                int row = 2;
                foreach (var item in ResearchReports)
                {
                    worksheet.Cell(row, 1).Value = item.ID_Исследования;
                    worksheet.Cell(row, 2).Value = item.ФИО_Умершего;
                    worksheet.Cell(row, 3).Value = item.Тип_Исследования;
                    worksheet.Cell(row, 4).Value = item.Дата_Проведения.ToString("dd.MM.yyyy HH:mm:ss");
                    worksheet.Cell(row, 5).Value = item.Описание;
                    worksheet.Cell(row, 6).Value = item.Результаты;
                    worksheet.Cell(row, 7).Value = item.ФИО_Исполнителя;
                    row++;
                }

                // Сохранение файла
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = $"ResearchReport_{DateTime.Now:yyyy_MM_dd}"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                }
            }
        }

        private void ExportToWord()
        {
            // Подтверждение экспорта
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
                    FileName = $"ResearchReport_{DateTime.Now:yyyy_MM_dd}"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(saveFileDialog.FileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                    {
                        var mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        var body = new Body();

                        // Заголовок
                        var paragraph = new Paragraph(new Run(new Text("Research Report")));
                        paragraph.ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center });
                        body.Append(paragraph);

                        // Таблица
                        var table = new Table();
                        var headerRow = new TableRow(
                            new TableCell(new Paragraph(new Run(new Text("ID Исследования")))),
                            new TableCell(new Paragraph(new Run(new Text("ФИО умершего")))),
                            new TableCell(new Paragraph(new Run(new Text("Тип исследования")))),
                            new TableCell(new Paragraph(new Run(new Text("Дата проведения")))),
                            new TableCell(new Paragraph(new Run(new Text("Описание")))),
                            new TableCell(new Paragraph(new Run(new Text("Результаты")))),
                            new TableCell(new Paragraph(new Run(new Text("ФИО исполнителя"))))
                        );
                        table.Append(headerRow);

                        foreach (var item in ResearchReports)
                        {
                            var dataRow = new TableRow(
                                new TableCell(new Paragraph(new Run(new Text(item.ID_Исследования.ToString())))),
                                new TableCell(new Paragraph(new Run(new Text(item.ФИО_Умершего)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Тип_Исследования)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Дата_Проведения.ToString("dd.MM.yyyy HH:mm:ss"))))),
                                new TableCell(new Paragraph(new Run(new Text(item.Описание)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Результаты)))),
                                new TableCell(new Paragraph(new Run(new Text(item.ФИО_Исполнителя))))
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

        protected override Dictionary<string, Expression<Func<ResearchReport, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<ResearchReport, object>>>
            {
                ["ФИО умершего"] = x => x.ФИО_Умершего,
                ["Тип исследования"] = x => x.Тип_Исследования,
                ["Дата проведения"] = x => x.Дата_Проведения,
                ["Описание"] = x => x.Описание,
                ["Результаты"] = x => x.Результаты,
                ["ФИО исполнителя"] = x => x.ФИО_Исполнителя
            };
        }

        protected override bool FilterPredicate(ResearchReport item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;

            // Поиск по дате проведения
            if (item.Дата_Проведения != null)
            {
                if (item.Дата_Проведения.Day.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Month.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Year.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Проведения.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Проведения.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Проведения.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Поиск по текстовым полям
            return item.ФИО_Умершего?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Тип_Исследования?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Описание?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Результаты?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.ФИО_Исполнителя?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}