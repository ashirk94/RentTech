﻿using System.ComponentModel.DataAnnotations;

namespace RentTech.Models.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Please enter a username.")]
        [StringLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(20)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        [StringLength(20)]
        public string LastName { get; set; }
    }
}
