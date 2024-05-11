using System;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace LabelMaker
{
    public static class SqlHepler
    {
        #region 类属性
        /// <summary>别名
        /// 
        /// </summary>
        public static string Alias { get; set; }

        /// <summary>数据库连接字符串
        /// 
        /// </summary>
        public static string ConnString { get; set; }

        /// <summary>数据库连接打开状态，
        /// /true:连接打开,false:未打开/
        /// </summary>
        public static bool SqlConnOpenState => sqlConn != null && sqlConn.State == ConnectionState.Open;

        /// <summary>数据库操作状态
        /// 
        /// </summary>
        public static ConnectionState SqlConnState => sqlConn.State;

        public static bool IsOpening { get; private set; } = false;

        #endregion

        private static SqlConnection sqlConn;

        /// <summary>打开数据库连接
        /// 
        /// </summary>
        /// <returns>(bool)打开状态</returns>
        public static bool SqlOpen()
        {
            IsOpening = true;
            if (string.IsNullOrEmpty(ConnString))
            {
                Say($"数据库连接字符串为空{NowString()}");
                return false;
            }
            try
            {
                sqlConn = new SqlConnection(ConnString);
                // Say($"SqlOpen> >Connection Timeout = {sqlConn.ConnectionTimeout}{NowString()}");
                sqlConn.Open();//打开数据库连接
                Say($"SqlOpen> >conn status = {sqlConn.State}{NowString()}");
            }
            catch (Exception ex)
            {
                Say($"SqlOpen> >error!{ex.Message}{NowString()}");
            }
            IsOpening = false;
            return SqlConnOpenState;
        }

        /// <summary>异步打开，不阻塞调用线程。
        /// 
        /// </summary>
        public static async void OpenAsync()
        {
            //  var cts = new CancellationTokenSource(200);
            // cts.Token.Register(() => Say($"Open DB is timeout,cancel.{NowString()}"));
            bool b = await Task.Run<bool>(() =>
            {
                return SqlOpen();
            });
        }

        /// <summary>关闭数据库连接
        /// 
        /// </summary>
        public static void SqlClose()
        {
            sqlConn.Close();//关闭连接 
            Say($"SqlClose> >{ sqlConn.State}{NowString()}");
        }

        //2.下面来封装第一个SqlHepler方法，封装一个执行的sql 返回受影响的行数。
        public static int ExecuteNonQuery(string sqlText, params SqlParameter[] parameters)
        {
            // using SqlConnection conn = new SqlConnection(GetSqlConnctingString());
            using SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandText = sqlText;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteNonQuery();
        }
        //3.继续封装一个查询操作，返回查询结果中的第一行第一列的值
        public static object ExecuteScalar(string sqlText, params SqlParameter[] parameters)
        {
            // using SqlConnection conn = new SqlConnection(GetSqlConnctingString());
            using SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandText = sqlText;
            cmd.Parameters.AddRange(parameters);
            return cmd.ExecuteScalar();
        }
        //4.在封装个常用的查询方法，返回一个DataTable
        public static DataTable ExecuteDataTable(string sqlText, params SqlParameter[] parameters)
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(sqlText, sqlConn))
            {
                DataTable dt = new DataTable();
                adapter.SelectCommand.Parameters.AddRange(parameters);
                adapter.Fill(dt);
                return dt;
            }
        }
        //5.最后在写封装一个查询方法,该方法返回的是一个SqlDataReader类型
        public static SqlDataReader ExecuteReader(string sqlText, params SqlDataReader[] parameters)
        {
            //SqlDataReader要求，它读取数据的时候有，它独占它的SqlConnection对象，而且SqlConnection必须是Open状态
            // SqlConnection conn = new SqlConnection(GetSqlConnctingString());//不要释放连接，因为后面还需要连接打开状态
            SqlCommand cmd = sqlConn.CreateCommand();
            cmd.CommandText = sqlText;
            cmd.Parameters.AddRange(parameters);
            //CommandBehavior.CloseConnection当SqlDataReader释放的时候，顺便把SqlConnection对象也释放掉
            return cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>根据名字调用存储过程，
        /// 提供参数集，并返回记录集。
        /// </summary>
        /// <param name="procedureName">存储过程名字</param>
        /// <param name="parameters">参数集</param>
        /// <returns></returns>
        public static DataSet StoredProcedureHasReturnDataSet(string procedureName, ref SqlParameter[] parameters)
        {
            if (!SqlConnOpenState)
            {
                Say($"StoredProcedureHasReturnDataSet> >数据库未打开{NowString()}");
                return null;
            }
            SqlCommand cmdStr = new SqlCommand()
            {
                Connection = sqlConn,
                CommandText = procedureName,
                CommandType = CommandType.StoredProcedure
            };
            cmdStr.Parameters.AddRange(parameters);
            SqlDataAdapter sqlData = new SqlDataAdapter(cmdStr);
            DataSet ds = new DataSet();

            sqlData.Fill(ds);
            Say($"StoredProcedureStatus> >Tables count = {ds.Tables.Count }{NowString()}");
            return ds;
        }
        /// <summary>根据名字调用存储过程，
        /// 提供参数集。
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        public static void StoredProcedure(string procedureName, ref SqlParameter[] parameters)
        {
            if (!SqlConnOpenState) return;
            SqlCommand cmdStr = new SqlCommand()
            {
                Connection = sqlConn,
                CommandText = procedureName,
                CommandType = CommandType.StoredProcedure
            };
            cmdStr.Parameters.AddRange(parameters);
            cmdStr.ExecuteNonQuery();
        }


        private static string NowString() => $"<{DateTime.Now.ToString("HH:mm:ss.fff")}>";

        private static void Say(string msg = "") => Console.WriteLine($"{Alias ?? "SqlHepler"}> >{msg}");


    }
}
