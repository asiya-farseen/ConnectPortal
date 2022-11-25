using FWS.DataAccess;
using FWS.DataAccess.Repository.IRepository;
using FWS.Models;
using Microsoft.AspNetCore.Mvc;

namespace FWSWeb.Areas.Admin.Controllers

{
    [Area("Admin")]
    public class ProjectManagerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProjectManagerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<ProjectManager> objProjectManagerList = _unitOfWork.ProjectManager.GetAll();
            return View(objProjectManagerList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProjectManager obj)
        {
            //if (obj.Email == obj.Email.ToString())

            //{
            //    ModelState.AddModelError("Email", "Email already Exists");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.ProjectManager.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Project Manager Added Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? PmId)
        {
            if (PmId == null || PmId == 0)
            {
                return NotFound();
            }
            // var CustomerFromDb = _db.Customers.Find(CustId);
            var ProjectManagerFromDbFirst = _unitOfWork.ProjectManager.GetFirstOrDefault(u => u.pmId == PmId);
            if (ProjectManagerFromDbFirst == null)
            {
                return NotFound();
            }

            return View(ProjectManagerFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProjectManager obj)
        {

            //if (obj.Email == obj.Email.ToString())

            //{
            //    ModelState.AddModelError("CustomError", "Email already Exists");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.ProjectManager.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Project Manager Updated Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? PmId)
        {
            if (PmId == null || PmId == 0)
            {
                return NotFound();
            }
            // var CustomerFromDb = _db.Customers.Find(CustId);
            var ProjectManagerFromDbFirst = _unitOfWork.ProjectManager.GetFirstOrDefault(u => u.pmId == PmId);
            if (ProjectManagerFromDbFirst == null)
            {
                return NotFound();
            }

            return View(ProjectManagerFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("DeletePOST")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? PmId)
        {

            var obj = _unitOfWork.ProjectManager.GetFirstOrDefault(u => u.pmId == PmId);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ProjectManager.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Project Manager Deleted Sucessfully";
            return RedirectToAction("Index");

        }
    }

}
