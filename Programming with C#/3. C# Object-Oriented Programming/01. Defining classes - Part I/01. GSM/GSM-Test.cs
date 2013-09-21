/*
* 7. Write a class GSMTest to test the GSM class:
* Create an array of few instances of the GSM class.
* Display the information about the GSMs in the array.
* Display the information about the static property IPhone4S.
*/

using System;
using System.Collections.Generic;

namespace MobilePhone.Test
{
    class GSM_Test
    {
        public static void TestRunner()
        {
            // Create a few instances of the GSM class
            List<GSM> mobilePhones = new List<GSM>();

            // Mobile N.1
            {
                mobilePhones.Add(new GSM("Asha 501", "Nokia", "GLOBUL", 599.99m, new Display(3, 1250000)));
            }

            // Mobile N.2
            {
                GSM mobile = new GSM("Xperia ray", "Sony Ericsson");
                mobile.Owner = "Vivacom";
                mobile.Price = 250;

                mobile.Battery = new Battery(Battery.Type.NiMH);
                mobile.Battery.HoursTalk = 200;

                mobilePhones.Add(mobile);
            }

            // Display information about phones in array
            foreach (var phone in mobilePhones)
                Console.Write(phone);

            // Mobile N.3
            // Display information about IPhone 4S
            Console.Write(GSM.Iphone4S);
        }
    }
}