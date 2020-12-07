using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace 新堂さんと遊ぼう
{
    class スポーツはいいぞ
    {
        public void show()
        {
            Console.WriteLine("新堂「スポーツはいいぞ」");
            Console.ReadKey();
            sort("新堂「スホ゜ーツはいいそ゛」");
            Console.ReadKey();
        }

        private static void sort(string sport)
        {
            //char型配列に変換

            var charArray = sport.ToCharArray();

            var charArray2 = Regex.Split(sport, @"\p{P}");

            //シャッフルしてchar型配列に戻す　条件をつける
            //「」は前後になる
            //半濁点は[ホ]または[は]のみ　濁点は[ス][ホ][ツ][は][そ]のみ

            var randomArray = charArray.OrderBy(i => Guid.NewGuid()).ToArray();
            
            //一文字ずつstring型に変換
            foreach (var c in randomArray)
            {
                c.ToString();
            }

            //表示
            Console.WriteLine(randomArray);
        }
    }
}
