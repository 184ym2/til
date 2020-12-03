using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpObjectの複製Sample
{
    public static class Extensions
    {
        public static string Name = "Name";
        public static string Id = "Id";

        public static string Ids = "Ids[]";
        public static string Names = "Names[]";

        public static string Original = "変数original";
        public static string Copy = "変数copy";

        public static void 値をコピー_S(int oriI, string oriS, string orInts, string orStrings, int cpI, string cpS, string cpInts, string cpStrings)
        {
            Console.WriteLine("{0}の値を{1}に代入\r\n" +
                              "original{2}\t= {6}\t   original{3}\t   = {7}\r\n" +
                              "original{4}\t= {8}  original{5} = {9}\r\n" +
                              "copy{2}\t\t= {10}\t   copy{3}\t   = {11}\r\n" +
                              "copy{4}\t= {12}  copy{5}\t   = {13}\r\n"
                              , Original, Copy, Id, Name, Ids, Names, oriI, oriS, orInts, orStrings, cpI, cpS, cpInts, cpStrings);
        }

        public static void 値を変更_S(string changename, int oriI, string oriS, string orInts, string orStrings, int cpI, string cpS, string cpInts, string cpStrings)
        {
            Console.WriteLine("{0}の値を変更\r\n" +
                              "original{1}\t= {5}\t   original{2}\t   = {6}\r\n" +
                              "original{3}\t= {7}  original{4} = {8}\r\n" +
                              "copy{1}\t\t= {9}\t   copy{2}\t   = {10}\r\n" +
                              "copy{3}\t= {11}  copy{4}\t   = {12}\r\n"
                              , changename, Id, Name, Ids, Names, oriI, oriS, orInts, orStrings, cpI, cpS, cpInts, cpStrings);
        }

        public static void 値をコピー(int oriI, string oriS, string orInts, string orStrings, int cpI, string cpS, string cpInts, string cpStrings)
        {
            Console.WriteLine("{0}の値を{1}に代入\r\n" +
                              "original.{2}\t= {6}\t  original.{3}\t   = {7}\r\n" +
                              "original.{4}\t= {8} original.{5} = {9}\r\n" +
                              "copy.{2}\t\t= {10}\t  copy.{3}\t   = {11}\r\n" +
                              "copy.{4}\t= {12} copy.{5}\t   = {13}\r\n"
                              , Original, Copy, Id, Name, Ids, Names, oriI, oriS, orInts, orStrings, cpI, cpS, cpInts, cpStrings);
        }

        public static void 値を変更(string changename, int oriI, string oriS, string orInts, string orStrings, int cpI, string cpS, string cpInts, string cpStrings)
        {
            Console.WriteLine("{0}の値を変更\r\n" +
                              "original.{1}\t= {5}\t  original.{2}\t   = {6}\r\n" +
                              "original.{3}\t= {7} original.{4} = {8}\r\n" +
                              "copy.{1}\t\t= {9}\t  copy.{2}\t   = {10}\r\n" +
                              "copy.{3}\t= {11} copy.{4}\t   = {12}\r\n"
                              , changename, Id, Name, Ids, Names, oriI, oriS, orInts, orStrings, cpI, cpS, cpInts, cpStrings);
        }
    }

    public struct SampleStruct
    {
        //コピーコンストラクタ
        public SampleStruct(SampleStruct ss)
        {
            Id = ss.Id;
            Name = ss.Name;
            Ids = ss.Ids;
            Names = ss.Names;
        }

        public int Id;
        public string Name;
        public int[] Ids;
        public string[] Names;

        public SampleStruct SharrowCopy()
        {
            return (SampleStruct) MemberwiseClone();
        }

        public SampleStruct DeepCopy()
        {
            var clone = SharrowCopy();

            if (clone.Ids != null)
            {
                clone.Ids = (int[]) this.Ids.Clone();
            }

            if (clone.Names != null)
            {
                clone.Names = (string[]) this.Names.Clone();
            }

            return clone;
        }
    }

    public struct SampleStruct2
    {
        //コピーコンストラクタ
        public SampleStruct2(SampleStruct2 ss)
        {
            SampleStruct = ss.SampleStruct;
            SampleClass = ss.SampleClass;
        }

        public SampleStruct SampleStruct;
        public SampleClass SampleClass;

        public SampleStruct2 SharrowCopy()
        {
            return (SampleStruct2) MemberwiseClone();
        }

        public SampleStruct2 DeepCopy()
        {
            var clone = SharrowCopy();

            if (clone.SampleStruct.Ids != null)
            {
                clone.SampleStruct.Ids = (int[]) this.SampleStruct.Ids.Clone();
            }

            if (clone.SampleStruct.Names != null)
            {
                clone.SampleStruct.Names = (string[]) this.SampleStruct.Names.Clone();
            }

            if (clone.SampleClass.Ids != null)
            {
                clone.SampleClass.Ids = (int[]) this.SampleClass.Ids.Clone();
            }

            if (clone.SampleClass.Names != null)
            {
                clone.SampleClass.Names = (string[]) this.SampleClass.Names.Clone();
            }

            return clone;
        }
    }

    public class SampleClass
    {
        public SampleClass()
        {
        }

        //コピーコンストラクタ
        public SampleClass(SampleClass ss)
        {
            Id = ss.Id;
            Name = ss.Name;
            Ids = ss.Ids;
            Names = ss.Names;
        }

        public int Id;
        public string Name;
        public int[] Ids;
        public string[] Names;

        public SampleClass SharrowCopy()
        {
            return (SampleClass) MemberwiseClone();
        }

        public SampleClass DeepCopy()
        {
            var clone = SharrowCopy();

            if (clone.Ids != null)
            {
                clone.Ids = (int[]) this.Ids.Clone();
            }

            if (clone.Names != null)
            {
                clone.Names = (string[]) this.Names.Clone();
            }

            return clone;
        }
    }

    public class SampleClass2
    {
        public SampleClass2()
        {
        }

        //コピーコンストラクタ
        public SampleClass2(SampleClass2 sc)
        {
            SampleStruct = sc.SampleStruct;
            SampleClass = sc.SampleClass;
        }

        public SampleStruct SampleStruct;
        public SampleClass SampleClass;

        public SampleClass2 SharrowCopy()
        {
            return (SampleClass2) MemberwiseClone();
        }

        public SampleClass2 DeepCopy()
        {
            var clone = SharrowCopy();

            if (clone.SampleStruct.Ids != null)
            {
                clone.SampleStruct.Ids = (int[]) this.SampleStruct.Ids.Clone();
            }

            if (clone.SampleStruct.Names != null)
            {
                clone.SampleStruct.Names = (string[]) this.SampleStruct.Names.Clone();
            }

            if (clone.SampleClass.Ids != null)
            {
                clone.SampleClass.Ids = (int[]) this.SampleClass.Ids.Clone();
            }

            if (clone.SampleClass.Names != null)
            {
                clone.SampleClass.Names = (string[]) this.SampleClass.Names.Clone();
            }

            return clone;
        }
    }
}