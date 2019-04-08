namespace BillsPaymentSystem.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BillsPaymentSystem.App.Core;
    using BillsPaymentSystem.App.Core.Contracts;
    using BillsPaymentSystem.Data;
    using BillsPaymentSystem.Models;
    using Microsoft.EntityFrameworkCore;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            using(BillsPaymentSystemContext db = new BillsPaymentSystemContext())
            {
                var pm = db.PaymentMethods.FirstOrDefault();
                db.Entry(pm).Reference(p => p.User).Load();
                ;
            }


            //InitializeSeedData();

            //ICommandInterpreter commandInterpreter = new CommandInterpreter();
            //IEngine engine = new Engine(commandInterpreter);
            //engine.Run();
        }

        private static void InitializeSeedData()
        {
            DbInitializer dbInitializer = new DbInitializer();

            using (BillsPaymentSystemContext context = new BillsPaymentSystemContext())
            {
                dbInitializer.Seed(context);
            }
        }
    }
}
