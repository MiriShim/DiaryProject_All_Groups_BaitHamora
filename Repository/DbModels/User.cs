﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Repository.DbModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        //DataAnnotations::
        [MinLength (2)]
        [MaxLength(200)]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }

    }
}