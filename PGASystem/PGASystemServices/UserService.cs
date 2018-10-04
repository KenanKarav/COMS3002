using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PGASystemData;
using PGASystemData.Models;

namespace PGASystemServices
{
    public class UserService : IUser
    {
        private readonly PGAContext _ctx;



        public UserService(PGAContext ctx)
        {
            _ctx = ctx;
        }


        /* This method retrieves a list of all Supervisors */
        public List<SelectListItem> GetSupervisors()
        {
            return _ctx.Users
                       .Where(u => u.Position.PositionName == "Supervisor")
                       .Select(u => new SelectListItem()
                       {
                           Value = u.Id.ToString(),
                           Text = u.Title + " " + u.FirstName + " " + u.LastName
                       })
                       .ToList();

        }
        /* This method retrieves User by userId, used to retrieve specifically a Supervisor */
        public Users GetSupervisorById(int userId)
        {
            var user = _ctx.Users.Include(u => u.Position)
                       .FirstOrDefault(u => u.Id == userId);

            /* If no such user exists with given userId, throw an exception */
            if (user is null)
            {
                throw new Exception("Supervisor does not exist");
            }

            return user;
        }

    }
}
