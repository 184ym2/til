using System;

namespace CsharpObjectの複製Sample
{
    public class ShallowCopy_Simple
    {
        /// <summary>
        /// int型とstring型のシャローコピー：代入
        /// </summary>
        public void simpleCopy()
        {
            Console.WriteLine("---シャローコピー：代入---\r\n");
            var originalId = 10;
            var originalName = "AAA";
            var originalIds = new[]
                              {
                                  1,
                                  2,
                                  3
                              };
            var originalNames = new[]
                                {
                                    "A",
                                    "B",
                                    "C"
                                };

            var copyId = originalId;
            var copyName = originalName;
            var copyIds = originalIds;
            var copyNames = originalNames;
            Extensions.値をコピー_S(originalId, originalName, string.Join(", ", originalIds), string.Join(", ", originalNames), copyId, copyName, string.Join(", ", copyIds), string.Join(", ", copyNames));

            originalId = 20;
            originalName = "XXX";
            originalIds[0] = 0;
            originalNames[0] = "X";
            Extensions.値を変更_S(Extensions.Original, originalId, originalName, string.Join(", ", originalIds), string.Join(", ", originalNames), copyId, copyName, string.Join(", ", copyIds), string.Join(", ", copyNames));

            copyId = 30;
            copyName = originalName + "YYY";
            copyIds[0] = 9;
            copyNames[0] = "Y";
            Extensions.値を変更_S(Extensions.Copy, originalId, originalName, string.Join(", ", originalIds), string.Join(", ", originalNames), copyId, copyName, string.Join(", ", copyIds), string.Join(", ", copyNames));
            Console.ReadKey();
        }
    }
}