using SharpData;

namespace SharpData.Fluent {
    public class RemoveIndexKey : RemoveItemFromTable, IRemoveFromTable {
        public RemoveIndexKey(IDataClient dataClient, string indexKeyName) : base(dataClient) {
            ItemName = indexKeyName;
        }

        protected override void ExecuteInternal() {
            DataClient.RemoveIndex(ItemName, TableNames[0]);
        }
    }
}