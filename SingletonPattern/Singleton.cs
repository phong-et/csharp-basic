using System;
namespace DesignPattern.SingletonPattern
{
    class Singleton
    {
        private Singleton(){
            Console.WriteLine("a");
        }
        private static Singleton Instance = new Singleton();
        public static Singleton getInstance(){ return Instance;}
    }
    /**
     * src : https://stackoverflow.com/questions/50235133/c-sharp-not-recognizing-sqlconnection-even-when-using-using-system-data-sqlclie 
     * 
        In .NET Core, you need to add a reference to System.Data.SqlClient via NuGet:
        Select Tools | NuGet Package Manager | Manage NuGet Packages for Solution
        Click "Browse"
        Type System.Data.SqlClient and hit return
        Select System.Data.SqlClient by Microsoft
        On the panel on the right, check your project.
        Click Install
        Click OK to the next box that comes up..
     */
}
