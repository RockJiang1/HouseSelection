using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseSelection.Logger
{
    public class EventHelper
    {
        /// <summary>
        /// 获取委托的拥有控件
        /// </summary>
        /// <param name="dlg">委托</param>
        /// <returns>包含的控件</returns>
        public static Control GetDelegateOwner(Delegate dlg)
        {
            if (dlg == null || dlg.Target == null)
            {
                return null;
            }
            if (dlg.Target as Control != null)
            {
                return dlg.Target as Control;
            }
            return GetDelegateOwner(dlg.Target as Delegate);
        }
    }
}
