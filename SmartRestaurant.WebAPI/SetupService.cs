using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.WebAPI
{
    public class SetupService
    {
        public static void Init(AppDBContext context)
        {
            context.Database.Migrate();
        }
    }
}
