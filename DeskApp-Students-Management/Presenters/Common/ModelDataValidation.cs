using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskApp_Students_Management.Presenters.Common
{
    public class ModelDataValidation
    {
        public void Validate(object model)
        {
            string errMessage = "";
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);
            bool isValid = Validator.TryValidateObject(model, context, results, true);
            if(!isValid)
            {
                foreach(var item in results)
                {
                    errMessage += "- " + item.ErrorMessage + "\n";
                }
                throw new Exception(errMessage);
            }
        }
    }
}
