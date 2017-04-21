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
                //const string query = "select * from ColumnCat where id in @ids order by id desc";
                //return conn.Query<ColumnCat>(query, new { ids = new int[] { 1, 2 } });

                //const string query = "select * from ColumnCat where id in @ids order by id desc";
                //DynamicParameters param = new DynamicParameters();
                //param.Add("ids", new int[] { 1, 2 });
                //return conn.Query<ColumnCat>(query, param);

                const string query = "select * from ColumnCat where Name in @names order by id desc";
                DynamicParameters param = new DynamicParameters();
                param.Add("names", new string[] { "小明", "小红" });
                return conn.Query<ColumnCat>(query, param);
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
            return View(Select().ToList());
        }
    }
}