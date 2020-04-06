using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace CsharpDatabase接続Sample
{
    internal class Other
    {
        //別クラスからメインフォームのコントロールを操作 フォームを操作するためには、そのフォームのインスタンス（アドレス）があれば操作可能

        //コンストラクタでは、☆引数として渡されたForm1型の変数(Form1Obj)を自分（別クラス）の★メンバ変数(form1Obj)に格納している

        //★
        public Form1 Form1Obj;//Form1を示すメンバ変数(フィールド)
        //public int I;　←と↑は同じ動作

        //☆
        //Q. other.csがnewされたときに、このコンストラクタがMainFormで呼び出され、引数はthis(Form1の先頭アドレス)を持つ → form1ObjはForm1の先頭アドレスを持っている
        //A. 参照型は代入だけでなく、メソッドに引数としてデータを渡した際にもコピー処理が行われるから
        
        public Other(Form1 form1Obj /*, int i)*/ )
        {
            //form1ObjはForm1の先頭アドレスを持っており、それを自分のメンバ変数(Form1Obj)に格納する
            Form1Obj = form1Obj;
            //I = i;　←と↑は同じ動作
        }

        public void 単一値の取得()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DB情報"].ConnectionString;

            //SqlConnection クラス：SQL Server データベースへの接続を表す　継承不可
            using (var sqlconnection = new SqlConnection(connectionString))

                //★commandオブジェクトの作成
                using (var commnd = sqlconnection.CreateCommand())
                {
                    sqlconnection.Open();
                    try
                    {
                        //SqlCommand クラス：SQL Server データベースに対して実行する Transact-SQL ステートメントまたはストアド プロシージャを表します　継承不可
                        commnd.CommandText = @" select count(*) from m_tokui ";//逐語的文字列リテラル：エスケープシーケンス(/n)などを処理しない

                        var rcount = (int) commnd.ExecuteScalar();
                        Form1Obj.textBox1.Clear();
                        Form1Obj.textBox1.Text += string.Format("{0:d} レコード", rcount);
                    }
                    catch (Exception　exception)
                    {
                        Form1Obj.label1.Text = exception.Message;
                        throw;
                    }
                    finally
                    {
                        sqlconnection.Close();
                    }
                }
        }
    }
}