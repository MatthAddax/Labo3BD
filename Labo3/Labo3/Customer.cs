using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbCustomersLibrary
{
    public class Customer
    {
        private double _accountBalance;

        public double AccountBalance
        {
            get { return _accountBalance; }
            set { _accountBalance = value; }
        }

        private string _addressLine1;

        public string AddressLine1
        {
            get { return _addressLine1; }
            set { _addressLine1 = value; }
        }
        private string _addressLine2;

        public string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }
        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _country;

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private long _id;

        public long Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _postcode;

        public string Postcode
        {
            get { return _postcode; }
            set { _postcode = value; }
        }
        private string _remark;

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        [Timestamp]
        public byte[] RowVersion { get; set; }

    }
}
