using Dapper;
using System.Data;
using System.Text.RegularExpressions;
using Microsoft.Data.Sqlite;

namespace CSharpDapperAndSQLSample;

// DatabaseとCustom型のマッピング

// https://learn.microsoft.com/ja-jp/dotnet/standard/data/sqlite/dapper-limitations

/*
    Dapper では、SqliteDataReader インデクサーを使用して値が読み取られます。 
    このインデクサーの戻り値の型は object です。つまり、long、double、string、または byte [] の値のみが返されます。 
    詳細については、「データ型」を参照してください。 
    これらの型と他のプリミティブ型との間の変換は、ほとんどが Dapper によって処理されます。 
    ただし、DateTimeOffset、Guid、TimeSpan は処理されません。 これらの型を結果で使用する場合は、型ハンドラーを作成してください。
*/

/// <summary>
/// UmaBanの型ハンドラー
/// </summary>
public class UmaBanTypeHandler : SqlMapper.TypeHandler<UmaBan>
{
    public override void SetValue(IDbDataParameter parameter, UmaBan value)
    {
        parameter.DbType = DbType.String;
        parameter.Value = value.Value;
    }

    public override UmaBan Parse(object value)
    {
        if (value is string stringValue)
        {
            return new UmaBan(stringValue);
        }
        throw new ArgumentException($"UmaBanに変換できない値です: {value}");
    }
}
