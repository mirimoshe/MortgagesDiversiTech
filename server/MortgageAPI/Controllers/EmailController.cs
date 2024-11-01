﻿using AutoMapper;
using Common.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using Repositories.Entities;
using Repositories.Interface;
using Service.Interfaces;
using Service.Services;
using System.Security.Cryptography;
using System.Web;
using static Dropbox.Api.Files.ListRevisionsMode;
using IEmailService = Service.Interfaces.IEmailService;

namespace MortgageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailService _emailService;
        private readonly IContext _context;
        private readonly IService<LeadsDto> _service;
        private readonly ILoginService _userService;
        private readonly IMapper _mapper;


        public EmailController(IEmailService emailService,IContext context, IService<LeadsDto> service, IMapper mapper, ILoginService userService)
        {
            _emailService = emailService;
            _context = context;
            _service = service;
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost("send-magic-link")]//[FromBody] string email,
        [Authorize(Policy = "AdminPolicy")]

        public async Task<IActionResult> SendMagicLink(int id)
        {
            var token = GenerateToken();
            var lead = await _service.GetAsync(id);
            lead.Token = token;
            lead.Expiration = DateTime.UtcNow.AddMinutes(15);
            await _service.UpdateAsync(id, _mapper.Map<LeadsDto>(lead));
            string subject = "Your Magic Login Link";
            string body = $@"
        <html>
        <body style='margin: 0; padding: 0;'>
            <table width='100%' cellspacing='0' cellpadding='0'>
                <tr>
                    <td align='center' style='padding: 10px;'>
                        <table width='600' cellspacing='0' cellpadding='0' style='border: 1px solid #cccccc;'>
                            <tr>
                                <td align='center' style='padding: 40px 0 30px 0; background-color: #f2f2f2;'>
                                    <h1 style='margin: 0; font-size: 48px; font-family: Arial, sans-serif;'>
                                        <span style='color: rgb(183, 182, 182);'>Y</span>.<span style='color: rgba(255, 68, 0, 0.749);'>B</span>
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td align='center' style='padding: 30px; background-color: #ffffff;'>
                                    <h2 style='color: rgba(255, 115, 0, 0.955); font-size: 32px; font-family: Arial, sans-serif;'>
                                        Welcome!
                                    </h2>
                                    <p style='font-family: Arial, sans-serif; font-size: 16px;'>
                                        Click <a href=`http://localhost:4200/lead/magic-link?token={token}&id={id}` style='color: #ff7300;'>here</a> to log in.

                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td align='center' style='padding: 20px; background-color: #f2f2f2;'>
                                    <p style='margin: 0; font-family: Arial, sans-serif; font-size: 12px; color: #666666;'>
                                        © Your App. All rights reserved.
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </body>
        </html>";
            await _emailService.SendGeneral(lead.Email, subject, body);
            return Ok("Magic link sent.");
        }

        private string GenerateToken()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var tokenData = new byte[32];
                rng.GetBytes(tokenData);
                return Convert.ToBase64String(tokenData);
            }
        }


        [HttpPost("send-mailing-list/{recipients}")]
        [Authorize(Policy = "AdminPolicy")]
        public async Task<IActionResult> SendMailingList(string recipients, [FromBody] EmailRequest emailRequest)
        {
            if (string.IsNullOrWhiteSpace(recipients))
            {
                return BadRequest("Recipients list is empty.");
            }

            var recipientList = recipients.Split(',').ToList();
            if (recipientList.Count == 0)
            {
                return BadRequest("No valid recipients.");
            }

            await _emailService.SendMailingList(recipientList, emailRequest.Subject, emailRequest.Body);
            return Ok();
        }


        [Authorize(Policy = "AdminPolicy")]

        [HttpPost("send-general/{toEmail}/{subject}/{body}")]
        public async Task SendGeneral(string toEmail,string subject, string body)
        {
            await _emailService.SendGeneral(toEmail, subject, body);
        }


        [HttpGet("validate-magic-link/{id}")]
        public async Task<IActionResult> ValidateMagicLink(int id)
        {
            var lead = await _service.GetAsync(id);
            var isValid = await IsTokenValid(lead);
            if (isValid)
            {
                return Ok("Token is valid.");
            }
            return BadRequest("Token is invalid or expired.");
        }


        private async Task<bool> IsTokenValid(LeadsDto lead)
        {
            if (lead == null || lead.Expiration < DateTime.UtcNow)
            {
                return false;
            }
            return true;
        }



        [HttpPost("/password/{email}")]
        public async Task<ActionResult> ResetPassword(string email)
        {
            Console.WriteLine("in reset");
            var u = this._userService.SetPassword(email);
            if (u != null)
            {
            //    var baseUrl = "http://localhost:4200/auth/forgot-password/";
            //    var userJson = System.Text.Json.JsonSerializer.Serialize(u);
            //    var encodedUserJson = HttpUtility.UrlEncode(userJson);
            //    var completeUrl = $"{baseUrl}{encodedUserJson}";
                int usrId=u.Id;
                Console.WriteLine("in reset and found the user");
                string subject = "reset password";
                string body = $@"
        <html>
        <body style='margin: 0; padding: 0;'>
            <table width='100%' cellspacing='0' cellpadding='0'>
                <tr>
                    <td align='center' style='padding: 10px;'>
                        <table width='600' cellspacing='0' cellpadding='0' style='border: 1px solid #cccccc;'>
                            <tr>
                                <td align='center' style='padding: 40px 0 30px 0; background-color: #f2f2f2;'>
                                    <h1 style='margin: 0; font-size: 48px; font-family: Arial, sans-serif;'>
                                        <span style='color: rgb(183, 182, 182);'>Y</span>.<span style='color: rgba(255, 68, 0, 0.749);'>B</span>
                                    </h1>
                                </td>
                            </tr>
                            <tr>
                                <td align='center' style='padding: 30px; background-color: #ffffff;'>
                                    <h2 style='color: rgba(255, 115, 0, 0.955); font-size: 32px; font-family: Arial, sans-serif;'>
                                       reset password איפוס סיסמא---
                                    </h2>
                                    <p style='font-family: Arial, sans-serif; font-size: 16px;'>
                                        Click <a href='http://localhost:4200/auth/forgot-password/{usrId}' style='color: #ff7300;'>here</a> to reset password.
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td align='center' style='padding: 20px; background-color: #f2f2f2;'>
                                    <p style='margin: 0; font-family: Arial, sans-serif; font-size: 12px; color: #666666;'>
                                        © Your App. All rights reserved.
                                    </p>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </body>
        </html>";
                await _emailService.SendGeneral(email, subject, body);
                //var token = Generate(u);
                return Ok(u);//token
            }
            return NotFound("user not found");
        }
    }
}
