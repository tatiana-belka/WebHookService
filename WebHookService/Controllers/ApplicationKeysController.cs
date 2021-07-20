using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebhooksAPIStore.Repository;
using WebhooksAPIStore.Models;
using WebhooksAPIStore.AES256Encryption;
using Microsoft.AspNetCore.Http;
using WebhooksAPIStore.Filters;
using Newtonsoft.Json;



namespace WebhooksAPIStore.Controllers
{
    [ValidateUserSession]
    public class ApplicationKeysController : Controller
    {
        IServicesStore _IServicesStore;
        ISize _ISize;
        IAPIManager _IAPIManager;
        public ApplicationKeysController(IServicesStore IServicesStore, ISize ISize, IAPIManager IAPIManager)
        {
            _IServicesStore = IServicesStore;
            _ISize = ISize;
            _IAPIManager = IAPIManager;
        }

        [HttpGet]
        // GET: /<controller>/
        public IActionResult GenerateKeys()
        {
            try
            {

                GenerateKeysVM generateKeysVM = new GenerateKeysVM();
                generateKeysVM.ListServices = _IServicesStore.GetServiceList();
                generateKeysVM.ListSize = _ISize.GetSizeList();
                return View(generateKeysVM);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult GenerateKeys(GenerateKeysVM generateKeysVM)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var userID = Convert.ToInt32(HttpContext.Session.GetString("UserID"));

                    if (_IAPIManager.isApikeyAlreadyGenerated(generateKeysVM.ServiceID, userID) > 0)
                    {
                        ModelState.AddModelError("", "Api Key for Choosen Service is Already Generated");
                        generateKeysVM.ListServices = _IServicesStore.GetServiceList();
                        generateKeysVM.ListSize = _ISize.GetSizeList();
                        return View(generateKeysVM);
                    }

                    generateKeysVM.ListServices = _IServicesStore.GetServiceList();
                    generateKeysVM.ListSize = _ISize.GetSizeList();

                    if (GenerateKey(generateKeysVM) == 1)
                    {
                        TempData["APIKeyGeneratedMessage"] = "Done";
                    }
                    else
                    {
                        TempData["APIKeyGeneratedMessage"] = "Failed";
                    }

                    return View(generateKeysVM);
                }

                generateKeysVM.ListServices = _IServicesStore.GetServiceList();
                generateKeysVM.ListSize = _ISize.GetSizeList();


                return View(generateKeysVM);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [NonAction]
        public int GenerateKey(GenerateKeysVM GenerateKeysVM)
        {
            try
            {
                APIManagerTB aPIManagerTB = new APIManagerTB()
                {
                    APIKey = EncryptionLibrary.KeyGenerator.GetUniqueKey(),
                    SizeID = GenerateKeysVM.SizeID,
                    CreatedOn = DateTime.Now,
                    ServiceID = GenerateKeysVM.ServiceID,
                    UserID = Convert.ToInt32(HttpContext.Session.GetString("UserID")),
                    Status = "A"
                };

                return _IAPIManager.GenerateandSaveToken(aPIManagerTB);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public IActionResult DeactivateService(string ServiceID)
        {
            try
            {
                var result = _IAPIManager.DeactivateService(Convert.ToInt32(ServiceID), Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                return Json(data: result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IActionResult ReActivateService(string ServiceID)
        {
            try
            {
                var result = _IAPIManager.ReactivateService(Convert.ToInt32(ServiceID), Convert.ToInt32(HttpContext.Session.GetString("UserID")));
                return Json(data: result);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
