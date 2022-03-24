using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using System.IO;

namespace WeatherApp.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine($"Welcome to world Weather Information centre.{Environment.NewLine}");
            DisplayWeatherOption();

            string input;
            while (true)
            {
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    DisplayWeatherOption();
                    continue;
                }


                if (int.TryParse(input, out int value))
                {
                    if (value == 1)
                    {
                        Console.WriteLine("Type a country name");
                        var country = Console.ReadLine();

                        if (!string.IsNullOrWhiteSpace(country))
                        {
                            Console.WriteLine("Type a city name");
                            string city = Console.ReadLine();

                            if (!string.IsNullOrWhiteSpace(city))
                            {
                                //make call to get weather condition of a city
                            }
                            else
                            {
                                DisplayWeatherOption();
                                continue;
                            }

                        }
                        else
                        {
                            DisplayWeatherOption();
                            continue;
                        }
                    }
                    else if (value == 2)
                    {
                        Console.WriteLine("Option two selected");
                    }
                    else
                    {
                        DisplaySelectOptionMessage();
                    }
                }
                else
                {
                    DisplaySelectOptionMessage();
                }

                DisplayWeatherOption();
            }


        }

        private static void DisplayWeatherOption()
        {
            Console.WriteLine($"Please select an option below...{Environment.NewLine}1) For real-time weather information.{Environment.NewLine}2) For periodic weather information.\n");
        }

        private static void DisplaySelectOptionMessage()
        {
            Console.WriteLine("Please select an option");
        }
    }
}
