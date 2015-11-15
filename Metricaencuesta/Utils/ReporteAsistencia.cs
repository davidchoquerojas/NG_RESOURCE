using System;
using System.Collections.Generic;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using Metricaencuesta.Models;
using System.Web;

namespace Metricaencuesta.Utils
{
    public class ReporteAsistencia
    {
        public String differenceTime(String first, String two)
        {
            var date1 = first.Trim() == "" ? DateTime.Now.ToShortTimeString() : first;
            var date2 = two.Trim() == "" ? DateTime.Now.ToShortTimeString() : two;
            var time1 = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " " + date1 + ":00");
            var time2 = Convert.ToDateTime(System.DateTime.Now.ToShortDateString() + " " + date2 + ":00");
            TimeSpan rest = time2 - time1;
            if (rest.Hours > 0)
                return rest.Hours + " Hr (s) | " + rest.Minutes + " Min.";
            else if (rest.Minutes > 0)
                return rest.Minutes + " Min (s).";
            else
            {
                if (rest.Hours <= 0)
                    return rest.Hours + " Hr (s) | " + rest.Minutes + " Min.";
                else if(rest.Minutes <= 0)
                    return rest.Minutes + " Min (s).";
                else
                    return "0 Min";
            }
        }
        public String exportExcel(List<asistenciaReport> o)
        {
            var font = new ReporteEncuestaExcel();
            var book = new XSSFWorkbook();
            String[] heads = { "Empresa", "Usuario", "Fecha Asistencia", "Hora Ingreso Est.", "Hora Ingreso Marcado", "IP_Ingreso","Diferencia Ingreso", "Hora Salida Est.", "Hora Salida Marcado","IP_Salida","Diferencia Salida" };
            var sheet = book.CreateSheet("Asistencia_" + System.DateTime.Now.AddHours(-7).ToString("dd-mm-yyyy"));
            var rHeader = sheet.CreateRow(1);
            ICell cHeader;
            for (var i = 0; i < heads.Length; i++)
            {
                cHeader = rHeader.CreateCell(i + 1);
                cHeader.SetCellValue(heads[i]);
                cHeader.CellStyle = font.setFontText(12, true, book);

            }
            
            //recorrer data
            for (var r = 0; r < o.Count; r++)
            {
                IRow rBody = sheet.CreateRow(r + 2);
                ICell cbody;

                cbody = rBody.CreateCell(1);
                cbody.SetCellValue(o[r].razon_social);
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(2);
                cbody.SetCellValue(o[r].usuario);
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(3);
                cbody.SetCellValue(o[r].fecha_asistencia.ToShortDateString());
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(4);
                cbody.SetCellValue(o[r].hora_ingresoS.ToString());
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(5);
                cbody.SetCellValue(o[r].hora_ingreso.ToString());
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(6);
                cbody.SetCellValue(o[r].ip_ingreso.ToString());
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(7);
                cbody.SetCellValue(this.differenceTime(o[r].hora_ingresoS, o[r].hora_ingreso));
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(8);
                cbody.SetCellValue(o[r].hora_SalidaS);
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(9);
                cbody.SetCellValue(o[r].hora_salida);
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(10);
                cbody.SetCellValue(o[r].ip_salida);
                cbody.CellStyle = font.setFontText(10, false, book);

                cbody = rBody.CreateCell(11);
                cbody.SetCellValue(this.differenceTime(o[r].hora_SalidaS, o[r].hora_salida));
                cbody.CellStyle = font.setFontText(10, false, book);
            }
           
            var guide = "Reporte_asistencia_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            using (var file = new FileStream(@HttpContext.Current.Server.MapPath("~/Utils/xlsxs/") + guide.ToString() + ".xlsx", FileMode.Create, FileAccess.ReadWrite))
            {
                book.Write(file);
                file.Close();
            }

            return guide.ToString();
        }
    }
}