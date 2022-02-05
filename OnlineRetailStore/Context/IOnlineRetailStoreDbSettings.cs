namespace OnlineRetailStore.Context
{
    public interface IOnlineRetailStoreDbSettings
    {
        string ConnectionString { get; set; }

        string DatabaseName { get; set; }

        string ProductsCollectionName { get; set; }
        string OrdersCollectionName { get; set; }
    }
}
