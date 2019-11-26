using System;
using System.IO;

namespace YTOPC9_left_to_do_StefanGC
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                Menu menu = new Menu();
                menu.addExempleTask();  //Some sample tasks are added
                menu.showMenu();
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}
