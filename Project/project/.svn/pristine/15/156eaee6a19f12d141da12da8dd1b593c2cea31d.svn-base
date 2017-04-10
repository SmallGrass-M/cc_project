using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("按1回车开始:");
            Console.Read();
            Console.WriteLine("正在导入..");

            #region 导入Excel文件
            string connStr = ConfigurationManager.AppSettings["ConnectionStr"];
            //导入
            HSSFWorkbook workBook = null;
            ISheet sheet = null;
            int count = 0;
            using (FileStream file = new FileStream("易销通合同账户.xls", FileMode.Open, FileAccess.Read))
            {
                workBook = new HSSFWorkbook(file);
                sheet = workBook.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                rows.MoveNext();

                while (rows.MoveNext())
                {
                    HSSFRow row = (HSSFRow)rows.Current;

                    string ContractNumber = row.GetCell(0).StringCellValue;
                    string ContractStartTime = row.GetCell(1).StringCellValue;
                    string ContractEndTime = row.GetCell(2).StringCellValue;
                    int AccountType = 1;
                    string CompanyName = row.GetCell(4).StringCellValue;
                    string Account = row.GetCell(5).StringCellValue;
                    string BankName = row.GetCell(6).StringCellValue;
                    string SubBankName = string.Empty;
                    if (row.GetCell(7) != null)
                    {
                        SubBankName = row.GetCell(7).StringCellValue;
                    }
                    string DealerID = row.GetCell(8).StringCellValue;
                    string OrderNumber = row.GetCell(9).StringCellValue;
                    string MemberRecordStartTime = row.GetCell(10).StringCellValue;
                    string MemberRecordEndTime = row.GetCell(11).StringCellValue;

                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        SqlCommand comm = new SqlCommand();
                        comm.Connection = conn;
                        comm.CommandText = "P_InsertDealerFinanceContract";
                        comm.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] param =
                        {
                            new SqlParameter("@ContractNumber",ContractNumber),
                            new SqlParameter("@ContractStartTime",ContractStartTime),
                            new SqlParameter("@ContractEndTime",ContractEndTime),
                            new SqlParameter("@AccountType",AccountType),
                            new SqlParameter("@CompanyName",CompanyName),
                            new SqlParameter("@Account",Account),
                            new SqlParameter("@BankName",BankName),
                            new SqlParameter("@SubBankName",SubBankName),
                            new SqlParameter("@DealerID",DealerID),
                            new SqlParameter("@OrderNumber",OrderNumber),
                            new SqlParameter("@MemberRecordStartTime",MemberRecordStartTime),
                            new SqlParameter("@MemberRecordEndTime",MemberRecordEndTime)
                        };
                        comm.Parameters.AddRange(param);
                        comm.ExecuteNonQuery();
                    }
                    count++;
                }
            }
            Console.WriteLine("导入成功：" + count);
            Console.ReadKey();
            Console.ReadKey();
            #endregion
        }
    }
}
