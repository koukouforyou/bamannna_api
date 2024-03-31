using Bamanna.DouDian.EntityFrameworkCore;

namespace Bamanna.DouDian.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly DouDianDbContext _context;

        public InitialHostDbBuilder(DouDianDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
