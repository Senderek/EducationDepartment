using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using EducationDepartment.Domain.Core.Domain.Entities;
using EducationDepartment.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace EducationDepartment.Infrastructure.Entityframework.Reporting
{
    public class WordReporting : IWordReportSrv
    {
        public void CreateReport(Stream stream, List<ReportingArticle> articles)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(stream, WordprocessingDocumentType.Document, true))
            {
                // Add a main document part. 
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                // Create the document structure and add some text.
                mainPart.Document = new Document();
                var docBody = mainPart.Document.AppendChild(new Body());

                Table table = new Table();

                TableProperties tblProperties = new TableProperties();
                TableBorders tblBorders = new TableBorders();

                TopBorder topBorder = new TopBorder();
                topBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
                topBorder.Color = "CC0000";
                tblBorders.AppendChild(topBorder);

                BottomBorder bottomBorder = new BottomBorder();
                bottomBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
                bottomBorder.Color = "CC0000";
                tblBorders.AppendChild(bottomBorder);

                RightBorder rightBorder = new RightBorder();
                rightBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
                rightBorder.Color = "CC0000";
                tblBorders.AppendChild(rightBorder);

                LeftBorder leftBorder = new LeftBorder();
                leftBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
                leftBorder.Color = "CC0000";
                tblBorders.AppendChild(leftBorder);

                InsideHorizontalBorder insideHBorder = new InsideHorizontalBorder();
                insideHBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
                insideHBorder.Color = "CC0000";
                tblBorders.AppendChild(insideHBorder);

                InsideVerticalBorder insideVBorder = new InsideVerticalBorder();
                insideVBorder.Val = new EnumValue<BorderValues>(BorderValues.Thick);
                insideVBorder.Color = "CC0000";
                tblBorders.AppendChild(insideVBorder);

                //// Add the table borders to the properties
                tblProperties.AppendChild(tblBorders);
                table.AppendChild(tblProperties);

                TableRow tr1 = new TableRow();

                TableCell tc11 = new TableCell();
                Paragraph p11 = new Paragraph();
                Run r11 = new Run();
                RunProperties rp11 = new RunProperties();
                rp11.Bold = new Bold();
                r11.Append(rp11);
                r11.Append(new Text("Autor"));
                p11.Append(r11);

                tc11.Append(p11);
                tr1.Append(tc11);

                TableCell tc12 = new TableCell();
                Paragraph p12 = new Paragraph();
                
                Run r12 = new Run();
                RunProperties rp12 = new RunProperties();
                rp12.Bold = new Bold();
                r12.Append(rp12);
                r12.Append(new Text("Data"));
                p12.Append(r12);
                tc12.Append(p12);

                tr1.Append(tc12);
                table.Append(tr1);

                for (int i = 0; i < articles.Count; i++)
                {
                    TableRow tr_i = new TableRow();
                    TableCell tr_i1 = new TableCell();
                    Paragraph pi1 = new Paragraph(new Run(new Text(articles[i].Author)));
                    tr_i1.Append(pi1);
                    tr_i.Append(tr_i1);

                    TableCell tr_i2 = new TableCell();
                    Paragraph pi2 = new Paragraph(new Run(new Text(articles[i].Date.ToLocalTime().ToString("dd-MM-yyyy"))));
                    tr_i2.Append(pi2);
                    tr_i.Append(tr_i2);
                    table.Append(tr_i);
                }

                // Add your table to docx body
                docBody.Append(table);

                Paragraph summaryPar = new Paragraph();
                ParagraphProperties pp22 = new ParagraphProperties();
                pp22.Justification = new Justification() { Val = JustificationValues.Center };
                summaryPar.Append(pp22);
                summaryPar.Append(new Run(new Text("Razem artykułów: " + articles.Count.ToString())));
                docBody.Append(summaryPar);
                wordDocument.Save();

            }
        }
    }
}
