using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExecuteSql
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.initPage();
        }

        private void initPage()
        {
            this.tbx_sql.Text = string.Empty;
            this.tbx_sql.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string strCon = ConfigurationManager.ConnectionStrings["sqlcc"].ConnectionString;
                using (SqlConnection conn = new SqlConnection(strCon))
                {
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(this.tbx_sql.Text, conn);
                    da.SelectCommand.CommandTimeout = 300;
                    da.SelectCommand.CommandType = CommandType.Text;

                    da.Fill(ds);
                    this.tbx_sql.Text = "成功";
                }
            }
            catch (Exception ex)
            {
                this.tbx_sql.Text = ex.Message + "\n" + ex.StackTrace;
                //this.tbx_sql.Focus();
                //this.tbx_sql.SelectAll();
            }
        }

        private void tbx_sql_GotFocus(object sender, RoutedEventArgs e)
        {
            if (this.tbx_sql.Text.Contains("行号"))
            {
                this.tbx_sql.Text = string.Empty;
            }
        }
    }
}
