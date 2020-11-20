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
                               IdInts = new[]
                                        {
                                            1,
                                            2,
                                            3
                                        },
                               NameStrings = new[]
                                             {
                                                 "A",
                                                 "B",
                                                 "C"
                                             }
                           };

            #endregion

            var copy = original.DeepCopy();
            Extensions.値をコピー(original.Id, original.Name, string.Join(", ", original.IdInts), string.Join(", ", original.NameStrings), copy.Id, copy.Name, string.Join(", ", copy.IdInts), string.Join(", ", copy.NameStrings));

            original.Id = 20;
            original.Name = "XXX";
            original.IdInts[0] = 0;
            original.NameStrings[0] = "X";
            Extensions.値を変更(Extensions.Original, original.Id, original.Name, string.Join(", ", original.IdInts), string.Join(", ", original.NameStrings), copy.Id, copy.Name, string.Join(", ", copy.IdInts), string.Join(", ", copy.NameStrings));

            copy.Id = 30;
            copy.Name = original.Name + "YYY";
            copy.IdInts[0] = 9;
            copy.NameStrings[0] = "Y";
            Extensions.値を変更(Extensions.Copy, original.Id, original.Name, string.Join(", ", original.IdInts), string.Join(", ", original.NameStrings), copy.Id, copy.Name, string.Join(", ", copy.IdInts), string.Join(", ", copy.NameStrings));
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
                               IdInts = new[]
                                        {
                                            1,
                                            2,
                                            3
                                        },
                               NameStrings = new[]
                                             {
                                                 "A",
                                                 "B",
                                                 "C"
                                             }
                           };

            #endregion

            var copy = original.DeepCopy();
            Extensions.値をコピー(original.Id, original.Name, string.Join(", ", original.IdInts), string.Join(", ", original.NameStrings), copy.Id, copy.Name, string.Join(", ", copy.IdInts), string.Join(", ", copy.NameStrings));

            original.Id = 20;
            original.Name = "XXX";
            original.IdInts[0] = 0;
            original.NameStrings[0] = "X";
            Extensions.値を変更(Extensions.Original, original.Id, original.Name, string.Join(", ", original.IdInts), string.Join(", ", original.NameStrings), copy.Id, copy.Name, string.Join(", ", copy.IdInts), string.Join(", ", copy.NameStrings));

            copy.Id = 30;
            copy.Name = original.Name + "YYY";
            copy.IdInts[0] = 9;
            copy.NameStrings[0] = "Y";
            Extensions.値を変更(Extensions.Copy, original.Id, original.Name, string.Join(", ", original.IdInts), string.Join(", ", original.NameStrings), copy.Id, copy.Name, string.Join(", ", copy.IdInts), string.Join(", ", copy.NameStrings));
            Console.ReadKey();
        }
    }
}