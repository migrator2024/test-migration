using codeBaseFirstDemo.Data;
using codeBaseFirstDemo.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace codeBaseFirstDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ctx = new Empcontext();
            Employee emp = new Employee();
            Customer newcust = new Customer();
            newcust.ID = 1;
            newcust.Name = "Sheela";

            Customer newcust2 = new Customer();
            newcust2.ID = 2;
            newcust2.Name = "subiya";
            //AddOrderToExisting();
            GetAllCustomersWithOrders();

            //List<Order> orders = new List<Order>();



            //Order ord = new Order();
            //ord.Order_ID = 11;
            //ord.Amount = 100;
            //ord.OrderDate = DateTime.Now;
            //orders.Add(ord);
            //newcust.Orders = orders;

            Order ord = new Order();
            ord.Order_ID = 11;
            ord.Amount = 100;
            ord.OrderDate = DateTime.Now;
            ord.cust = newcust;

            Order ord2 = new Order();
            ord.Order_ID = 11;
            ord.Amount = 100;
            ord.OrderDate = DateTime.Now;
            ord.cust = newcust2;



            try
            {
                //ctx.Orders.Add(ord);

                //ctx.ord.Add(ord);
                ctx.cust.Add(newcust2);
                ctx.ord.Add(ord2);


                //ctx.Customers.Add(newcust);
                ctx.SaveChanges();
                Console.WriteLine("Customer and order is created");

            }
            catch (Exception ex)
            {



                Console.WriteLine(ex.Message);
            }
        }

        public static void AddOrderToExisting()
        {
            var ctx = new Empcontext();
            Order ord = new Order();
            ord.Order_ID = 22;
            ord.Amount = 300;
            ord.OrderDate = DateTime.Now;



            try
            {
                Customer existingcust = ctx.cust.Where(x => x.ID == 2).SingleOrDefault();
                ord.cust = existingcust;
                ctx.ord.Add(ord);
                ctx.SaveChanges();
                Console.WriteLine("Order is created for existing customer");
            }
            catch (Exception ex)
            {



                Console.WriteLine(ex.Message);

            }
        }

        public static void GetAllCustomersWithOrders()
        {
            var ctx = new Empcontext();
            try
            {
                //var customers = ctx.Customers.Include("Orders");
                var customers = ctx.cust.Include(o => o.Orders);




                foreach (var item in customers)
                {
                    Console.WriteLine(item.Name);
                    Console.WriteLine("----->");


                    foreach (var item1 in item.Orders)
                    {
                        Console.WriteLine(item1.Amount.ToString());
                    }
                    Console.WriteLine("-----");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}


