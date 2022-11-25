using FWS.DataAccess.Repository.IRepository;
using FWS.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FWS.DataAccess.Repository
{
    public class ProjectManagerRepository : Repository<ProjectManager>, IProjectManagerRepository
    {
        private ApplicationDbContext _db;

        public ProjectManagerRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(ProjectManager obj)
        {
           // _db.ProjectMangers.Update(obj);
        }
    }
}
