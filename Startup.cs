﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FINALP2.Startup))]
namespace FINALP2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
