using System.IO;
using SharpData.Databases;
using SharpData.Exceptions;
using SharpData.Tests.Integration.Data;
using Xunit;

namespace SharpData.Tests.Integration.SQLite {
    public class SqLiteSchemaTests : DataClientSchemaTests {
        public SqLiteSchemaTests() {
            var fileName = "hot.db3";
            if (File.Exists(fileName)) {
                File.Delete(fileName);
            }
            //SQLiteConnection.CreateFile(fileName);
        }

        protected override DbProviderType GetDataProviderName() {
            return DbProviderType.SqLite;
        }

        [Fact]
        public override void Can_add_foreign_key_to_table() {
            try {
                base.Can_add_foreign_key_to_table();
                Assert.True(false);
            }
            catch (NotSupportedByDialectException ex) {
                Assert.Equal("SqLiteDialect", ex.DialectName);
                Assert.Equal("GetForeignKeySql", ex.FunctionName);
            }
        }

        [Fact]
        public override void Can_add_named_primary_key_to_table() {
            try {
                base.Can_add_named_primary_key_to_table();
                Assert.True(false);
            }
            catch (NotSupportedByDialectException ex) {
                Assert.Equal("SqLiteDialect", ex.DialectName);
                Assert.Equal("GetPrimaryKeySql", ex.FunctionName);
            }
        }

        [Fact]
        public override void Can_add_primary_key_to_table() {
            try {
                base.Can_add_primary_key_to_table();
                Assert.True(false);
            }
            catch (NotSupportedByDialectException ex) {
                Assert.Equal("SqLiteDialect", ex.DialectName);
                Assert.Equal("GetPrimaryKeySql", ex.FunctionName);
            }
        }

        [Fact]
        public override void Can_remove_column_from_table() {
            try {
                base.Can_remove_column_from_table();
                Assert.True(false);
            }
            catch (NotSupportedByDialectException ex) {
                Assert.Equal("SqLiteDialect", ex.DialectName);
                Assert.Equal("GetDropColumnSql", ex.FunctionName);
            }
        }


        [Fact]
        public override void Can_remove_foreign_key_from_table() {
            try {
                DataClient.RemoveForeignKey("foo", "bar");
                Assert.True(false);
            }
            catch (NotSupportedByDialectException ex) {
                Assert.Equal("SqLiteDialect", ex.DialectName);
                Assert.Equal("GetDropForeignKeySql", ex.FunctionName);
            }
        }
    }
}