using Entities.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(k => k.DisplayName).NotEmpty().WithMessage("Görünecek isim boş olamaz.");
            RuleFor(k => k.Title).NotEmpty().WithMessage("Müşteri ünvanı boş olamaz.");
            RuleFor(k => k.TaxOffice).NotEmpty().WithMessage("Vergi dairesi boş olamaz.");
            RuleFor(k => k.TaxNumber).MaximumLength(10).When(k => k.TaxNumber != null)
                .WithMessage("Vergi numarası en fazla 10 karakter olabilir.");
            RuleFor(k => k.Identifier).MaximumLength(11).When(k => k.TaxNumber != null)
                .WithMessage("Vergi numarası en fazla 11 karakter olabilir.");
        }
    }
}
