using System;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using System.Web;
using Metricaencuesta.Models;
using Metricaencuesta.Data;

namespace Metricaencuesta.Utils
{
    public class PdfGenerator
    {
        public Boolean generatePdf(String fileName, List<encuesta> e, resultado r)
        {
            try
            {
                new Utils.DeleteFile().deleteFile(@HttpContext.Current.Server.MapPath("~/Utils/pdfs/"));
                var colaborador = new EmpleadoDB().listAll(r.id_empleado);
                var evaluador = new EvaluadorDB().listAll(r.id_evaluador);

                var document = new Document(PageSize.LETTER);
                var pdfwriter = PdfWriter.GetInstance(document, new FileStream(@HttpContext.Current.Server.MapPath("~/Utils/pdfs/" + fileName), FileMode.Create));
                document.Open();
                String[] heads = { "ÁREA DEL DESEMPEÑO", "MUY BAJO", "BAJO", "MEDIO", "ALTO", "MUY ALTO" };
                String[] subHeads = { "", "1", "2", "3", "4", "5" };

                // Creamos el tipo de Font que vamos utilizar
                iTextSharp.text.Font docFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
                iTextSharp.text.Font docFont1 = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.BOLD, BaseColor.BLACK);

                document.Add(new Paragraph("Colaborador : " + colaborador[0].nombres + " " + colaborador[0].apellidos));
                document.Add(new Paragraph("Evaluador : " + evaluador[0].nombres + " " + evaluador[0].apellidos));
                document.Add(new Paragraph("Fecha : " + DateTime.Now.ToShortDateString()));
                document.Add(Chunk.NEWLINE);


                var tblEncuesta = new PdfPTable(heads.Length);
                float[] colWidth = { 1000, 150, 150, 150, 150, 150 };
                tblEncuesta.SetWidths(colWidth);
                tblEncuesta.WidthPercentage = 100;

                PdfPCell[] rowCell = new PdfPCell[heads.Length];
                for (var i = 0; i < heads.Length; i++)
                {
                    var pdfCell = new PdfPCell(new Phrase(heads[i], docFont1)) { HorizontalAlignment = Element.ALIGN_CENTER, BorderWidth = 0.75f, FixedHeight = 15f, BackgroundColor = new BaseColor(230, 230, 230) };
                    if (i == 0)
                    {
                        pdfCell.Rowspan = 2;
                        pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfCell.BorderWidthBottom = 0;
                    }
                    rowCell[i] = pdfCell;
                }
                var row1 = new PdfPRow(rowCell);
                tblEncuesta.Rows.Add(row1);

                PdfPCell[] rowCell1 = new PdfPCell[subHeads.Length];
                for (var i = 0; i < subHeads.Length; i++)
                {
                    var pdfCell = new PdfPCell(new Phrase(subHeads[i], docFont)) { BorderWidth = 0.75f, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 15f };
                    if (i == 0) pdfCell.BorderWidthTop = 0;
                    rowCell1[i] = pdfCell;
                }

                var row2 = new PdfPRow(rowCell1);
                tblEncuesta.Rows.Add(row2);

                //body table
                for (var i = 0; i < e.Count; i++)
                {
                    PdfPCell[] rowBody = new PdfPCell[heads.Length];
                    for (int c = 0; c < heads.Length; c++)
                    {
                        PdfPCell cell;
                        if (c == 0)
                        {
                            if (e[i].id_pregunta == 0)
                            {
                                cell = new PdfPCell(new Phrase(e[i].descripcion, docFont1)) { BorderWidth = 0.75f, FixedHeight = 15f };
                                cell.Colspan = 6;
                                cell.BackgroundColor = new BaseColor(230, 230, 230);

                            }
                            else
                                cell = new PdfPCell(new Phrase(e[i].descripcion, docFont)) { BorderWidth = 0.75f, FixedHeight = 15f };
                        }
                        else
                        {
                            if (c == e[i].puntaje)
                                cell = new PdfPCell(new Phrase(e[i].puntaje.ToString(), docFont)) { BorderWidth = 0.75f, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 15f };
                            else
                                cell = new PdfPCell(new Phrase(" ", docFont)) { BorderWidth = 0.75f, HorizontalAlignment = Element.ALIGN_CENTER, FixedHeight = 15f };
                        }
                        rowBody[c] = cell;
                    }
                    var row3 = new PdfPRow(rowBody);
                    tblEncuesta.Rows.Add(row3);
                }
                document.Add(tblEncuesta);

                document.Close();
                pdfwriter.Close();

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
