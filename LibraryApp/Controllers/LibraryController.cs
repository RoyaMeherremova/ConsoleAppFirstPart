using DomainLayer.Models;
using ServiceLayer.Helpers;
using ServiceLayer.Services;
using ServiceLayer.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Controllers
{
    public  class LibraryController
    {
        private readonly ILibraryService _libraryService;
        public LibraryController()
        {
            _libraryService = new LibraryService();
        }
        public void Create()
        {
           ConsoleColor.Cyan.WriteConsole("Please add library name:");
           LibraryName: string libraryName=Console.ReadLine();

           ConsoleColor.Cyan.WriteConsole("Please add library seatcount:");
           SeatCount: string seatCountStr=Console.ReadLine();

            int seatCount;

            bool IsCorrectSeatCount=int.TryParse(seatCountStr, out seatCount);

            if (IsCorrectSeatCount)
            {
                try
                {
                    Library library = new Library
                    {
                        Name = libraryName,
                        SeatCount = seatCount
                    };

                    var response = _libraryService.Create(library);
                    ConsoleColor.Green.WriteConsole($"{library.Id} {library.Name} {library.SeatCount}");
                }
                catch (Exception ex)
                {

                    ConsoleColor.Red.WriteConsole(ex.Message+"/"+"Please try again");
                    goto LibraryName;
                }
               
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Please add correct format seat count");
                goto SeatCount;
            }
           



        }
    }
}
