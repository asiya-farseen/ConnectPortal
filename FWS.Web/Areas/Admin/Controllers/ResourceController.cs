
using FWS.DataAccess;
using FWS.DataAccess.Repository.IRepository;
using FWS.Models;
using FWS.Models.ViewModels;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FWSWeb.Areas.Admin.Controllers
{
    [Area("Admin")]


    public class ResourceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResourceController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }



        //GET
        public IActionResult Upsert(int? id)
        {
            ResourceVM resourceVM = new()
            {
                Resource = new(),
                CustomerList = _unitOfWork.Customer.GetAll().Select(i => new SelectListItem
                {
                    Text = i.CustName,
                    Value = i.custId.ToString()
                }),
                ProjectList = _unitOfWork.Project.GetAll().Select(i => new SelectListItem
                {
                    Text = i.ProjName,
                    Value = i.projId.ToString()
                })
            };

            if (id == null || id == 0)
            {
                //create
                //ViewBag.CustomerList = CustomerList;
                //ViewData["ProjectManagerList"] = ProjectManagerList;
                return View(resourceVM);
            }
            else
            {
                resourceVM.Resource = _unitOfWork.Resource.GetFirstOrDefault(u => u.jobId == id);
                return View(resourceVM);
                //update
            }



        }


        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ResourceVM obj)
        {


            if (ModelState.IsValid)
            {
                if (obj.Resource.jobId == 0)
                {
                    _unitOfWork.Resource.Add(obj.Resource);
                }
                else
                {
                    _unitOfWork.Resource.Update(obj.Resource);
                }
                _unitOfWork.Save();
                TempData["success"] = "Resource added successfully";
                return RedirectToAction("Index");
            }


            return View(obj);
        }

        ////GET
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var projectFromDbFirst = _unitOfWork.Project.GetFirstOrDefault(u => u.projectId == id);


        //    if (projectFromDbFirst == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(projectFromDbFirst);
        //}


        ////POST
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeletePOST(int? id)
        //{
        //    var obj = _unitOfWork.Project.GetFirstOrDefault(u => u.projectId == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }

        //    _unitOfWork.Project.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "Project deleted successfully";
        //    return RedirectToAction("Index");

        //}

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {

            var resourceList = _unitOfWork.Resource.GetAll(includeProperties: "Customer");
            return Json(new { data = resourceList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Resource.GetFirstOrDefault(u => u.jobId == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting!" });
            }

            _unitOfWork.Resource.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete successful" });

        }
        #endregion
    }




}

