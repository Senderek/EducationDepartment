using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationDepartment.Infrastructure.Entityframework.Reporting
{
    public class ExcelReporting : IExcelReportSrv
    {
        public Task<Stream> CreateReport()
        {
            throw new NotImplementedException();
        }
        public void CreateReport(Stream stream, List<ReportingArticle> articles)
        {
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(stream, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Employees" };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row firstRow = new Row();

                firstRow.Append(
                    ConstructCell("Lp.", CellValues.String),
                    ConstructCell("Autor", CellValues.String),
                    ConstructCell("Data", CellValues.String));

                // Insert the header row to the Sheet Data
                sheetData.AppendChild(firstRow);

                // Inserting each employee
                for (int i = 0; i < articles.Count; i++)
                {
                    var row = new Row();

                    row.Append(
                        ConstructCell((i + 1).ToString(), CellValues.Number),
                        ConstructCell(articles[i].Author, CellValues.String),
                        ConstructCell(articles[i].Date.ToString("yyyy/MM/dd"), CellValues.String));

                    sheetData.AppendChild(row);
                }
                var lastRow = new Row();
                lastRow.Append(
                    ConstructCell("", CellValues.String),
                    ConstructCell("Razem", CellValues.String),
                    ConstructCell(articles.Count.ToString(), CellValues.String));
                sheetData.AppendChild(lastRow);

                worksheetPart.Worksheet.Save();
            }
        }

        private Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }
    }
}
