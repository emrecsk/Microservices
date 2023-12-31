﻿using FreeCourse.IdentityServer_2.Models;
using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeCourse.IdentityServer_2.Services
{
    public class IdentityResourcesOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public IdentityResourcesOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
           var existUser = _userManager.Users.Where(x => x.Email == "emrecsk@gmail.com").FirstOrDefault();

            if (existUser == null)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email or password not correct" });

                context.Result.CustomResponse = errors;
                return;
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(existUser, context.Password);

            if (!passwordCheck)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email or password not correct" });

                context.Result.CustomResponse = errors;
                return;
            }

            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);    
        }
    }
}
