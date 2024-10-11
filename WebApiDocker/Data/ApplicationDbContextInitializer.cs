using Microsoft.EntityFrameworkCore;

namespace WebApiDocker.Data
{
    public class ApplicationDbContextInitializer
    {
        private readonly ApplicationDbContext _dbContext;
        public ApplicationDbContextInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task InitializeAsync(CancellationToken cancellationToken = default)
        {
            await _dbContext.Database.MigrateAsync(cancellationToken);
        }
    }
}
