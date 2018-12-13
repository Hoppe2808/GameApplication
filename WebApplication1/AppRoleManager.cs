using GameWebApplication.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameWebApplication
{
    public class AppRoleManager : RoleManager<IdentityRole>
    {

        private readonly GameWebApplicationContext _db = new GameWebApplicationContext();

        public AppRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            var appRoleManager = new AppRoleManager(new RoleStore<IdentityRole>(context.Get<GameWebApplicationContext>()));

            return appRoleManager;
        }
    }
}