namespace OnlineRetailStore.Context
{
    public class OnlineRetailStoreDbSettings : IOnlineRetailStoreDbSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string ProductsCollectionName { get; set; } = null!;
        public string OrdersCollectionName { get; set; } = null!;
    }
}
