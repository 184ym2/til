namespace CsharpKeywordSample_1
{
    class 組込み型変換Sample
    {
        //暗黙的な型変換について　ある型の変数を別の型の変数に代入するだけで自動的に型を変換してくれる機能
        //★型を変換しても値の大きさが失われない場合にのみ暗黙的な型変換が行える★

        private static short _sh = 365;
        private static long _lo = _sh; // short から long への暗黙的な型変換
        private double db = _lo; // long から double への暗黙的な型変換

        
        //明示的な型変換　暗黙的に変換を行えない型同士は明示的(explicit)に変換を行う必要がある
        //「 (変換後の型名)変数名 」という形の式のことを「キャスト（cast）式」と呼ぶ

        private static int _it = 365;
        private short sho = (short)_it; // int から short への明示的な型変換

        private static int _int2 = 365;
        private byte bt = (byte)_int2;   // int から byte への明示的な型変換
        // byte は 0～255 までの範囲しか表現できないので、n の値は 365 mod 256 = 109 になる

        private static double _db2 = 3.14159;
        private long lo2 = (long)_db2;   // double から long への明示的な型変換
        // 値は小数点以下が切り捨てられて 3 になる
    }
}