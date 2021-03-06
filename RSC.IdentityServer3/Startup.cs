﻿using IdentityServer3.Core.Configuration;
using Owin;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using IdentityServer3.Core.Services;

namespace RSC.IdentityServer3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory()
                .UseInMemoryClients(Clients.Get())
                .UseInMemoryScopes(Scopes.Get());
            
            factory.UserService = new Registration<IUserService, LocalAuthenticationService>();

            app.UseIdentityServer(new IdentityServerOptions
            {
                SiteName = "Identity server",
                RequireSsl = false,
                SigningCertificate = LoadCertificate(),

                Factory = factory
            });
        }

        private static X509Certificate2 LoadCertificate()
        {
            return new X509Certificate2(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"idsrv3test.pfx"), "idsrv3test");
        }
    }
}