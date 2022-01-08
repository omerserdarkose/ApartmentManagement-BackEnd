using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace ApartmentManagement.Core.CrossCuttingConcern.Validation.FluentValidation
{
    public static class ValidatorTool
    {
        /// <summary>
        /// validasyon islemlerini merkezilestirmek icin kullanilacak validasyon kurallarini ve valide edilecek objeyi alip 
        /// validasyon gecersiz olursa hata dondurur
        /// </summary>
        /// <param name="validator">validasyon kurallarini iceren sinif</param>
        /// <param name="entity">valide edilecek obje</param>
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
