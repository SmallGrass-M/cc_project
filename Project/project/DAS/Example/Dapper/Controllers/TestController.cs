using Dapper;
using DapperTest.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperTest.Controllers
{
    public class TestController : Controller
    {
        private string sqlconnection = "Data Source=.;Initial Catalog=DapperTest;User Id=sa;Password=sasa;";
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(sqlconnection);
            connection.Open();
            return connection;
        }

        public IEnumerable<ColumnCat> Select()
        {
            using (IDbConnection conn = OpenConnection())
            {
                const string query = "select * from ColumnCat order by id desc";
                return conn.Query<ColumnCat>(query, null);
            }
        }
        public IEnumerable<ColumnCat> SelectMuch()
        {
            using (IDbConnection conn = OpenConnection())
            {
                const string query = "SELECT ColumnCat.id,ColumnCat.name,ColumnCatid FROM ColumnCat JOIN [Column] ON ColumnCat.Id = [Column].ColumnCatid";
                return conn.Query<ColumnCat, Column, ColumnCat>(query, (a, b) => { a.ColumnList.Add(b); return a; }, splitOn: "ColumnCatid");//splitOn为第二个对象开始截取的列
            }
        }


        // GET: Test
        public ActionResult Index()
        {
            return View(SelectMuch().ToList());
        }
    }
}