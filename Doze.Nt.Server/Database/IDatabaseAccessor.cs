namespace Doze.Nt.Server.Database
{
    public interface IDatabaseAccessor
    {
        int GetAccessCount();
        int GetQueriesCount();
    }
}
