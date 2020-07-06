using System.Threading.Tasks;

namespace industry9.Server.Data
{
    public interface IDatabaseInitializer
    {
        Task SeedAsync();
    }
}
