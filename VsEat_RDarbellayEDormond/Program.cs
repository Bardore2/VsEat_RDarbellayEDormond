using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace VsEat_RDarbellayEDormond
{
    class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

        static void Main(string[] args)
        {
            int orderNumber;
            int deliveryNumber;
            int courierNumber;
            int restaurantNumber;
            int customerNumber = 0;

            Console.WriteLine("Choose what to do : [Enter O to place an order, D to delete an existing order, L to access the deliveries OR 'quit']");
            string s = Console.ReadLine();
            while (!s.Equals("quit"))
            {
                if (s.Equals("O"))
                {
                    Console.WriteLine("ENVIRONEMENT => PASS AN ORDER");
                    Console.WriteLine("Use existing account (Y/N) : ");
                    s = Console.ReadLine();
                    if (s.Equals("Y"))
                    {
                        Console.WriteLine("Enter login and password : [Login, Password]");
                        s = Console.ReadLine();
                        string[] stab = s.Split(", ");
                        CUSTOMERS_Manager cm = new CUSTOMERS_Manager(Configuration);
                        customerNumber = cm.checkCustomerLogin(stab);
                        for (int y = 0; y < stab.Length; y++)
                            Console.WriteLine("\tVous avez tapez : " + stab[y]);
                    }
                    else if (s.Equals("N"))
                    {
                        Console.WriteLine("Create an account : [FirstName, LastName, PhoneNumber, Address, NPA, Cities]");
                        s = Console.ReadLine();
                        string[] stab = s.Split(", ");
                        CUSTOMERS_Manager cm = new CUSTOMERS_Manager(Configuration);
                        customerNumber = cm.createNewCustomer(stab);
                        for (int j = 0; j < stab.Length; j++)
                            Console.WriteLine("\tVous avez tapez : " + stab[j]);
                    }
                    Console.WriteLine("YOU'RE CONNECTED WITH CUSTOMER ACCOUNT N° "+ customerNumber);

                    Console.WriteLine("WOULD YOU ORDER SOME FOOD (Y/N) => ");
                    s = Console.ReadLine();
                    if (s.Equals("Y"))
                    {
                        Console.WriteLine("\tVous avez tapez : " + s);
                        ORDERS_Manager om = new ORDERS_Manager(Configuration);
                        orderNumber = om.createNewOrders(customerNumber);

                        Console.WriteLine("DISPLAY RESTAURANTS => ");
                        RESTAURANTS_Manager rm = new RESTAURANTS_Manager(Configuration);
                        List<RESTAURANTS> restaurants = rm.displayRestaurants();
                        foreach (RESTAURANTS r in restaurants)
                            Console.WriteLine(r);

                        Console.WriteLine("Enter choosen restaurants : [Id]");
                        restaurantNumber = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\tVous avez tapez : " + restaurantNumber);
                        Console.WriteLine("DISPLAY DISHES => ");
                        DISHES_Manager dm = new DISHES_Manager(Configuration);
                        List<DISHES> dishes = dm.displayDishesForRestaurant(restaurantNumber);
                        foreach (DISHES d in dishes)
                            Console.WriteLine(d);

                        Console.WriteLine("Enter choosen dishes : [Id, Quantity]");
                        while (true)
                        {
                            s = Console.ReadLine();
                            if (s.Equals("stop"))
                                break;
                            string[] stab = s.Split(", ");
                            int id1 = Convert.ToInt32(stab[0]);
                            int id2 = Convert.ToInt32(stab[1]);
                            ORDERS_DISHES_Manager odm = new ORDERS_DISHES_Manager(Configuration);
                            odm.createNewOrdersDishes(stab, orderNumber);
                            Console.WriteLine("\tVous avez tapez : " + id1 + " et " + id2);
                        }

                        DELIVERY_Manager dem = new DELIVERY_Manager(Configuration);
                        deliveryNumber = (om.addNewDelivery(orderNumber)).Fk_Id_Delivery;

                        Console.WriteLine("DISPLAY DELIVERY TIME => ");
                        DELIVERY_TIME_Manager dtm = new DELIVERY_TIME_Manager(Configuration);
                        List<DELIVERY_TIME> delivery_times = dtm.displayDeliveryTime();
                        foreach (DELIVERY_TIME dt in delivery_times)
                            Console.WriteLine(dt);

                        Console.WriteLine("Enter choosen delivery time : [Id]");
                        int z = Convert.ToInt32(Console.ReadLine());
                        dem.updateDeliveryTime(deliveryNumber, z);
                        Console.WriteLine("\tVous avez tapez : " + z);

                        Console.WriteLine("DISPLAY SERVICE CLASS => ");
                        SERVICE_CLASS_Manager scm = new SERVICE_CLASS_Manager(Configuration);
                        List<SERVICE_CLASS> service_classes = scm.displayServiceClass();
                        foreach (SERVICE_CLASS sc in service_classes)
                            Console.WriteLine(sc);

                        Console.WriteLine("Enter choosen service class : [Id]");
                        int u = Convert.ToInt32(Console.ReadLine());
                        dem.updateServiceClass(deliveryNumber, u);
                        Console.WriteLine("\tVous avez tapez : " + u);

                        om.addNewBills(orderNumber);

                        Console.WriteLine("DISPLAY BILLS => ");
                        BILLS_Manager bm = new BILLS_Manager(Configuration);
                        Console.WriteLine(bm.displayBills(orderNumber));

                        Console.WriteLine("PLEASE CONFIRM ORDER (Y/N) => ");
                        s = Console.ReadLine();
                        if (s.Equals("Y"))
                        {
                            om.confirmOrders(orderNumber);
                        }
                        else
                        {
                            om.cancelOrders(orderNumber);
                        }
                        Console.WriteLine("\tVous avez tapez : " + s);

                        dem.assignCourier(deliveryNumber, restaurantNumber);
                        Console.WriteLine("YOUR ORDER HAS BEEN ASSIGNED => ");

                    }
                }
                else if (s.Equals("D"))
                {
                    Console.WriteLine("ENVIRONEMENT => DELETE AN ORDER");
                    Console.WriteLine("Enter login and password : [Login, Password]");
                    s = Console.ReadLine();
                    string[] stab = s.Split(", ");
                    CUSTOMERS_Manager cm = new CUSTOMERS_Manager(Configuration);
                    customerNumber = cm.checkCustomerLogin(stab);
                    for (int y = 0; y < stab.Length; y++)
                        Console.WriteLine("\tVous avez tapez : " + stab[y]);

                    Console.WriteLine("DISPLAY ORDERS => ");
                    ORDERS_Manager om = new ORDERS_Manager(Configuration);
                    List<ORDERS> orders = om.displayOrders(customerNumber);
                    foreach (ORDERS o in orders)
                        Console.WriteLine(o);

                    Console.WriteLine("Delete an order : [Number, FirstName, LastName]");
                    s = Console.ReadLine();
                    stab = s.Split(", ");
                    om.cancelOrders(stab);
                    for (int j = 0; j < stab.Length; j++)
                        Console.WriteLine("\tVous avez tapez : " + stab[j]);

                    Console.WriteLine("YOUR ORDER HAS BEEN DELETED => ");
                }
                else if (s.Equals("L"))
                {
                    Console.WriteLine("ENVIRONEMENT => LOOK AT DELIVERY");
                    Console.WriteLine("Enter login and password : [Login, Password]");
                    s = Console.ReadLine();
                    string[] stab = s.Split(", ");
                    DELIVERY_COURIER_Manager dcm = new DELIVERY_COURIER_Manager(Configuration);
                    courierNumber = dcm.checkCourierLogin(stab);
                    for (int y = 0; y < stab.Length; y++)
                        Console.WriteLine("\tVous avez tapez : " + stab[y]);

                    Console.WriteLine("DISPLAY DELIVERY => ");
                    DELIVERY_Manager dm = new DELIVERY_Manager(Configuration);
                    List<DELIVERY> deliveries = dm.displayDelivery(courierNumber);
                    foreach (DELIVERY d in deliveries)
                        Console.WriteLine(d);

                    Console.WriteLine("Archive an delivery : [Number]");
                    int id3 = Convert.ToInt32(Console.ReadLine());
                    dm.archiveDelivery(id3);
                    Console.WriteLine("\tVous avez tapez : " + id3);

                    Console.WriteLine("YOUR DELIVERY HAS BEEN ARCHIVED => ");
                }
                Console.WriteLine("Choose what to do : [Enter O to place an order, D to delete an existing order, L to access the deliveries OR 'quit']");
                s = Console.ReadLine();
            }
        }
    }
}

