using Apllication4Course.Models.Reports;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Windows.Input;
using System.Windows;

namespace Apllication4Course.ViewModels
{
    public class DeceasedMovementReportViewModel : SearchSortViewModel<DeceasedMovementReport>
    {
        public ObservableCollection<DeceasedMovementReport> DeceasedMovementReports => Items;

        public ICommand ExportToExcelCommand { get; }
        public ICommand ExportToWordCommand { get; }

        public DeceasedMovementReportViewModel()
        {
            LoadData();
            ExportToExcelCommand = new RelayCommand(ExportToExcel);
            ExportToWordCommand = new RelayCommand(ExportToWord);
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
                var worksheet = workbook.Worksheets.Add("Deceased Movements");

                // Заголовки
                worksheet.Cell(1, 1).Value = "ID Умершего";
                worksheet.Cell(1, 2).Value = "ФИО";
                worksheet.Cell(1, 3).Value = "Дата смерти";
                worksheet.Cell(1, 4).Value = "Место смерти";
                worksheet.Cell(1, 5).Value = "Причина смерти";
                worksheet.Cell(1, 6).Value = "Тип перемещения";
                worksheet.Cell(1, 7).Value = "Дата перемещения";
                worksheet.Cell(1, 8).Value = "Место отправления";
                worksheet.Cell(1, 9).Value = "Место назначения";
                worksheet.Cell(1, 10).Value = "ФИО ответственного";

                // Данные
                int row = 2;
                foreach (var item in DeceasedMovementReports)
                {
                    worksheet.Cell(row, 1).Value = item.ID_Умершего;
                    worksheet.Cell(row, 2).Value = item.ФИО;
                    worksheet.Cell(row, 3).Value = item.Дата_Смерти.ToString("dd.MM.yyyy HH:mm:ss");
                    worksheet.Cell(row, 4).Value = item.Место_Смерти;
                    worksheet.Cell(row, 5).Value = item.Причина_Смерти;
                    worksheet.Cell(row, 6).Value = item.Тип_Перемещения;
                    worksheet.Cell(row, 7).Value = item.Дата_Перемещения.ToString("dd.MM.yyyy HH:mm:ss");
                    worksheet.Cell(row, 8).Value = item.Место_Отправления;
                    worksheet.Cell(row, 9).Value = item.Место_Назначения;
                    worksheet.Cell(row, 10).Value = item.ФИО_Ответственного;
                    row++;
                }

                // Сохранение файла
                var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                {
                    Filter = "Excel Files|*.xlsx",
                    FileName = $"DeceasedMovementsReport_{DateTime.Now:yyyy_MM_dd}"
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
                    FileName = $"DeceasedMovementsReport_{DateTime.Now:yyyy_MM_dd}"
                };

                if (saveFileDialog.ShowDialog() == true)
                {
                    using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(saveFileDialog.FileName, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                    {
                        var mainPart = wordDocument.AddMainDocumentPart();
                        mainPart.Document = new Document();
                        var body = new Body();

                        // Заголовок
                        var paragraph = new Paragraph(new Run(new Text("Deceased Movements Report")));
                        paragraph.ParagraphProperties = new ParagraphProperties(new Justification { Val = JustificationValues.Center });
                        body.Append(paragraph);

                        // Таблица
                        var table = new Table();
                        var headerRow = new TableRow(
                            new TableCell(new Paragraph(new Run(new Text("ID Умершего")))),
                            new TableCell(new Paragraph(new Run(new Text("ФИО")))),
                            new TableCell(new Paragraph(new Run(new Text("Дата смерти")))),
                            new TableCell(new Paragraph(new Run(new Text("Место смерти")))),
                            new TableCell(new Paragraph(new Run(new Text("Причина смерти")))),
                            new TableCell(new Paragraph(new Run(new Text("Тип перемещения")))),
                            new TableCell(new Paragraph(new Run(new Text("Дата перемещения")))),
                            new TableCell(new Paragraph(new Run(new Text("Место отправления")))),
                            new TableCell(new Paragraph(new Run(new Text("Место назначения")))),
                            new TableCell(new Paragraph(new Run(new Text("ФИО ответственного"))))
                        );
                        table.Append(headerRow);

                        foreach (var item in DeceasedMovementReports)
                        {
                            var dataRow = new TableRow(
                                new TableCell(new Paragraph(new Run(new Text(item.ID_Умершего.ToString())))),
                                new TableCell(new Paragraph(new Run(new Text(item.ФИО)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Дата_Смерти.ToString("dd.MM.yyyy HH:mm:ss"))))),
                                new TableCell(new Paragraph(new Run(new Text(item.Место_Смерти)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Причина_Смерти)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Тип_Перемещения)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Дата_Перемещения.ToString("dd.MM.yyyy HH:mm:ss"))))),
                                new TableCell(new Paragraph(new Run(new Text(item.Место_Отправления)))),
                                new TableCell(new Paragraph(new Run(new Text(item.Место_Назначения)))),
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

        protected override Dictionary<string, Expression<Func<DeceasedMovementReport, object>>> CreateSortProperties()
        {
            return new Dictionary<string, Expression<Func<DeceasedMovementReport, object>>>
            {
                ["ФИО"] = x => x.ФИО,
                ["Дата смерти"] = x => x.Дата_Смерти,
                ["Место смерти"] = x => x.Место_Смерти,
                ["Причина смерти"] = x => x.Причина_Смерти,
                ["Тип перемещения"] = x => x.Тип_Перемещения,
                ["Дата перемещения"] = x => x.Дата_Перемещения,
                ["Место отправления"] = x => x.Место_Отправления,
                ["Место назначения"] = x => x.Место_Назначения,
                ["ФИО ответственного"] = x => x.ФИО_Ответственного
            };
        }

        protected override bool FilterPredicate(DeceasedMovementReport item)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
                return true;

            // Поиск по дате смерти
            if (item.Дата_Смерти != null)
            {
                if (item.Дата_Смерти.Day.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Month.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Year.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Смерти.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Смерти.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Смерти.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Поиск по дате перемещения
            if (item.Дата_Перемещения != null)
            {
                if (item.Дата_Перемещения.Day.ToString().Contains(SearchText) ||
                    item.Дата_Перемещения.Month.ToString().Contains(SearchText) ||
                    item.Дата_Перемещения.Year.ToString().Contains(SearchText) ||
                    item.Дата_Перемещения.Hour.ToString().Contains(SearchText) ||
                    item.Дата_Перемещения.Minute.ToString().Contains(SearchText) ||
                    item.Дата_Перемещения.Second.ToString().Contains(SearchText))
                {
                    return true;
                }

                if (item.Дата_Перемещения.ToString("dd.MM.yyyy HH:mm:ss").Contains(SearchText) ||
                    item.Дата_Перемещения.ToString("yyyy-MM-dd HH:mm:ss").Contains(SearchText))
                {
                    return true;
                }
            }

            // Поиск по текстовым полям
            return item.ФИО?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Место_Смерти?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Причина_Смерти?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Тип_Перемещения?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Место_Отправления?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.Место_Назначения?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0 ||
                   item.ФИО_Ответственного?.IndexOf(SearchText, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}