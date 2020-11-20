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
            Console.WriteLine("{0}の値を{1}にコピー\r\n" +
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
            Console.WriteLine("{0}の値を{1}にコピー\r\n" +
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
            IdInts = ss.IdInts;
            NameStrings = ss.NameStrings;
        }

        public int Id;
        public string Name;
        public int[] IdInts;
        public string[] NameStrings;

        public SampleStruct SharrowCopy()
        {
            return (SampleStruct) MemberwiseClone();
        }

        public SampleStruct DeepCopy()
        {
            var clone = SharrowCopy();

            if (clone.IdInts != null)
            {
                clone.IdInts = (int[]) this.IdInts.Clone();
            }

            if (clone.NameStrings != null)
            {
                clone.NameStrings = (string[]) this.NameStrings.Clone();
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
            IdInts = ss.IdInts;
            NameStrings = ss.NameStrings;
        }

        public int Id;
        public string Name;
        public int[] IdInts;
        public string[] NameStrings;

        public SampleClass SharrowCopy()
        {
            return (SampleClass) MemberwiseClone();
        }

        public SampleClass DeepCopy()
        {
            var clone = SharrowCopy();

            if (clone.IdInts != null)
            {
                clone.IdInts = (int[]) this.IdInts.Clone();
            }

            if (clone.NameStrings != null)
            {
                clone.NameStrings = (string[]) this.NameStrings.Clone();
            }

            return clone;
        }
    }
}