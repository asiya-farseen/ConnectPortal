using FWS.DataAccess.Repository.IRepository;
using FWS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FWS.DataAccess.Repository
{
    public class ResourceRepository : Repository<Resource>, IResourceRepository
    {
        private ApplicationDbContext _db;

        public ResourceRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(Resource obj)
        {
            var objFromDb = _db.Resources.FirstOrDefault(u => u.jobId == obj.jobId);
            if (objFromDb != null)
            {
                objFromDb.JobTitle = obj.JobTitle;
                objFromDb.SkillSet = obj.SkillSet;
                objFromDb.Experience = obj.Experience;
                objFromDb.StartDateOfJob = obj.StartDateOfJob;
                objFromDb.EndDateOfJob = obj.EndDateOfJob;
                objFromDb.NumberOfResource = obj.NumberOfResource;
                objFromDb.CustomercustId = obj.CustomercustId;
                objFromDb.projectId = obj.projectId;
            }
        }
    }
}
