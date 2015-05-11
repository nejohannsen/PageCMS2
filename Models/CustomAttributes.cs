using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Diagnostics.CodeAnalysis;
using System.Security.Principal;
using System.Web.Mvc.Properties;
using System.ComponentModel.DataAnnotations;

namespace CustomAttributes
{
    public class CombinedUniquness : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return base.IsValid(value);
        }

    }
}