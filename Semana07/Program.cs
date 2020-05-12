using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semana07
{
    class Program
    {
        public static DataClasses1DataContext context = new DataClasses1DataContext();


        static void Main(string[] args)
        {
           Grouping2Lmabda();
            Console.Read();
        }
        static void IntroToLINQ()
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };

            var numQuery =
                from num in numbers
                where (num % 2) == 0
                select num;

            foreach (int num in numQuery)
            {
                Console.Write("{0,1}", num);
            }
        }
        //Ejemplo 1 lambda
        static void IntroToLINQLAMBDA()
        {
            int[] numbers = new int[7] { 0, 1, 2, 3, 4, 5, 6 };
            var ParesLambda = numbers.Where(num => num % 2 == 0).ToArray();


             foreach (int num in ParesLambda)
            {
                Console.Write("{0,1}", num);
            }
        }

        static void DataSource()
        {
            var queryAllCustomers = from cust in context.clientes
                                    select cust;

            foreach(var item in queryAllCustomers)
            {
                Console.WriteLine(item.NombreCompañia);
            }

        }
        //Ejemplo 2 lambda
        static void DataSourcelambda()
        {
            var queryAllCustomersLam = context.clientes.ToList();

                 foreach (var item in queryAllCustomersLam)
            {
                Console.WriteLine(item.NombreCompañia);
            }
        }

        static void Filtering()
        {
            var queryLondonCustomers = from cust in context.clientes
                                       where cust.Ciudad == "Londres"
                                       select cust;
            foreach(var item in queryLondonCustomers)
            {
                Console.WriteLine(item.Ciudad);
            }
        }
        // Ejemplo 3 Lambda
        static void FilteringLambda()
        {
            var queryLondonCustomers = context.clientes.Where(cust => cust.Ciudad== "Londres").ToList();
            foreach (var item in queryLondonCustomers)
            {
                Console.WriteLine(item.Ciudad);
            }
        }

        static void Ordering()
        {
            var queryLondonCustomers3 = from cust in context.clientes
                                        where cust.Ciudad == "Londres"
                                        orderby cust.NombreCompañia ascending
                                        select cust;
            foreach (var item in queryLondonCustomers3)
            {

                Console.WriteLine(item.NombreCompañia);
            }
        }
        //Ejemplo 4 Lambda
        static void OrderingLambda()
        {
            var queryLondonCustomers3 = context.clientes.Where(cust => cust.Ciudad == "Londre")
                                        .OrderBy(cust => cust.NombreCompañia);
            foreach (var item in queryLondonCustomers3)
            {

                Console.WriteLine(item.NombreCompañia);
            }
        }


        static void Grouping()
        {
            var queryCustomersByCity = from cust in context.clientes
                                        group cust by cust.Ciudad;

            foreach (var customerGroup in queryCustomersByCity)
            {
                Console.WriteLine(customerGroup.Key);

                foreach (clientes customer in customerGroup)
                {
                    Console.WriteLine(" {0}", customer.NombreCompañia);
                }
            }
        }
        //ejemplo 5 lambda
        static void GroupingLmabda()
        {
            var queryCustomersByCity = context.clientes.GroupBy(cust => cust.Ciudad);

            foreach (var customerGroup in queryCustomersByCity)
            {
                Console.WriteLine(customerGroup.Key);

                foreach (clientes customer in customerGroup)
                {
                    Console.WriteLine(" {0}", customer.NombreCompañia);
                }
            }
        }

        static void Grouping2()
        {
            var custQuery = from cust in context.clientes
                            group cust by cust.Ciudad into custGroup
                            where custGroup.Count() > 2
                            orderby custGroup.Key
                            select custGroup;

            foreach (var item in custQuery)
            {
                Console.WriteLine(item.Key);
            }
        }
        //Ejemplo 6 lambda
        static void Grouping2Lmabda()
        {
            var custQuery = context.clientes.GroupBy(cust => cust.Ciudad)
                .Where(custGroup => custGroup.Count() > 2)
                .OrderBy(custGroup=>custGroup.Key);

            foreach (var item in custQuery)
            {
                Console.WriteLine(item.Key);
            }
        }

        static void Joining()
        {
            var innerJoinQuery = from cust in context.clientes
                                join dist in context.Pedidos on cust.idCliente equals dist.IdCliente
                                select new { CustomerName = cust.NombreCompañia, DistributorName = dist.PaisDestinatario };

            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine(item.CustomerName);
            }
        }
        //Ejempplo 7 lambda
        static void JoiningLambda()
        {
            var innerJoinQuery = context.clientes
                .Join(context.Pedidos, cust => cust.idCliente, dist => dist.IdCliente, (a, b) => new {a.NombreCompañia,b.PaisDestinatario});

            foreach (var item in innerJoinQuery)
            {
                Console.WriteLine($"Nombre : {item.NombreCompañia} y destinatario: {item.PaisDestinatario}");
            }
        }
    }


}
