﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Sample_WebApiModelValidation.Models;
using System.Net;

namespace Sample_WebApiModelValidation.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        [HttpGet]
        public string Get() {
            return "Hello";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Add you logic for storing the customer
                    customer.Id = Guid.NewGuid();

                    string uri = "api/customer/" + customer.Id.ToString();
                    return Created(uri, customer);
                }
                catch (Exception ex)
                {
                    return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return HttpBadRequest(ModelState);
            }
        }
    }
}
