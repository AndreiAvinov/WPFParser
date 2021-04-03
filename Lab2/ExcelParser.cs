using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class ExcelParser
    {
        public static List<CyberDanger> GetDataFromFile(string path)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var file = new FileInfo(path);
            var dangersList = new List<CyberDanger>();
            using (var p = new ExcelPackage(file))
            {
                var ws = p.Workbook.Worksheets["Sheet"];
                int rowsNum = ws.Dimension.End.Row;
                for (int i = 3; i < rowsNum; i++)
                {
                    var danger = new CyberDanger();
                    int.TryParse(ws.Cells[i, 1].Text, out danger.id);
                    danger.name = ws.Cells[i, 2].Text;
                    danger.description = ws.Cells[i, 3].Text;
                    danger.source = ws.Cells[i, 4].Text;
                    danger.target = ws.Cells[i, 5].Text;
                    danger.conf = ws.Cells[i, 6].Text == "1";
                    danger.integrity = ws.Cells[i, 7].Text == "1";
                    danger.access = ws.Cells[i, 8].Text == "1";
                    dangersList.Add(danger);
                }
            }
            return dangersList;
        }

    }
}
