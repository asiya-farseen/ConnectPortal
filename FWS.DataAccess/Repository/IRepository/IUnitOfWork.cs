using FWS.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FWS.DataAccess.Repository.IRepository
{
   public interface IUnitOfWork
    {
        ICustomerRepository Customer { get; }
        IProjectManagerRepository ProjectManager { get; }
        IProjectRepository Project { get; }
        IResourceRepository Resource { get; }


        void Save();
    }
}
