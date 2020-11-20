using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpObjectの複製Sample
{
    /// <summary>
    /// シャロ―コピー(簡易コピー)：複製元を変更すると複製先の値も変更される
    /// </summary>
    public class ShallowCopy
    {
        /// <summary>
        /// 構造体(struct)のシャロ―コピー：代入
        /// 値型/string型は変更の影響を受けない
        /// </summary>
        public void stractCopy()
        {
            Console.WriteLine("\r\n---構造体(struct)のシャロ―コピー：代入---\r\n");

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

            var copy = original;
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
        /// クラス(class)のシャロ―コピー：代入
        /// 値型/string型も含め、全ての型が変更の影響を受ける
        /// </summary>
        public void classCopy()
        {
            Console.WriteLine("\r\n---クラス(class)のシャロ―コピー：代入---\r\n");

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

            var copy = original;
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
        /// 構造体(struct)のシャロ―コピー：コピーコンストラクタ
        /// 値型/string型は変更の影響を受けない
        /// </summary>
        public void stractCopy2()
        {
            Console.WriteLine("\r\n---構造体(struct)のシャロ―コピー：コピーコンストラクタ---\r\n");

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

            var copy = new SampleStruct(original);
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
        /// クラス(class)のシャロ―コピー：コピーコンストラクタ
        /// 値型/string型は変更の影響を受けない
        /// </summary>
        public void classCopy2()
        {
            Console.WriteLine("\r\n---クラス(class)のシャロ―コピー：コピーコンストラクタ---\r\n");

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

            var copy = new SampleClass(original);
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
        /// 構造体(struct)のシャロ―コピー：MemberwiseCloneメソッド
        /// 値型/string型は変更の影響を受けない
        /// </summary>
        public void stractCopy3()
        {
            Console.WriteLine("\r\n---構造体(struct)のシャロ―コピー：MemberwiseCloneメソッド--\r\n");

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

            var copy = original.SharrowCopy();
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
        /// クラス(class)のシャロ―コピー：MemberwiseCloneメソッド
        /// 値型/string型は変更の影響を受けない
        /// </summary>
        public void classCopy3()
        {
            Console.WriteLine("\r\n---クラス(class)のシャロ―コピー：MemberwiseCloneメソッド--\r\n");

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

            var copy = original.SharrowCopy();
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