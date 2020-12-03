using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpObjectの複製Sample
{
    /// <summary>
    /// 構造体(struct)のシャロ―コピー：MemberwiseCloneメソッドを使い簡易コピーをしたあと、更に配列を簡易コピーする(値型とstirng型なので別インスタンスを持つ)
    /// すべての変数はお互いの変更の影響を受けない
    /// </summary>
    public class DeepCopy
    {
        public void stractCopy()
        {
            Console.WriteLine("\r\n---構造体(struct)のディープコピー：MemberwiseCloneメソッド--\r\n");

            #region newする

            var original = new SampleStruct
                           {
                               Id = 10,
                               Name = "AAA",
                               Ids = new[]
                                     {
                                         1,
                                         2,
                                         3
                                     },
                               Names = new[]
                                       {
                                           "A",
                                           "B",
                                           "C"
                                       }
                           };

            #endregion

            var copy = original.DeepCopy();
            Extensions.値をコピー(original.Id, original.Name,
                             string.Join(", ", original.Ids), string.Join(", ", original.Names),
                             copy.Id, copy.Name,
                             string.Join(", ", copy.Ids), string.Join(", ", copy.Names));

            original.Id = 20;
            original.Name = "XXX";
            original.Ids[0] = 0;
            original.Names[0] = "X";
            Extensions.値を変更(Extensions.Original, original.Id, original.Name,
                            string.Join(", ", original.Ids), string.Join(", ", original.Names),
                            copy.Id, copy.Name,
                            string.Join(", ", copy.Ids), string.Join(", ", copy.Names));

            Console.ReadKey();
        }

        /// <summary>
        /// クラス(class)のシャロ―コピー：MemberwiseCloneメソッドを使い簡易コピーをしたあと、更に配列を簡易コピーする(値型とstirng型なので別インスタンスを持つ)
        /// すべての変数はお互いの変更の影響を受けない
        /// </summary>
        public void classCopy()
        {
            Console.WriteLine("\r\n---クラス(class)のディープコピー：MemberwiseCloneメソッド--\r\n");

            #region newする

            var original = new SampleClass
                           {
                               Id = 10,
                               Name = "AAA",
                               Ids = new[]
                                     {
                                         1,
                                         2,
                                         3
                                     },
                               Names = new[]
                                       {
                                           "A",
                                           "B",
                                           "C"
                                       }
                           };

            #endregion

            var copy = original.DeepCopy();
            Extensions.値をコピー(original.Id, original.Name, string.Join(", ", original.Ids), string.Join(", ", original.Names),
                             copy.Id, copy.Name,
                             string.Join(", ", copy.Ids), string.Join(", ", copy.Names));

            original.Id = 20;
            original.Name = "XXX";
            original.Ids[0] = 0;
            original.Names[0] = "X";
            Extensions.値を変更(Extensions.Original, original.Id, original.Name,
                            string.Join(", ", original.Ids), string.Join(", ", original.Names),
                            copy.Id, copy.Name,
                            string.Join(", ", copy.Ids), string.Join(", ", copy.Names));

            Console.ReadKey();
        }
    }
}