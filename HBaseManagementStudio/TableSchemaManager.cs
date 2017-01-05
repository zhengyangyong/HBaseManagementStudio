using HBaseThrift.Thrift;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace HBaseManagementStudio
{
    public class TableSchemaManager
    {
        public static Dictionary<string, Type> ColumnDataTypes = new Dictionary<string, Type>()
        {
            {"byte",typeof(byte)},
            {"int",typeof(int)},
            {"long",typeof(long)},
            {"float",typeof(float)},
            {"double",typeof(double)},
            {"string",typeof(string)},
            {"blob",typeof(byte[])},

            {"OPCUA_Boolean",null},
            {"OPCUA_SByte",null},
            {"OPCUA_Byte",null},
            {"OPCUA_Int16",null},
            {"OPCUA_UInt16",null},
            {"OPCUA_Int32",null},
            {"OPCUA_UInt32",null},
            {"OPCUA_Float",null},
            {"OPCUA_Double",null},
            {"OPCUA_String",null},
            {"OPCUA_DateTime",null},
            {"OPCUA_Guid",null}
        };

        private string _folder = "TableSchemas";
        private static TableSchemaManager _instance = null;

        public Dictionary<string, TableSchema> Schemas { get; private set; }

        private TableSchemaManager()
        {
            if(!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }
            Schemas = new Dictionary<string, TableSchema>();
            this.Load();
        }


        public static TableSchemaManager GetInstance()
        {
            if (TableSchemaManager._instance == null) TableSchemaManager._instance = new TableSchemaManager();
            return TableSchemaManager._instance;
        }

        public void Load()
        {
            lock(this)
            {
                Schemas.Clear();
                foreach(var file in Directory.GetFiles(_folder))
                {
                    FileInfo fi = new FileInfo(file);
                    try
                    {
                        Schemas.Add(fi.Name, JsonConvert.DeserializeObject<TableSchema>(File.ReadAllText(file, Encoding.UTF8)));
                    }
                    catch { }
                }
            }
        }

        public void Save()
        {
            lock(this)
            {
                foreach(var schema in Schemas)
                {
                    File.WriteAllText(_folder + "\\" + schema.Key, JsonConvert.SerializeObject(schema.Value), Encoding.UTF8);
                }
            }
        }

        public TableSchema Get(string key)
        {
            lock (this)
            {
                if (Schemas.ContainsKey(key))
                {
                    return Schemas[key];
                }
                else return null;
            }
        }

        public string ProcessTRowResultToString(string tableName,List<TRowResult> data)
        {
            StringBuilder sb = new StringBuilder();
            if (data != null && data.Count != 0)
            {
                var schema = this.Get(tableName);
                if (schema != null)
                {
                    foreach (var row in data)
                    {
                        sb.AppendLine(string.Format("Row = {0} Column Count = {1}:",row.Row.GetObject(schema.RowKeyType,schema.RowKeyFormat).ToString(), row.Columns.Count));
                        foreach (var column in row.Columns)
                        {
                            string columnname = column.Key.GetUTF8String();
                            object value = null;
                            if (schema.ColumnTypeAndFormats.ContainsKey(columnname))
                            {
                                value = column.Value.Value.GetObject(schema.ColumnTypeAndFormats[columnname].Item1,schema.ColumnTypeAndFormats[columnname].Item2);
                            }
                            else
                            {
                                value = "$->" + column.Value.Value.Length;
                                
                            }
                            sb.AppendFormat("{0}={1},", columnname, value);
                        }
                        sb.AppendLine();
                        sb.AppendLine("------------------------------------------------");
                    }
                }
            }
            return sb.ToString();
        }
    }
}
