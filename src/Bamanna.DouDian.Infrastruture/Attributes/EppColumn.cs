using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bamanna.DouDian.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.All)]
    public class EppColumn : System.Attribute
    {
        public int ColumnIndex { get; set; }


        public EppColumn(int column)
        {
            ColumnIndex = column;
        }
    }
}
