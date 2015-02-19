using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace AdminView.ViewModel
{
    public class CouponViewModel
    {
        public static Dictionary<String, String> CouponTypes = new Dictionary<String, String>
        {
            {typeof (BuyProductXRecieveProductY).FullName, "Köp X få Y gratis"},
            {typeof (BuyXProductsPayForYProducts).FullName, "Tag X betala för Y"},
            {typeof (TotalSumAmountDiscount).FullName, "Köp för X:kr få Y:kr rabatt"},
            {typeof (TotalSumPercentageDiscount).FullName, "Köp för X:kr få Y:% rabatt"}
        };

        public void CreateCustomers()
        {
            Customers = new List<Customer>();

            string[] lines = CustomerString.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);


            foreach (string line in lines)
            {
                Customer customer = new Customer();
                //customer.CouponUses = 0;

                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Match match = regex.Match(line);
                if (match.Success)
                {
                    customer.Email = line;
                    Customers.Add(customer);
                }

                else if (true)
                {
                    customer.SocialSecurityNumber = line;
                    Customers.Add(customer);
                }
            }
        }

        public string CustomerString { get; set; }

        public List<Customer> Customers { get; set; }

        public String Type { get; set; }
        public Boolean CanBeCombined { get; set; }
        public Dictionary<String, String> Parameters { get; set; }
    }
}