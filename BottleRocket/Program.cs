using System;

namespace BottleRocket
{
    class Program
    {
        static void Main(string[] args)
        {
            var romPath = string.Empty;
            var noArgMode = args.Length == 0;
            var debugMode = true;

            if (noArgMode)
            {
                if (debugMode)
                    romPath = @"C:\Users\vincents\Desktop\Git repos\EB0-Text-Tool\Test.nes";
                else
                {
                    Console.WriteLine("Please drag and drop the ROM on this program or pass it in as a command-line argument!");
                    Console.ReadLine();
                    return;
                }
            }

            Console.Title = "BottleRocket";
            Console.Clear();
            Console.Write("Which part of the game do you want to work with?");

            var menuItems = new string[]
            {
                "Script",
                "Item Configuration",
                "Teleport Destinations",
                "Train Destinations",
            };

            for (var i = 0; i < menuItems.Length; i++)
            {
                string menuItem = menuItems[i];
                Console.SetCursorPosition(4, i + 2);
                Console.WriteLine(i.ToString() + ": " + menuItem);
            }

            int input;
            while (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please type a number!");
            }

            Console.Clear();
            Console.WriteLine(" " + menuItems[input]);
            Console.WriteLine("".PadLeft(menuItems[input].Length + 2, '-') + "\n");
            var insertMode = DumpOrInsert();

            switch (input)
            {
                case 0:
                    //Script
                    break;
                case 1:
                    //Item config
                    break;
                case 2:
                    //Teleport destinations
                    break;
                case 3:
                    //Train destinations
                    break;
            }

            if (noArgMode) Console.ReadKey(); //let them read it before the window closes
        }

        private static bool DumpOrInsert()
        {
            Console.WriteLine("Dump or insert data?");

            if (Console.ReadLine().ToLower().StartsWith('d'))
                return false;
            else
                return true;
        }
    }
}
