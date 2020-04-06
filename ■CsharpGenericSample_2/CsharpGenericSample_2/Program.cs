using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpGenericSample_2
{

    internal class Program
    {
        // partsというList<T>クラス(T = Part)をインスタンス化する
        static void 型引数を使用して他のジェネリッククラスをインスタンス化<T>(IList<T> list)
        {
            //foreach…コレクションのすべての要素を1回ずつ読み出すための構文
            foreach (var x in list)
                Console.Write("{0}\n", x);//xに配列の値を一つずつ入れている
            Console.ReadLine();
        }


        private static void Main(string[] args)
        {
            // 部品のリストを作成
            var parts = new List<Part>
                        {
                            new Part
                            {
                                PartName = "crank arm",
                                PartId = 1234
                            },
                            new Part
                            {
                                PartName = "chain ring",
                                PartId = 1334
                            },
                            new Part
                            {
                                PartName = "regular seat",
                                PartId = 1434
                            },
                            new Part
                            {
                                PartName = "banana seat",
                                PartId = 1444
                            },
                            new Part
                            {
                                PartName = "cassette",
                                PartId = 1534
                            },
                            new Part
                            {
                                PartName = "shift lever",
                                PartId = 1634
                            }
                        };

            // 部品をリストに追加します

            // リスト内の部分を書き出します。これにより、オーバーライドされたToStringメソッドが呼び出されます。
            // Partクラスで。

            Console.WriteLine();
            Console.ReadLine();

            foreach (var aPart in parts)
            {
                Console.WriteLine(aPart);
                Console.ReadLine();
            }


            // パーツ番号1734のリストを確認してください。これはIEquitable.Equalsメソッドを呼び出します
            // Partクラスは、PartIdが等しいかどうかをチェックします。
            Console.WriteLine("\nContains(\"1734\"): {0}",
            parts.Contains(new Part { PartId = 1734, PartName = "" }));

            // 2の位置に新しい項目を挿入します。
            Console.WriteLine("\nInsert(2, \"1834\")");
            parts.Insert(2, new Part() { PartName = "brake lever", PartId = 1834 });


            //Console.WriteLine();
            foreach (var aPart in parts)
            {
                Console.WriteLine(aPart);
                Console.ReadLine();
            }

            Console.WriteLine("\nParts[3]: {0}", parts[3]);

            Console.WriteLine("\nRemove(\"1534\")");

            // PartNameが異なっていても、これは部分1534を削除します。
            // EqualsメソッドはPartIdの等価性のみをチェックするためです。
            parts.Remove(new Part
                         { PartId = 1534, PartName = "cogs" });

            Console.WriteLine();
            foreach (var aPart in parts)
            {
                Console.WriteLine(aPart);
                Console.ReadLine();
            }
            Console.WriteLine("\nRemoveAt(3)");
            // これにより、インデックス3の部分が削除されます。
            parts.RemoveAt(3);

            Console.WriteLine();
            foreach (var aPart in parts)
            {
                Console.WriteLine(aPart);
                Console.ReadLine();
            }

            型引数を使用して他のジェネリッククラスをインスタンス化(parts);
        }
    }

    public class Part : IEquatable<Part>
    {
        public string PartName { get; set; }

        public int PartId { get; set; }

        public override string ToString()
        {
            return "ID: " + PartId + "   Name: " + PartName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            var objAsPart = obj as Part;
            return objAsPart != null && Equals(objAsPart);
        }

        public override int GetHashCode()
        {
            return PartId;
        }

        public bool Equals(Part other)
        {
            return other != null && (PartId.Equals(other.PartId));
        }

        // ==と！=演算子もオーバーライドする必要があります。


    }
}
