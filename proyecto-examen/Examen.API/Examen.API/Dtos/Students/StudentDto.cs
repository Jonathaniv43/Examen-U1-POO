﻿using System.ComponentModel.DataAnnotations;

namespace Examen.API.Dtos.Students
{
    public class StudentDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
