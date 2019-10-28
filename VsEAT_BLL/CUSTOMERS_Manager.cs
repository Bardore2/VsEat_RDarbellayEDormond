using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace DTO
{
    public class CUSTOMERS_Manager : I_CUSTOMERS_Manager
    {
        public I_CUSTOMERS_DB CUSTOMERS_DB { get; }
        public IConfiguration Configuration { get; set; }

        public CUSTOMERS_Manager(IConfiguration configuration)
        {
            CUSTOMERS_DB = new CUSTOMERS_DB(configuration);
            Configuration = configuration;
        }

        public int createNewCustomer(string[] stab)
        {
            CITIES_Manager cm = new CITIES_Manager(Configuration);
            string[] citiesTab = new string[2] { stab[4], stab[5] };
            int citiesId = cm.getCitiesId(citiesTab);

            if (citiesId == 0)
                citiesId = cm.createNewCities(citiesTab);

            string login = $"{stab[0].ToLower().Substring(0, 1)}.{stab[1].ToLower()}";
            if (CUSTOMERS_DB.CheckExistingCUSTOMERS(login) == 0)
                return 0;

            CUSTOMERS customers = new CUSTOMERS();
            customers.FirstName = stab[0];
            customers.LastName = stab[1];
            customers.Phone_Number = stab[2];
            customers.Address = stab[3];
            customers.Login = login;
            customers.Password = "password";
            customers.Fk_Id_Cities = citiesId;

            return (CUSTOMERS_DB.AddCUSTOMERS(customers)).Id;
        }

        public int checkCustomerLogin(string[] stab)
        {
            CUSTOMERS customers = CUSTOMERS_DB.GetCUSTOMERS(stab[0]);

            if (stab[1].Equals(customers.Password))
                return customers.Id;

            return 0;
        }
    }

}
