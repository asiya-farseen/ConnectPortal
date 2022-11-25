using FWS.DataAccess;
using FWS.DataAccess.Repository.IRepository;
using FWS.Models;
using Microsoft.AspNetCore.Mvc;

namespace FWSWeb.Areas.Admin.Controllers
    
{
    [Area("Admin")]
    public class CustomerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Customer> objCustomerList = _unitOfWork.Customer.GetAll();
            return View(objCustomerList);
        }
        //GET
        public IActionResult Create()
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer obj)
        {
            //if (obj.Email == obj.Email.ToString())

            //{
            //    ModelState.AddModelError("Email", "Email already Exists");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Customer.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Customer Added Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? CustId)
        {
            if (CustId == null || CustId == 0)
            {
                return NotFound();
            }
            // var CustomerFromDb = _db.Customers.Find(CustId);
            var CustomerFromDbFirst = _unitOfWork.Customer.GetFirstOrDefault(u => u.custId == CustId);
            if (CustomerFromDbFirst == null)
            {
                return NotFound();
            }

            return View(CustomerFromDbFirst);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer obj)
        {

            //if (obj.Email == obj.Email.ToString())

            //{
            //    ModelState.AddModelError("CustomError", "Email already Exists");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Customer.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Customer Updated Sucessfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        public IActionResult Delete(int? CustId)
        {
            if (CustId == null || CustId == 0)
            {
                return NotFound();
            }
            // var CustomerFromDb = _db.Customers.Find(CustId);
            var CustomerFromDbFirst = _unitOfWork.Customer.GetFirstOrDefault(u => u.custId == CustId);
            if (CustomerFromDbFirst == null)
            {
                return NotFound();
            }

            return View(CustomerFromDbFirst);
        }

        //POST
        [HttpPost, ActionName("DeletePOST")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? CustId)
        {

            var obj = _unitOfWork.Customer.GetFirstOrDefault(u => u.custId == CustId);

            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Customer.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Customer Deleted Sucessfully";
            return RedirectToAction("Index");

        }
    }

}
