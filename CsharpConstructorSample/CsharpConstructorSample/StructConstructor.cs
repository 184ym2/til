using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpConstructorSample
{
  
    struct StructConstructor
    {
        /// <summary>
        /// structは引数なしコンストラクタが必ず実装されている
        /// そのためどんな状況においても再定義は不可
        /// 理由：structは値型のため「初期化していない」という状態が存在しない
        /// 　　　= 引数なしコンストラクタは既定値で初期化する
        /// </summary>
        /// <param name="i"></param>

        public StructConstructor(int i):this()
        {

        }

        public int Id;
        public string Name;
    }
}
