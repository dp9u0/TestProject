using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegateLambda {
    class CoolMother {
        public static Func<CoolMother> Activator {
            get; protected set;
        }

        //We are only doing this to avoid NULL references!
        static CoolMother() {
            Activator = () => new CoolMother();
        }

        public CoolMother() {
            //Message of every mother
            Message = "I am the mother";
        }

        public string Message {
            get; protected set;
        }
    }

    class HotDaughter : CoolMother {
        public HotDaughter() {
            //Once this constructor has been "touched" we set the Activator ...
            Activator = () => new HotDaughter();
            //Message of every daughter
            Message = "I am the daughter";
        }
    }

    public class Test2 {
        public static void Test() {
            var mother = CoolMother.Activator().Message;
            //mother = "I am the mother"
            var create = new HotDaughter();
            var daughter = HotDaughter.Activator().Message;
            //daughter = "I am the daughter"
            var mother2 = CoolMother.Activator().Message;
            Console.WriteLine(mother);
            Console.WriteLine(daughter);
            Console.WriteLine(mother2);
        }
    }
}
