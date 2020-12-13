using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CsharpObjectの複製Sample
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Action shallowSimple = () =>
                                       {
                                           var shallowsimple = new ShallowCopy_Simple();
                                           shallowsimple.simpleCopy();
                                       };

            Action shallowCopySubstitution = () =>
                                                 {
                                                     var shallowcopy = new ShallowCopy_Substitution();
                                                     shallowcopy.stractCopy_Substitution();
                                                     shallowcopy.classCopy_Substitution();
                                                     shallowcopy.stractCopy_Substitution2();
                                                     shallowcopy.classCopy_Substitution2();
                                                 };

            Action shallowCopyConstructor = () =>
                                                {
                                                    var shallowcopy = new ShallowCopy_Constructor();
                                                    shallowcopy.stractCopy_Constructor();
                                                    shallowcopy.classCopy_Constructor();
                                                    shallowcopy.stractCopy_Constructor2();
                                                    shallowcopy.classCopy_Constructor2();
                                                };

            Action shallowCopyMemberwiseClone = () =>
                                                    {
                                                        var shallowcopy = new ShallowCopy_MemberwiseClone();
                                                        shallowcopy.stractCopy_MemberwiseClone();
                                                        shallowcopy.classCopy_MemberwiseClone();
                                                        shallowcopy.stractCopy_MemberwiseClone2();
                                                        shallowcopy.classCopy_MemberwiseClone2();
                                                    };

            Action deepCopy = () =>
                                  {
                                      var deepcopy = new DeepCopy();
                                      deepcopy.stractCopy();
                                      deepcopy.classCopy();
                                  };

            Action 値渡しと参照渡し = () =>
                                  {
                                      var refout = new 値渡しと参照渡し();
                                      refout.値型();
                                      refout.参照型();
                                  };

            //shallowCopySubstitution();
            //shallowCopyConstructor();
            //shallowCopyMemberwiseClone();

            //値渡しと参照渡し();

            deepCopy();
        }
    }
}