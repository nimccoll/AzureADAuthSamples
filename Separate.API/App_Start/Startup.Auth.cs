﻿//===============================================================================
// Microsoft Premier Support for Developers
// Azure Active Directory Authentication Samples
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin.Security.ActiveDirectory;
using Owin;
using System;
using System.Configuration;

namespace Separate.API
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            WindowsAzureActiveDirectoryBearerAuthenticationOptions options = new WindowsAzureActiveDirectoryBearerAuthenticationOptions();

            options.Tenant = ConfigurationManager.AppSettings["ida:Tenant"];
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = Convert.ToBoolean(ConfigurationManager.AppSettings["ida:ValidateAudience"]),
                ValidAudience = ConfigurationManager.AppSettings["ida:Audience"]
            };

            app.UseWindowsAzureActiveDirectoryBearerAuthentication(options);
        }
    }
}