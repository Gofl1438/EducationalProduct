using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProduct.Classes
{
    public static class StateCatchBones
    {
        public static int СurrentQuntityBones;
        public static bool СurrentStateMenuClick;
        public static bool SingleView;
        public static void Init()
        {
            СurrentQuntityBones = 0;
            СurrentStateMenuClick = false;
            SingleView = false;
        }
    }
}
