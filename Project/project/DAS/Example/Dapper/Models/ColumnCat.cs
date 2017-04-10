using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;

namespace DapperTest.Models
{
    public class ColumnCat
    {
        public ColumnCat()
        {
            ColumnList = new List<Column>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ModifiedOn { get; set; }
        public List<Column> ColumnList { get; set; }
    }
}