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
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private ApplicationDbContext _db;

        public ProjectRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Project obj)
        {
            var objFromDb = _db.Projects.FirstOrDefault(u => u.projId == obj.projId);
            if (objFromDb != null)
            {
                objFromDb.ProjName = obj.ProjName;
                objFromDb.description = obj.description;
                objFromDb.startDate = obj.startDate;
                objFromDb.EndDate = obj.EndDate;
                objFromDb.CustomercustId = obj.CustomercustId;
                objFromDb.ProjectManagerpmId = obj.ProjectManagerpmId;
            }
        }
    }
}
