
using Microsoft.EntityFrameworkCore;

namespace eHub.Backend.Infrastructure.Context.Mappings
{
    public interface IEntityMapping<T>
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
