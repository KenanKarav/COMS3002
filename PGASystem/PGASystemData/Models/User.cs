﻿using System;
namespace PGASystemData.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Position Position { get; set; }
    }

}
