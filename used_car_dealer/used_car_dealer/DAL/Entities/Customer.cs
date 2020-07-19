using MySqlConnector;
using System;

namespace used_car_dealer.DAL.Entities
{
    public class Customer
    {

        #region Properties

        public uint? Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public uint HomeNumber { get; set; }
        public string BirthDate { get; set; }

        #endregion

        #region Ctor
        public Customer(MySqlDataReader reader)
        {
            Id = uint.Parse(reader["customer_id"].ToString());
            Name = reader["customer_name"].ToString();
            LastName = reader["customer_last_name"].ToString();
            Pesel = reader["customer_pesel"].ToString();
            PhoneNumber = reader["customer_phone_number"].ToString();
            PostalCode = reader["customer_postal_code"].ToString();
            City = reader["customer_city"].ToString();
            Street = reader["customer_street"].ToString();
            HomeNumber = uint.Parse(reader["customer_home_number"].ToString());
            BirthDate = reader["customer_birth_date"].ToString();
        }

        public Customer(string name, string lastName, string pesel, string phoneNumber, string postalCode,
            string city, string street, uint homeNumber, string birthDate)
        {
            Id = null;
            Name = name.Trim();
            LastName = lastName.Trim();
            Pesel = pesel.Trim();
            PhoneNumber = phoneNumber.Trim();
            PostalCode = postalCode.Trim();
            City = city.Trim();
            Street = street.Trim();
            HomeNumber = homeNumber;
            BirthDate = birthDate;
        }

        public Customer(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            LastName = customer.LastName;
            Pesel = customer.Pesel;
            PhoneNumber = customer.PhoneNumber;
            PostalCode = customer.PostalCode;
            City = customer.City;
            Street = customer.Street;
            HomeNumber = customer.HomeNumber;
            BirthDate = customer.BirthDate;
        }

        #endregion

        #region Methods
        public string ToInsert()
        {
            return $"('{Name}', '{LastName}', '{Pesel}', '{PhoneNumber}', '{PostalCode}', '{City}', '{Street}', {HomeNumber},'{BirthDate}')";
        }


        public override string ToString()
        {
            //return $"{Name} {LastName} z {City}";

            //temporary, check if class is have good params
            return $"{Id} - {Name} {LastName} | {Pesel} |  {BirthDate} | {PhoneNumber} | {PostalCode} " +
                    $"{City}, {Street} {HomeNumber}";
        }
        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            if (customer is null) return false;
            if (Pesel != customer.Pesel) return false;

            return true;
        }
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}
