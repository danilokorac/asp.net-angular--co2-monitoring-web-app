using BusinessLogicLayer.UserBusinessLogic;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarbonDioxidePollutionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IMeasurementBusinessLayer userBusinessLogic;
        public UserController(IMeasurementBusinessLayer _userBusinessLogic)
        {
            userBusinessLogic = _userBusinessLogic;
        }

        [HttpPost("login")]
        public IActionResult LogIn([FromBody] User user)
        {
            User loggUser = userBusinessLogic.LogIn(user);
            if (loggUser == null)
                return Unauthorized();

            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
            SigningCredentials signingCredential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            List<Claim> claimsList = new List<Claim>();

            claimsList.Add(new Claim("UserID", loggUser.UserID.ToString()));

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: "https://localhost:44362",
                audience: "https://localhost:44362",
                claims: claimsList,
                expires: DateTime.Now.AddMinutes(10),
                signingCredentials: signingCredential
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            return Ok(new { Token = tokenString });
        }

        [HttpPost("register")]
        public IActionResult InsertUser([FromBody] User user)
        {
            if (this.userBusinessLogic.InsertUser(user))
                return Ok();
            else
                return BadRequest();
        }
    }
}
