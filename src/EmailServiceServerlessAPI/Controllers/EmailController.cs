﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmailServiceServerlessAPI.Models;
using EmailServiceServerlessAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EmailServiceServerlessAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;
        private readonly Logger<EmailController> _logger;

        public EmailController(EmailService emailService, Logger<EmailController> logger)
        {
            _emailService = emailService;
            _logger = logger;
        }
       

        // POST api/email
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmailEnquiryModel email)
        {
            _emailService.SendEmail(email);
            return Ok();
        }
     
    }
}
