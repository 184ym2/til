using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpObjectの複製Sample
{
    /// <summary>
    /// シャロ―コピー(簡易コピー)：複製元を変更すると複製先の値も変更される
    /// </summary>
    public class ShallowCopy_Substitution
    {
        /// <summary>
        /// 構造体(struct)のシャロ―コピー：代入
        /// 値型/string型は変更の影響を受けない
        /// </summary>
        public void stractCopy_Substitution()
        {
            //Console.WriteLine("\r\n---------構造体(struct)のシャロ―コピー：代入---------\r\n");

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

            Console.WriteLine("---代入：SampleStruct 構造体のメンバーに int型/string型/配列 を含め、そのメンバーを表示する---");
            var copy = original;

            Action 構造体のメンバー = () =>
                                  {
                                      Extensions.値をコピー(original.Id, original.Name,
                                                       string.Join(", ", original.Ids), string.Join(", ", original.Names),
                                                       copy.Id, copy.Name,
                                                       string.Join(", ", copy.Ids), string.Join(", ", copy.Names));

                                      original.Id = 99;
                                      original.Name = "Hello, " + "World!";
                                      original.Ids[0] = 9;
                                      original.Names[0] = "あ";
                                      Extensions.値を変更(Extensions.Original, original.Id, original.Name,
                                                      string.Join(", ", original.Ids), string.Join(", ", original.Names),
                                                      copy.Id, copy.Name,
                                                      string.Join(", ", copy.Ids), string.Join(", ", copy.Names));
                                  };
            構造体のメンバー();
            Console.ReadKey();
        }

        /// <summary>
        /// 構造体(struct)のシャロ―コピー：代入
        /// 値型/string型は変更の影響を受けないが、参照型メンバの値型は影響を受ける
        /// </summary>
        public void stractCopy_Substitution2()
        {

            #region newする

            var original = new SampleStruct2
                           {
                               SampleStruct = new SampleStruct
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
                                                 },
                               SampleClass = new SampleClass
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
                                             }
                           };

            #endregion

            Console.WriteLine("---代入：SampleStruct2 構造体のメンバーに SampleStruct 構造体と SampleClass クラスを含め、そのメンバーを表示する---\r\n");
            var copy = original;

            Action 構造体のメンバーSampleStruct構造体 = () =>
                                                 {
                                                     Console.WriteLine("---メンバー：SampleStruct 構造体---");
                                                     Extensions.値をコピー(original.SampleStruct.Id, original.SampleStruct.Name,
                                                                      string.Join(", ", original.SampleStruct.Ids), string.Join(", ", original.SampleStruct.Names),
                                                                      copy.SampleStruct.Id, copy.SampleStruct.Name,
                                                                      string.Join(", ", copy.SampleStruct.Ids), string.Join(", ", copy.SampleStruct.Names));

                                                     original.SampleStruct.Id = 99;
                                                     original.SampleStruct.Name = "Hello, " + "World!";
                                                     original.SampleStruct.Ids[0] = 9;
                                                     original.SampleStruct.Names[0] = "あ";
                                                     Extensions.値を変更(Extensions.Original, original.SampleStruct.Id, original.SampleStruct.Name,
                                                                     string.Join(", ", original.SampleStruct.Ids), string.Join(", ", original.SampleStruct.Names),
                                                                     copy.SampleStruct.Id, copy.SampleStruct.Name,
                                                                     string.Join(", ", copy.SampleStruct.Ids), string.Join(", ", copy.SampleStruct.Names));
                                                 };

            Action 構造体のメンバーSampleClassクラス = () =>
                                                {
                                                    Console.WriteLine("---メンバー：SampleClass クラス---");
                                                    Extensions.値をコピー(original.SampleClass.Id, original.SampleClass.Name,
                                                                     string.Join(", ", original.SampleClass.Ids), string.Join(", ", original.SampleClass.Names),
                                                                     copy.SampleClass.Id, copy.SampleClass.Name,
                                                                     string.Join(", ", copy.SampleClass.Ids), string.Join(", ", copy.SampleClass.Names));

                                                    original.SampleClass.Id = 99;
                                                    original.SampleClass.Name = "Hello, " + "World!";
                                                    original.SampleClass.Ids[0] = 9;
                                                    original.SampleClass.Names[0] = "あ";
                                                    Extensions.値を変更(Extensions.Original, original.SampleClass.Id, original.SampleClass.Name,
                                                                    string.Join(", ", original.SampleClass.Ids), string.Join(", ", original.SampleClass.Names),
                                                                    copy.SampleClass.Id, copy.SampleClass.Name,
                                                                    string.Join(", ", copy.SampleClass.Ids), string.Join(", ", copy.SampleClass.Names));
                                                };

            構造体のメンバーSampleStruct構造体();
            構造体のメンバーSampleClassクラス();
            Console.ReadKey();
        }

        /// <summary>
        /// クラス(class)のシャロ―コピー：代入
        /// 値型/string型も含め、全ての型が変更の影響を受ける
        /// </summary>
        public void classCopy_Substitution()
        {
            //Console.WriteLine("\r\n------クラス(class)のシャロ―コピー：代入------\r\n");

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

            Console.WriteLine("---代入：SampleClass クラスのメンバーに int型/string型/配列 を含め、そのメンバーを表示する---");
            var copy = original;
            Action クラスのメンバー = () =>
                                  {
                                      Extensions.値をコピー(original.Id, original.Name,
                                                       string.Join(", ", original.Ids), string.Join(", ", original.Names),
                                                       copy.Id, copy.Name,
                                                       string.Join(", ", copy.Ids), string.Join(", ", copy.Names));

                                      original.Id = 99;
                                      original.Name = "Hello, " + "World!";
                                      original.Ids[0] = 9;
                                      original.Names[0] = "あ";
                                      Extensions.値を変更(Extensions.Original, original.Id, original.Name,
                                                      string.Join(", ", original.Ids), string.Join(", ", original.Names),
                                                      copy.Id, copy.Name,
                                                      string.Join(", ", copy.Ids), string.Join(", ", copy.Names));
                                  };
            クラスのメンバー();
            Console.ReadKey();
        }

        /// <summary>
        /// クラス(class)のシャロ―コピー：代入
        /// 値型/string型も含め、全ての型が変更の影響を受ける
        /// </summary>
        public void classCopy_Substitution2()
        {

            #region newする

            var original = new SampleClass2
                           {
                               SampleStruct = new SampleStruct
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
                                              },
                               SampleClass = new SampleClass
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
                                             }
                           };

            #endregion

            Console.WriteLine("---代入：SampleClass2 クラスのメンバーに SampleStruct 構造体と SampleClass クラスを含め、そのメンバーを表示する---\r\n");
            var copy = original;

            Action クラスのメンバーSampleStruct構造体 = () =>
                                                 {
                                                     Console.WriteLine("---メンバー：SampleStruct 構造体---");
                                                     Extensions.値をコピー(original.SampleStruct.Id, original.SampleStruct.Name,
                                                                      string.Join(", ", original.SampleStruct.Ids), string.Join(", ", original.SampleStruct.Names),
                                                                      copy.SampleStruct.Id, copy.SampleStruct.Name,
                                                                      string.Join(", ", copy.SampleStruct.Ids), string.Join(", ", copy.SampleStruct.Names));

                                                     original.SampleStruct.Id = 99;
                                                     original.SampleStruct.Name = "Hello, " + "World!";
                                                     original.SampleStruct.Ids[0] = 9;
                                                     original.SampleStruct.Names[0] = "あ";
                                                     Extensions.値を変更(Extensions.Original, original.SampleStruct.Id, original.SampleStruct.Name,
                                                                     string.Join(", ", original.SampleStruct.Ids), string.Join(", ", original.SampleStruct.Names),
                                                                     copy.SampleStruct.Id, copy.SampleStruct.Name,
                                                                     string.Join(", ", copy.SampleStruct.Ids), string.Join(", ", copy.SampleStruct.Names));
                                                 };

            Action クラスのメンバーSampleClassクラス = () =>
                                                {
                                                    Console.WriteLine("---メンバー：SampleClass クラス---");
                                                    Extensions.値をコピー(original.SampleClass.Id, original.SampleClass.Name,
                                                                     string.Join(", ", original.SampleClass.Ids), string.Join(", ", original.SampleClass.Names),
                                                                     copy.SampleClass.Id, copy.SampleClass.Name,
                                                                     string.Join(", ", copy.SampleClass.Ids), string.Join(", ", copy.SampleClass.Names));

                                                    original.SampleClass.Id = 99;
                                                    original.SampleClass.Name = "Hello, " + "World!";
                                                    original.SampleClass.Ids[0] = 9;
                                                    original.SampleClass.Names[0] = "あ";
                                                    Extensions.値を変更(Extensions.Original, original.SampleClass.Id, original.SampleClass.Name,
                                                                    string.Join(", ", original.SampleClass.Ids), string.Join(", ", original.SampleClass.Names),
                                                                    copy.SampleClass.Id, copy.SampleClass.Name,
                                                                    string.Join(", ", copy.SampleClass.Ids), string.Join(", ", copy.SampleClass.Names));
                                                };

            クラスのメンバーSampleStruct構造体();
            クラスのメンバーSampleClassクラス();
            Console.ReadKey();
        }
    }
}