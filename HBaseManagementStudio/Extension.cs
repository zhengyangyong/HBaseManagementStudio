using Opc.Ua;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HBaseManagementStudio
{
    public static class Extension
    {
        public static void SetImageIndex(this TreeNode node,int index)
        {
            node.ImageIndex = index;
            node.SelectedImageIndex = index;
        }

        public static string GetCellStringValue(this DataGridViewRow row,int index)
        {
            if(row.Cells[index].Value != null)
            {
                return row.Cells[index].Value.ToString().Trim();
            }
            return null;
        }

        public static int? GetCellIntValue(this DataGridViewRow row, int index)
        {
            if (row.Cells[index].Value != null)
            {
                int value = 0;
                if(int.TryParse(row.Cells[index].Value.ToString(),out value))
                {
                    return value;
                }
            }
            return null;
        }

        public static string GetUTF8String(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static long GetHBaseTimestamp(this DateTime time)
        {
            return (long)(time - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static byte[] GetBytes(object obj, string type, string format)
        {
            if (obj == null) return null;
            else
            {
                if (type == "byte")
                {
                    return new byte[] { (byte)obj};
                }
                else if (type == "int")
                {
                    byte[] data = BitConverter.GetBytes((int)obj);
                    if (format == "Big-Endian")
                    {
                        Array.Reverse(data);
                    }
                    return data;
                }
                else if (type == "long")
                {
                    byte[] data = BitConverter.GetBytes((long)obj);
                    if (format == "Big-Endian")
                    {
                        Array.Reverse(data);
                    }
                    return data;
                }
                else if (type == "float")
                {
                    byte[] data = BitConverter.GetBytes((float)obj);
                    if (format == "Big-Endian")
                    {
                        Array.Reverse(data);
                    }
                    return data;
                }
                else if (type == "double")
                {
                    byte[] data = BitConverter.GetBytes((double)obj);
                    if (format == "Big-Endian")
                    {
                        Array.Reverse(data);
                    }
                    return data;
                }
                else if (type == "string")
                {
                    return Encoding.GetEncoding(format).GetBytes((string)obj);
                }
                else if (type == "blob")
                {
                    return (byte[])obj;
                }

                else if (type == "OPCUA_Boolean")
                {
                    return ToByte(new Variant((bool)obj));
                }
                else if (type == "OPCUA_SByte")
                {
                    return ToByte(new Variant((sbyte)obj));
                }
                else if (type == "OPCUA_Byte")
                {
                    return ToByte(new Variant((byte)obj));
                }
                else if (type == "OPCUA_Int16")
                {
                    return ToByte(new Variant((short)obj));
                }
                else if (type == "OPCUA_UInt16")
                {
                    return ToByte(new Variant((ushort)obj));
                }
                else if (type == "OPCUA_Int32")
                {
                    return ToByte(new Variant((int)obj));
                }
                else if (type == "OPCUA_UInt32")
                {
                    return ToByte(new Variant((uint)obj));
                }
                else if (type == "OPCUA_Float")
                {
                    return ToByte(new Variant((float)obj));
                }
                else if (type == "OPCUA_Double")
                {
                    return ToByte(new Variant((double)obj));
                }
                else if (type == "OPCUA_String")
                {
                    return ToByte(new Variant((string)obj));
                }
                else if (type == "OPCUA_DateTime")
                {
                    return ToByte(new Variant((DateTime)obj));
                }
                else if (type == "OPCUA_Guid")
                {
                    return ToByte(new Variant((Guid)obj));
                }
                else throw new Exception("Unknow Data Type:" + type);
            }
        }

        public static object GetObject(this byte[] data,string type,string format)
        {
            if (data != null && data.Length != 0)
            {
                if (type == "byte")
                {
                    return data[0];
                }
                else if (type == "int")
                {
                    if (format == "Big-Endian")
                    {
                        Array.Reverse(data);
                    }
                    return BitConverter.ToInt32(data, 0);
                }
                else if (type == "long")
                {
                    if (format == "Big-Endian")
                    {
                        Array.Reverse(data);
                    }
                    return BitConverter.ToInt64(data, 0);
                }
                else if (type == "float")
                {
                    if (format == "Big-Endian")
                    {
                        Array.Reverse(data);
                    }
                    return BitConverter.ToSingle(data, 0);
                }
                else if (type == "double")
                {
                    if (format == "Big-Endian")
                    {
                        Array.Reverse(data);
                    }
                    return BitConverter.ToDouble(data, 0);
                }
                else if (type == "string")
                {
                    return Encoding.GetEncoding(format).GetString(data);
                }
                else if (type == "blob")
                {
                    return data;
                }

                else if (type == "OPCUA_Boolean")
                {
                    return (bool)FromByte(data).Value;
                }
                else if (type == "OPCUA_SByte")
                {
                    return (sbyte)FromByte(data).Value;
                }
                else if (type == "OPCUA_Byte")
                {
                    return (byte)FromByte(data).Value;
                }
                else if (type == "OPCUA_Int16")
                {
                    return (short)FromByte(data).Value;
                }
                else if (type == "OPCUA_UInt16")
                {
                    return (ushort)FromByte(data).Value;
                }
                else if (type == "OPCUA_Int32")
                {
                    return (int)FromByte(data).Value;
                }
                else if (type == "OPCUA_UInt32")
                {
                    return (uint)FromByte(data).Value;
                }
                else if (type == "OPCUA_Float")
                {
                    return (float)FromByte(data).Value;
                }
                else if (type == "OPCUA_Double")
                {
                    return (double)FromByte(data).Value;
                }
                else if (type == "OPCUA_String")
                {
                    return (string)FromByte(data).Value;
                }
                else if (type == "OPCUA_DateTime")
                {
                    return (DateTime)FromByte(data).Value;
                }
                else if (type == "OPCUA_Guid")
                {
                    return (Guid)FromByte(data).Value;
                }
                else throw new Exception("Unknow Data Type:" + type);
            }
            return null;
        }

        public static Variant FromByte(byte[] data)
        {
            return new BinaryDecoder(data, new ServiceMessageContext() { MaxArrayLength = int.MaxValue, MaxByteStringLength = int.MaxValue, MaxMessageSize = int.MaxValue, MaxStringLength = int.MaxValue }).ReadVariant(null);
        }

        public static byte[] ToByte(this Variant variant)
        {
            BinaryEncoder be = new BinaryEncoder(new ServiceMessageContext() { MaxArrayLength = int.MaxValue, MaxByteStringLength = int.MaxValue, MaxMessageSize = int.MaxValue, MaxStringLength = int.MaxValue });
            be.WriteVariant(null, variant);
            return be.CloseAndReturnBuffer();
        }
    }
}
