using Metricaencuesta.Data;
using System;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using System.Web;
using NPOI.SS.Util;
using NPOI.HSSF.Util;

namespace Metricaencuesta.Utils
{
    class ReporteEncuestaExcel
    {
        public String GenerateExcel(DateTime fecha_ini,DateTime fecha_fin)
        {
            try
            {
                new Utils.DeleteFile().deleteFile(HttpContext.Current.Server.MapPath(@"~/Utils/xlsxs/"));
                XSSFWorkbook book = new XSSFWorkbook();
                var ReporteGpregunta = new ReporteEncuestaDB().getData(1, fecha_ini, fecha_fin);

                if (ReporteGpregunta.Count == 0)
                    return string.Empty;

                String[] hPersona = { "N°", "NOMBRES Y APELLIDOS DEL \n COLABORADOR", "EVALUADOR", "EMPRESA" };
                var sheet = book.CreateSheet("Reporte 1");
                //Titulo cabecera 1
                var rGpregunta = sheet.CreateRow(1);
                ICell cGpregunta;
                var cellMerge = 4;
                var contador = 0;
                //subtitulo de cabecera 1
                var ReportePregunta = new ReporteEncuestaDB().getData(2, fecha_ini, fecha_fin);
                var rPregunta = sheet.CreateRow(2);
                rPregunta.Height = 39 * 39;
                ICell cPregunta;
                var contCell = 4;
                while (contador < ReporteGpregunta.Count)
                {
                    var endIndex = ReporteGpregunta[contador].cont_idPregunta + cellMerge;
                    sheet.AddMergedRegion(new CellRangeAddress(1, 1, cellMerge, endIndex));
                    cGpregunta = rGpregunta.CreateCell(cellMerge);
                    cGpregunta.SetCellValue(ReporteGpregunta[contador].gdescripcion);
                    cGpregunta.CellStyle = setFontText(12, true, book);
                    cellMerge += ReporteGpregunta[contador].cont_idPregunta + 1;

                    var listPregunta = ReportePregunta.FindAll(p => p.id_gpregunta == ReporteGpregunta[contador].id_gpregunta);
                    for (int i = 0; i <= listPregunta.Count; i++)
                    {
                        cPregunta = rPregunta.CreateCell(contCell);
                        if (i == listPregunta.Count)
                            cPregunta.SetCellValue("TOTAL");
                        else
                            cPregunta.SetCellValue(listPregunta[i].pdescripcion);
                        cPregunta.CellStyle = setFontText(9, true, book);
                        cPregunta.CellStyle.WrapText = true;
                        contCell++;
                    }
                    contador++;
                }
                String[] ultimacelda = { "TOTAL", "EVALUACIÓN POR DESEMPEÑO" };
                for (int u = 0; u < ultimacelda.Length; u++)
                {
                    cGpregunta = rGpregunta.CreateCell(contCell + u);
                    cGpregunta.SetCellValue(ultimacelda[u]);
                    cGpregunta.CellStyle = setFontText(12, true, book);
                    cGpregunta.CellStyle.WrapText = true;
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, cellMerge + u, cellMerge + u));
                }

                //titulo cabecera datos personas 1
                ICell cPersona;
                for (int i = 0; i < hPersona.Length; i++)
                {
                    if (i > 0) sheet.SetColumnWidth(i, 5000);
                    cPersona = rGpregunta.CreateCell(i);
                    cPersona.SetCellValue(hPersona[i]);
                    cPersona.CellStyle = setFontText(12, true, book);
                    sheet.AddMergedRegion(new CellRangeAddress(1, 2, i, i));
                    cPersona.CellStyle.WrapText = true;
                }

