using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MilitaryClock
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaring variables
            string userInput;
            string menuChoice;
            int startHour = 0;
            int startMinute = 0;
            int startSecond = 0;
            bool isValid = false;
            bool badTime = true;

            //Menu and user input section
            do
            {   //Menu choices
                Console.WriteLine("1. Pick your own starting time.");
                Console.WriteLine("2. Start at 00:00:00");
                Console.WriteLine("3. Start from current time");
                menuChoice = Console.ReadLine();

                //Menu choice 1
                if (menuChoice == "1")
                {
                    //Asking for valid hour
                    do
                    {
                        Console.WriteLine("Please enter the starting hour.");
                        userInput = Console.ReadLine();
                        isValid = int.TryParse(userInput, out startHour);
                        if (isValid && startHour <= 23 && startHour >= 0)
                        {
                            badTime = false;
                        }
                        else
                        {
                            badTime = true;
                            Console.WriteLine("please enter a valid hour from 0 to 23");
                        }
                    } while (badTime);

                    //Asking for valid minute
                    do
                    {
                        Console.WriteLine("Please enter the starting minute.");
                        userInput = Console.ReadLine();
                        isValid = int.TryParse(userInput, out startMinute);
                        if (isValid && startMinute <= 59 && startMinute >= 0)
                        {
                            badTime = false;
                        }
                        else
                        {
                            badTime = true;
                            Console.WriteLine("please enter a valid minute from 0 to 59");
                        }
                    } while (badTime);

                    //Asking for valid second
                    do
                    {
                        Console.WriteLine("Please enter the starting second.");
                        userInput = Console.ReadLine();
                        isValid = int.TryParse(userInput, out startSecond);
                        if (isValid && startSecond <= 59 && startSecond >= 0)
                        {
                            badTime = false;
                        }
                        else
                        {
                            badTime = true;
                            Console.WriteLine("please enter a valid second from 0 to 59");
                        }
                    } while (badTime);
                }

                //Menu choice 3
                else if (menuChoice == "3")
                {
                    //Assigning current time
                    startHour = DateTime.Now.TimeOfDay.Hours;
                    startMinute = DateTime.Now.TimeOfDay.Minutes;
                    startSecond = DateTime.Now.TimeOfDay.Seconds;

                    isValid = true;
                }

                //Error Handler
                else if (menuChoice != "2")
                {
                    Console.WriteLine("invalid menu choice!  Please select a valid option. ");
                    isValid = false;
                }
            } while (!isValid);

            //Wrap around loop
            do
            {
                //Hour for loop
                for (int hour = startHour; hour <= 23; hour++)
                {
                    //Minute for loop
                    for (int minute = startMinute; minute <= 59; minute++)
                    {
                        //Second for loop
                        for (int second = startSecond; second <= 59; second++)
                        {
                            //Clear screen & output time
                            Console.Clear();
                            Console.WriteLine("{0:00}:{1:00}:{2:00}", hour, minute, second);

                            //Delay process for one second
                            Thread.Sleep(1000);
                        }
                    }
                }
            } while (true);
        }
    }
}
