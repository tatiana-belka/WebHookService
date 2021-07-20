﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebhooksAPIStore.Models;
using WebhooksAPIStore.Repository;
using WebhooksAPIStore.AES256Encryption;



namespace WebhooksAPIStore.Controllers
{
    public class RegisterUserController : Controller
    {
        IRegisterUser _repository;
        public RegisterUserController(IRegisterUser repository)
        {
            _repository = repository;
        }

        [HttpGet]
        // GET: RegisterUser/Create
        public ActionResult Create()
        {
            return View(new RegisterUser());
        }

        // POST: RegisterUser/Create
        [HttpPost]
        public ActionResult Create(RegisterUser RegisterUser)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Create", RegisterUser);
                }

                
                if (_repository.ValidateUsername(RegisterUser))
                {
                    ModelState.AddModelError("", "User is Already Registered");
                    return View("Create", RegisterUser);
                }
                RegisterUser.CreateDate = DateTime.Now;

                
                RegisterUser.Password = EncryptionLibrary.EncryptText(RegisterUser.Password);

                
                _repository.Add(RegisterUser);
                TempData["UserMessage"] = "User Registered Successfully";
                ModelState.Clear();
                return View("Create", new RegisterUser());
            }
            catch
            {
                return View();
            }
        }
    }
}
