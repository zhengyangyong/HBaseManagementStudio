using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HBaseManagementStudio
{
    public class TableSchema
    {
        public string RowKeyType { get; set; }
        public string RowKeyFormat { get; set; }

        public Dictionary<string, Tuple<string,string>> ColumnTypeAndFormats { get; set; }

        public Dictionary<string,Dictionary<string,Tuple<string,string>>> ColumnQualifierTypeAndFormats
        {
            get
            {
                if (ColumnTypeAndFormats == null) return null;
                else
                {
                    Dictionary<string, Dictionary<string, Tuple<string, string>>> results = new Dictionary<string, Dictionary<string, Tuple<string, string>>>();
                    foreach(var columntype in ColumnTypeAndFormats)
                    {
                        string f = columntype.Key.Substring(0, columntype.Key.IndexOf(':') + 1);
                        string q = columntype.Key.Substring(columntype.Key.IndexOf(':') + 1);
                        if (!results.ContainsKey(f))
                        {
                            results.Add(f, new Dictionary<string, Tuple<string, string>>());
                        }
                        results[f].Add(q, columntype.Value);
                    }
                    return results;
                }
            }
        }
    }
}
