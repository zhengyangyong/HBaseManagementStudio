using HBaseThrift.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Thrift.Protocol;
using Thrift.Transport;

namespace HBaseThrift
{
    public class HBaseThriftClient
    {
        public string Server { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }

        public HBaseThriftClient()
        {
            this.Server = "localhost";
            this.Port = 9090;
        }

        public HBaseThriftClient(string server,int port,int timeout)
        {
            this.Server = server;
            this.Port = port;
            this.Timeout = timeout;
        }

        private Tuple<TTransport,Hbase.Client> GenerateAgent()
        {
            var transport = new TSocket(this.Server, this.Port,this.Timeout);
            var protocol = new TBinaryProtocol(transport);
            var client = new Hbase.Client(protocol);
            transport.Open();
            return new Tuple<TTransport,Hbase.Client>(transport,client);
        }

        public void CreateTable(string tableName,string[] columnNames,List<ColumnDescriptor> extras = null)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                List<ColumnDescriptor> columns = new List<ColumnDescriptor>();
                if (extras != null) columns.AddRange(extras);
                if (columnNames != null && columnNames.Length != 0)
                {
                    foreach (var columnname in columnNames)
                    {
                        if (!columns.Exists(cd => cd.StringName == columnname))
                        {
                            columns.Add(new ColumnDescriptor() { Name = columnname.GetUTF8Bytes() });
                        }
                    }
                }
                agent.Item2.createTable(tableName.GetUTF8Bytes(), columns);
            }
            finally
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
            }
        }

        public bool TableExists(string tableName)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                List<byte[]> tables = agent.Item2.getTableNames();
                return tables.Exists(t => Encoding.UTF8.GetString(t) == tableName);
            }
            finally
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
            }
        }

        public void DisableTable(string tableName)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                agent.Item2.disableTable(tableName.GetUTF8Bytes());
            }
            finally
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
            }
        }

        public void EnableTable(string tableName)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                agent.Item2.enableTable(tableName.GetUTF8Bytes());
            }
            finally
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
            }
        }

        public void DeleteTable(string tableName)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                agent.Item2.deleteTable(tableName.GetUTF8Bytes());
            }
            finally
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
            }
        }

        //Key = TableName
        //Value = Item1:Columns Item2:table is enable
        public Dictionary<string, Tuple<ColumnDescriptor[], bool>> GetAllTableDefinition()
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                var names = agent.Item2.getTableNames();
                Dictionary<string, Tuple<ColumnDescriptor[], bool>> results = new Dictionary<string, Tuple<ColumnDescriptor[], bool>>();
                foreach (var name in names)
                {
                    var columns = agent.Item2.getColumnDescriptors(name);
                    bool status = agent.Item2.isTableEnabled(name);
                    results.Add(Encoding.UTF8.GetString(name), new Tuple<ColumnDescriptor[], bool>(columns.Select(c => c.Value).ToArray(), status));
                }
                return results;
            }
            finally
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
            }
        }

        public void MultiplePut(string tableName, List<BatchMutation> rows)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                agent.Item2.mutateRows(tableName.GetUTF8Bytes(), rows, null);
            }
            finally
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
            }
        }

        public List<TRowResult> SingleQuery(string tableName, byte[] rowKey, List<string> columnNames = null, long timestamp = 0)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                List<byte[]> columns = null;
                if (columnNames != null)
                {
                    columns = columnNames.Select(c => c.GetUTF8Bytes()).ToList();
                }
                if (timestamp == 0)
                {
                    return agent.Item2.getRowWithColumns(tableName.GetUTF8Bytes(), rowKey, columns, null);
                }
                else
                {
                    return agent.Item2.getRowWithColumnsTs(tableName.GetUTF8Bytes(), rowKey, columns, timestamp, null);
                }
            }
            finally
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
            }
        }

        public List<TRegionInfo> TableRegionQuery(string tableName)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                List<TRegionInfo> infos = agent.Item2.getTableRegions(tableName.GetUTF8Bytes());
                return infos;
            }
            finally
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
            }
        }


        #region Full Scan
        private static Dictionary<Guid, Tuple<TTransport, Hbase.Client, int>> _tableScan = new Dictionary<Guid, Tuple<TTransport, Hbase.Client, int>>();
        public Guid GetScan(string tableName,byte[] startKey, List<string> columnNames = null)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                List<byte[]> columns = null;
                if (columnNames != null)
                {
                    columns = columnNames.Select(c => c.GetUTF8Bytes()).ToList();
                }
                int scan = agent.Item2.scannerOpen(tableName.GetUTF8Bytes(), startKey, columns, null);
                Guid id = Guid.NewGuid();
                lock (_tableScan)
                {
                    _tableScan[id] = new Tuple<TTransport, Hbase.Client, int>(agent.Item1, agent.Item2, scan);
                }
                return id;
            }
            catch (Exception ex)
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
                throw ex;
            }
        }

        public Guid GetScanWithStop(string tableName, byte[] startKey,byte[] endKey, List<string> columnNames = null)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                List<byte[]> columns = null;
                if (columnNames != null)
                {
                    columns = columnNames.Select(c => c.GetUTF8Bytes()).ToList();
                }
                int scan = agent.Item2.scannerOpenWithStop(tableName.GetUTF8Bytes(), startKey, endKey,columns, null);
                Guid id = Guid.NewGuid();
                lock (_tableScan)
                {
                    _tableScan[id] = new Tuple<TTransport, Hbase.Client, int>(agent.Item1, agent.Item2, scan);
                }
                return id;
            }
            catch (Exception ex)
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
                throw ex;
            }
        }

        public Guid GetScanWithPrefix(string tableName, byte[] prefixKey,List<string> columnNames = null)
        {
            Tuple<TTransport, Hbase.Client> agent = null;
            try
            {
                agent = GenerateAgent();
                List<byte[]> columns = null;
                if (columnNames != null)
                {
                    columns = columnNames.Select(c => c.GetUTF8Bytes()).ToList();
                }
                int scan = agent.Item2.scannerOpenWithPrefix(tableName.GetUTF8Bytes(), prefixKey, columns, null);
                Guid id = Guid.NewGuid();
                lock (_tableScan)
                {
                    _tableScan[id] = new Tuple<TTransport, Hbase.Client, int>(agent.Item1, agent.Item2, scan);
                }
                return id;
            }
            catch (Exception ex)
            {
                if (agent != null && agent.Item1 != null) agent.Item1.Close();
                throw ex;
            }
        }


        public static List<TRowResult> DoScan(Guid id, int count)
        {
            Tuple<TTransport, Hbase.Client, int> scan = null;
            lock (_tableScan)
            {
                if (_tableScan.ContainsKey(id))
                {
                    scan = _tableScan[id];
                }
            }
            if (scan != null)
            {
                lock (scan)
                {
                    return scan.Item2.scannerGetList(scan.Item3, count);
                }
            }
            else
            {
                return null;
            }
        }

        public static void CloseScan()
        {
            lock (_tableScan)
            {
                foreach(var scan in _tableScan)
                {
                    try
                    {
                        scan.Value.Item2.scannerClose(scan.Value.Item3);
                    }
                    catch { }
                    try
                    {
                        scan.Value.Item1.Close();
                    }
                    catch { }
                }
                _tableScan.Clear();
            }
        }

        public static void CloseScan(Guid id)
        {
            Tuple<TTransport, Hbase.Client, int> scan = null;
            lock (_tableScan)
            {
                if (_tableScan.ContainsKey(id))
                {
                    scan = _tableScan[id];
                    _tableScan.Remove(id);
                }
            }
            if (scan != null)
            {
                lock (scan)
                {
                    scan.Item2.scannerClose(scan.Item3);
                }
            }
        }
        #endregion
    }
}
