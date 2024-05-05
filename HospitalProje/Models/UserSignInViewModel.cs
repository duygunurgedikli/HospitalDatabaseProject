﻿using System.ComponentModel.DataAnnotations;

namespace HospitalProje.Models
{
	public class UserSignInViewModel
	{
		[Required(ErrorMessage = "Lütfen kullanıcı adını giriniz")]
		public string Username { get; set; }

		[Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
		public string Password { get; set; }
	}
}