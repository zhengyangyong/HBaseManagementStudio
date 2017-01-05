using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBaseThrift.Thrift
{
    public partial class ColumnDescriptor
    {
        public string StringName
        {
            get { return Encoding.UTF8.GetString(this.Name); }
            set
            {
                this.Name = value.GetUTF8Bytes();
            }
        }
    }
}
