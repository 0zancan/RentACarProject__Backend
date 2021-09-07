using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Name).Must(StartWithA).WithMessage("Ürünler A harfi ile başlamalıdır!");
        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
            // A ile başlıyorsa true döner hata almaz dönmezse hata alır!
        }
    }
}
