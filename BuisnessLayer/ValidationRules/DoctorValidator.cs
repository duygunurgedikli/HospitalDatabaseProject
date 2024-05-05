using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.ValidationRules
{
    public class DoctorValidator : AbstractValidator<Doctor>
    {
        public DoctorValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen doktor adını giriniz");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Lütfen doktor soyadını giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen doktor görselini giriniz");
            RuleFor(x => x.Branch).NotEmpty().WithMessage("Lütfen doktor branşını giriniz");
            RuleFor(x => x.Concact).NotEmpty().WithMessage("Lütfen doktor iletişim bilgilerini giriniz");
            RuleFor(x => x.Status).NotEmpty().WithMessage("Lütfen doktor durumunu giriniz");

            //RuleFor(x => x.Name).MaximumLength(30).WithMessage("lütfen 30 karakterden daha kısa bir isim giriniz");
            //RuleFor(x => x.Name).MinimumLength(2).WithMessage("lütfen 8 karakterden daha uzun bir isim giriniz");
        }
    }
   
}
