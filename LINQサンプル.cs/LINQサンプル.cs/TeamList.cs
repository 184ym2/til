using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQサンプル.cs
{
    static class TeamList
    {
        public static Dictionary<int, string> Aclass_personnel = new Dictionary<int, string>
                                                        {
                                                            {1, "太刀川隊"}
                                                            , {2, "冬島隊"}
                                                            , {3, "風間隊"}
                                                            , {4, "草壁隊"}
                                                            , {5, "嵐山隊"}
                                                            , {6, "加古隊"}
                                                            , {7, "三輪隊"}
                                                            , {8, "片桐隊"}
                                                            , {9, "玉狛第一"}
                                                        };

        public static Dictionary<int, string> Bclass_personnel = new Dictionary<int, string>
                                                        {
                                                            {1, "二宮隊"}
                                                            , {2, "玉狛第一"}
                                                            , {3, "影浦隊"}
                                                            , {4, "生駒隊"}
                                                            , {5, "王子隊"}
                                                            , {6, "東隊"}
                                                            , {7, "那須隊"}
                                                            , {8, "弓場隊"}
                                                            , {9, "鈴鳴第一"}
                                                            , {10, "荒船隊"}
                                                            , {11, "香取隊"}
                                                            , {12, "諏訪隊"}
                                                            , {13, "柿崎隊"}
                                                            , {14, "漆間隊"}
                                                            , {15, "松代隊"}
                                                            , {16, "海老名隊"}
                                                            , {17, "吉里隊"}
                                                            , {18, "早川隊"}
                                                            , {19, "茶野隊"}
                                                            , {20, "常盤隊"}
                                                            , {21, "間宮隊"}
                                                        };

        public static Dictionary<int, string> SourceC = new Dictionary<int, string>();

        public static List<int> SrcNumbers_A
        {
            get { return Aclass_personnel.Keys.ToList(); }
        }

        public static List<string> SrcNames_A
        {
            get { return Aclass_personnel.Values.ToList(); }
        }

        public static List<int> MargedNumbers_AB
        {
            get { return Aclass_personnel.Keys.Concat(Bclass_personnel.Keys).ToList(); }
        }

        public static List<string> MargedNames_AB
        {
            get { return Aclass_personnel.Values.Concat(Bclass_personnel.Values).ToList(); }
        }

        public static List<KeyValuePair<int, string>> MargedSource_AB
        {
            get { return Aclass_personnel.Concat(Bclass_personnel).ToList(); }
        }
    }
}
