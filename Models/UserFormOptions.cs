using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace JPT.Models
{
    public static class UserFormOptions
    {
        public static List<SelectListItem> Branches { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "001", Text = "001 - Athara saya khola Saccos" },
            new SelectListItem { Value = "002", Text = "002 - Branch 2" },
            new SelectListItem { Value = "003", Text = "003 - Branch 3" }
        };

        public static List<SelectListItem> Counters { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "001-001-B1", Text = "001-001 - B1 Counter" },
            new SelectListItem { Value = "001-002-B2", Text = "001-002 - B2 Counter" },
            new SelectListItem { Value = "001-003-B3", Text = "001-003 - B3 Counter" }
        };

        public static List<SelectListItem> Roles { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "admin", Text = "Admin" },
            new SelectListItem { Value = "user", Text = "User" },
            new SelectListItem { Value = "manager", Text = "Manager" }
        };

        public static List<SelectListItem> Genders { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "male", Text = "Male" },
            new SelectListItem { Value = "female", Text = "Female" },
            new SelectListItem { Value = "other", Text = "Other" }
        };

        public static List<SelectListItem> PasswordOptions { get; } = new List<SelectListItem>
        {
            new SelectListItem { Value = "manual", Text = "Manual" },
            new SelectListItem { Value = "auto", Text = "Auto" }
        };
    }
}
