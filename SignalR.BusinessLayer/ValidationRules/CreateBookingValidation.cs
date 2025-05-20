using FluentValidation;
using SignalR.DTOLayer.BookingDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.ValidationRules
{
    public class CreateBookingValidation:AbstractValidator<CreateBookingDTO>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.BookingName).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.BookingPhone).NotEmpty().WithMessage("Telefon alanı boş geçilemez!");
            RuleFor(x => x.BookingMail).NotEmpty().WithMessage("Mail alanı boş geçilemez!");
            RuleFor(x => x.BookingPersonCount).NotEmpty().WithMessage("Kişi sayısı alanı boş geçilemez!");
            RuleFor(x => x.BookingDate).NotEmpty().WithMessage("Tarih alanı boş geçilemez!");

            RuleFor(x => x.BookingName).MinimumLength(3).WithMessage("İsim alanı en az 3 karakter içermelidir!");
            RuleFor(x => x.BookingDescription).MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter içerebilir!");

            RuleFor(x => x.BookingMail).EmailAddress().WithMessage("Lütfen geçerli bir E-Mail adresi giriniz!");
        }
    }
}
