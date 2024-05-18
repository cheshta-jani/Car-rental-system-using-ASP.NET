using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    [MetadataType(typeof(customerMetaData))]
    public partial class customer
    {
        public class customerMetaData
        {
            [DisplayName("Customer ID")]
            public int id { get; set; }

            [DisplayName("Customer Name")]
            public string custname { get; set; }

            [DisplayName("Customer Address")]
            public string address { get; set; }

            [DisplayName("Customer Mobile No.")]
            public Nullable<int> mobile { get; set; }

        }
    }
}