                //cuerpo de pregunta
                var ReporteContPersona = new ReporteEncuestaDB().getData(3, fecha_ini, fecha_fin);
                var ReportePuntaje = new ReporteEncuestaDB().getData(4, fecha_ini, fecha_fin);
                for (int i = 0; i < ReporteContPersona.Count; i++)
                {
                    var rPuntaje = sheet.CreateRow(3 + i);
                    var id_empleado = ReporteContPersona[i].id_empleado;
                    ICell cPuntaje;
                    var listPuntaje = ReportePuntaje.FindAll(p => p.id_empleado == id_empleado);

                    cPuntaje = rPuntaje.CreateCell(0);
                    cPuntaje.SetCellValue(i + 1);
                    cPuntaje.CellStyle = setFontText(10, false, book);

                    cPuntaje = rPuntaje.CreateCell(1);
                    cPuntaje.SetCellValue(listPuntaje[0].empleado);
                    cPuntaje.CellStyle = setFontText(10, false, book);

                    cPuntaje = rPuntaje.CreateCell(2);
                    cPuntaje.SetCellValue(listPuntaje[0].evaluador);
                    cPuntaje.CellStyle = setFontText(10, false, book);

                    cPuntaje = rPuntaje.CreateCell(3);
                    cPuntaje.SetCellValue(listPuntaje[0].empresa);
                    cPuntaje.CellStyle = setFontText(10, false, book);
                    var countPuntaje = 4;
                    var totalPuntaje = 0;
                    for (int f = 0; f < ReporteGpregunta.Count; f++)
                    {
                        var listPreguntaDet = listPuntaje.FindAll(g => g.id_gpregunta == ReporteGpregunta[f].id_gpregunta);
                        var totalDet = 0;
                        for (int c = 0; c <= listPreguntaDet.Count; c++)
                        {
                            cPuntaje = rPuntaje.CreateCell(countPuntaje);
                            if (c == listPreguntaDet.Count)
                                cPuntaje.SetCellValue(totalDet);
                            else
                            {
                                totalDet += listPreguntaDet[c].puntaje;
                                cPuntaje.SetCellValue(listPreguntaDet[c].puntaje);
                            }
                            cPuntaje.CellStyle = setFontText(10, false, book);
                            countPuntaje++;
                        }
                        totalPuntaje += totalDet;
                    }

                    cPuntaje = rPuntaje.CreateCell(countPuntaje);
                    cPuntaje.SetCellValue(totalPuntaje);
                    cPuntaje.CellStyle = setFontText(14, false, book);

                    cPuntaje = rPuntaje.CreateCell(countPuntaje + 1);
                    cPuntaje.SetCellValue(totalPuntaje >= 71 ? "ALTO" : totalPuntaje >= 45 ? "MEDIO" : "BAJO");
                    cPuntaje.CellStyle = setFontText(14, false, book);
                }

                var guide = "Reporte_consolidado_mensual_" + DateTime.Now.ToString("yyyyMMddHHmmss");
                using (var file = new FileStream(HttpContext.Current.Server.MapPath(@"~/Utils/xlsxs/") + guide.ToString() + ".xlsx", FileMode.Create, FileAccess.ReadWrite))
                {
                    book.Write(file);
                    file.Close();
                }
                return guide.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICellStyle setFontText(short point,bool color,XSSFWorkbook book)
        {
            var font = book.CreateFont();
            font.FontName = "Calibri";
            font.Color = (IndexedColors.Black.Index);
            font.FontHeightInPoints = point;

            var style = book.CreateCellStyle();
            style.SetFont(font);
            style.Alignment = HorizontalAlignment.Center;
            style.VerticalAlignment = VerticalAlignment.Center;
            if (color)
            {
                style.FillForegroundColor = HSSFColor.Grey25Percent.Index;
                style.FillPattern = FillPattern.SolidForeground;
            }
            style.BorderBottom = BorderStyle.Thin;
            style.BorderTop = BorderStyle.Thin;
            style.BorderLeft = BorderStyle.Thin;
            style.BorderRight = BorderStyle.Thin;
            return style;
        }
    }
}
