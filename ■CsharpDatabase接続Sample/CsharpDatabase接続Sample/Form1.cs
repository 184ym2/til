using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace CsharpDatabase接続Sample
{
    public partial class Form1 : Form
    {
        /*　App.config(アプリケーション構成ファイル)の追加   
          1. プロジェクト → 新しい項目の追加 → アプリケーション構成ファイル を追加
          2. App.configにデータベースの情報を記載
        */

        /*  ConfigurationManager クラスの使用(App.config に記述したパラメータの読み込み)      
          1. 参照設定 → 参照の追加 → .NET → System.configuration を追加
          2. using ディレクティブで、System.Configuration を指定する
        */

        private readonly Other _other;
        private bool _p;

        public Form1()
        {
            InitializeComponent();

            //this：インスタンス自身(Form1)を格納する特別な変数
            //otherインスタンスに対して自分の参照(先頭アドレス)を渡すことで、other内から自分（Form1）を操作できるようにするため
            _other = new Other(this /*, 5)*/);

        }

        public void 複数データの取得()
        {
            SqlConnection sqlConnection;

            if (uiIPアドレス手入力.Checked == false)
            {
                //App.configからDBの接続情報を取得
                var connectionString = ConfigurationManager.ConnectionStrings["DB情報"].ConnectionString;

                //SqlConnectionオブジェクトを作成　
                //SqlConnection クラス：SQL Server データベースへの接続を表す　継承不可
                sqlConnection = new SqlConnection(connectionString);

                //⚠メンバ(プロパティ等)に格納する場合はusingが使えない → 上の例）格納した途端にDispose()をするとconnectionStringの初期化がされない
            }
            else
            {
                //MainFormとテキストからDBの接続情報を取得
                var builder = new SqlConnectionStringBuilder
                              {
                                  DataSource = uiIP.Text,
                                  InitialCatalog = uiスキーマ名.Text,
                                  IntegratedSecurity = true,
                                  UserID = "sa",
                                  Password = "sa"
                              };

                //SqlConnectionオブジェクトを作成　
                //SqlConnection クラス：SQL Server データベースへの接続を表す　継承不可
                sqlConnection = new SqlConnection(builder.ConnectionString);
            }

            #region if文を使わず、App.configからDB接続コマンドを取得する

            //var connectionString = ConfigurationManager.ConnectionStrings["DB情報"].ConnectionString;

            //⚠ここではusingを使える usingはネスト(入れ子)可能
            //using (var sqlConnection = new SqlConnection(connectionString))

            #endregion

            //★commandオブジェクトの作成
            using (var command = sqlConnection.CreateCommand()) //ここで[sqlConnection] → [SqlCommand] に
            {
                //Open()メソッドを呼び出すことでSQLServerへ接続する
                sqlConnection.Open();

                try
                {
                    //SqlCommand クラス：SQL Server データベースに対して実行する Transact-SQL ステートメントまたはストアド プロシージャを表します　継承不可
                    //☆SQL文の設定
                    command.CommandText = @" SELECT cd_tokui, kn_tokui FROM m_tokui WHERE cd_tokui between 1 and 10 ";

                    #region ------------他の方法：SqlCommandを定数で表す(SQL文の設定からExecuteReader()メソッドの呼び出しまで)-------------

                    //☆SQL文の設定
                    const string cmdText = @" SELECT cd_tokui, kn_tokui FROM m_tokui WHERE cd_tokui between 1 and 10 ";

                    //★commandオブジェクトの作成
                    var commandCopy = new SqlCommand(cmdText, sqlConnection);
                    using (var readerCopy = commandCopy.ExecuteReader()) //ここで[SqlCommand] → [SqlDataReader] に
                    {
                        //得意先cdと得意先名の取得
                    }

                    #endregion　-----------------------------------------------------------------------------------------------------

                    //SqlDataReader クラス：SQL Server データベースから行の前方向ストリームを読み取る方法を提供する　継承不可
                    //SQL文の実行
                    using (var reader = command.ExecuteReader()) //ここで[SqlCommand] → [SqlDataReader] に
                    {
                        textBox1.Clear();

                        while (reader.Read()) //次の行が存在する場合はtrue
                        {
                            var 得意先cd = (long) reader["cd_tokui"];
                            var 得意先名 = (string) reader["kn_tokui"];
                            textBox1.Text += string.Format("{0} / {1}\r\n", 得意先cd, 得意先名.Trim());
                        }
                    }
                }
                catch (Exception exception)
                {
                    label1.Text = exception.Message;
                    throw;
                }
                finally
                {
                    //DB接続終了
                    sqlConnection.Close();
                }
            }
        }

        private void 複数_Click(object sender, EventArgs e)
        {
            複数データの取得();
        }

        private void 単一_Click(object sender, EventArgs e)
        {
            _other.単一値の取得();
        }

        private void uiIPアドレス手入力_CheckedChanged(object sender, EventArgs e)
        {
            if (uiIPアドレス手入力.Checked==false)
            {
                _p = uiパネル.Enabled == false;
            }
            else
            {
                _p = uiパネル.Enabled == true;
            }
        }
    }
}