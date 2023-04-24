using System;
using bocadillos.Decorators;
using bocadillos.Bases;
using bocadillos.UI;
using bocadillos.DB;
using System.Collections;
using bocadillos.Controllers;

namespace bocadillos;

class Program
{
    static void Main()
    {

        /// RUN TO SET UP DATABASE
        /// comment out after first run
        //DbConnect.DropDataBase();
        DbConnect.CreateDb();
        ToppingDAO.AddToppingsToDatabase();
        
        
        
        InputOutputManager iomanager = new ();
        iomanager.Run();
    }

}

