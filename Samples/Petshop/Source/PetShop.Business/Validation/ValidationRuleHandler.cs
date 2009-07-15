using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.Business.Validation
{
   /// <summary>
   /// Delegate providing the signature of all methods that will process validation rules.
   /// </summary>
   /// <remarks>
   /// <para>
   /// The method handler should set the Description attribute of the 
   /// <see cref="ValidationRuleArgs"/> parameter so that a meaningful
   /// error is returned.
   /// </para><para>
   /// If the data is valid, the method must return true.  If the data is invalid,
   /// the Description should be set the false should be returned.
   /// </para>
   /// </remarks>
   public delegate bool ValidationRuleHandler(object target, ValidationRuleArgs e);
   
}