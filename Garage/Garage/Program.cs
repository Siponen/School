﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage
{
    class Program
    {
        static void Main(string[] args)
        {
            GarageHandler garageHandler = new GarageHandler("DoTA2",100);
            GarageUI ui = new GarageUI(garageHandler);
            bool isDone = false;

            while (!isDone)
            {
                Console.Clear();
                ui.MainMenu();

                if (ui.IsDone) break;
                Commons.PressKeyToContinue();
            }
        }
    }
}
