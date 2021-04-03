using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Pagination
    {
        public int PageIndex { get; set; }
        DataTable pagedList = new DataTable();


        public DataTable PagedTable(IList<CyberDanger> sourceList)
        {
            DataTable tableToReturn = new DataTable();
            foreach (var trans in CyberDanger.translation)
            {
                tableToReturn.Columns.Add(trans.Value);
            }
            foreach (var item in sourceList)
            {
                DataRow tableRow = tableToReturn.NewRow();
                foreach (var dictItem in CyberDanger.translation)
                {
                    Type tempType = typeof(CyberDanger);
                    FieldInfo fieldInfo = tempType.GetField(dictItem.Key);
                    tableRow[dictItem.Value] = fieldInfo.GetValue(item);
                }
                tableToReturn.Rows.Add(tableRow);
            }
            return tableToReturn;
        }
    }

}
