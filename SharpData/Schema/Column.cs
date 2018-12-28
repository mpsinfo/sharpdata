using System.Data;

namespace SharpData.Schema {
    public class Column {

        public DbType Type { get; set; }
        public string ColumnName { get; set; }
        public int Size { get; set; }
        public bool IsNullable { get; set; }
        public object DefaultValue { get; set; }
        public string Comment { get; set; }
        
        private bool _isPrimaryKey;
        public bool IsPrimaryKey {
            get => _isPrimaryKey;
            set {
                _isPrimaryKey = value;
                if (_isPrimaryKey) {
                    IsNullable = false;
                }
            }
        }

        private bool _isAutoIncrement;
        public bool IsAutoIncrement {
            get => _isAutoIncrement;
            set {
                _isAutoIncrement = value;
                if (_isAutoIncrement) {
                    IsNullable = false;
                }
            }
        }

        public Column(string name, DbType type = DbType.String) {
            ColumnName = name;
            IsAutoIncrement = false;
            Type = type;
            IsNullable = true;
        }
        
        public static FluentColumn AutoIncrement(string name) { 
            var fc = new FluentColumn(name, DbType.Int32);
            fc.Object.IsAutoIncrement = true;
            return fc; 
        }
        public static FluentColumn AnsiString(string name, int size = 0) { return new FluentColumn(name, DbType.AnsiString, size); }
        public static FluentColumn String(string name, int size = 0) { return new FluentColumn(name, DbType.String, size); }
        public static FluentColumn Clob(string name, int size = System.Int32.MaxValue) { return new FluentColumn(name, DbType.String, size); }
        public static FluentColumn Binary(string name, int size = System.Int32.MaxValue) { return new FluentColumn(name, DbType.Binary, size); }
        public static FluentColumn Int16(string name) { return new FluentColumn(name, DbType.Int16); }
        public static FluentColumn Int32(string name) { return new FluentColumn(name, DbType.Int32); }
        public static FluentColumn Int64(string name) { return new FluentColumn(name, DbType.Int64); }
        public static FluentColumn Boolean(string name) { return new FluentColumn(name, DbType.Boolean); }
        public static FluentColumn Date(string name) { return new FluentColumn(name, DbType.Date); }
        public static FluentColumn DateTime(string name) { return new FluentColumn(name, DbType.DateTime); }
        public static FluentColumn Decimal(string name, int precision = -1) { return new FluentColumn(name, DbType.Decimal, precision); }
        public static FluentColumn Single(string name) { return new FluentColumn(name, DbType.Single); }
        public static FluentColumn Double(string name) { return new FluentColumn(name, DbType.Double); }
        public static FluentColumn Guid(string name) { return new FluentColumn(name, DbType.Guid); }
    }
}
