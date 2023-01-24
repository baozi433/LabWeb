namespace LabWeb.DataStore.Contracts
{
    public interface ISqlDataAccess
    {
        string connectionStringName { get; set; }

        Task<List<T>> LoadData<T, U>(string sql, U parameters);
        Task<T> LoadSingleData<T, U>(string sql, U parameters);
        Task<int> SaveData<T>(string sql, T parameters);
    }
}