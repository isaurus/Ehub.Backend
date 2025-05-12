
using Microsoft.EntityFrameworkCore;

namespace eHub.Backend.Infrastructure.Context.Mappings
{
    internal interface IEntityMapping<T>
    {
        void Configure(ModelBuilder modelBuilder);
    }
}
