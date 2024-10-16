using EntityLayer;
using HelperLib;
using System.IO.Pipes;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
EmpEntity emp = new EmpEntity();
EmpHelper emphelp = new EmpHelper();
char ans = 'N';
do
{
    Console.WriteLine("1.Insert 2.Update 3.Delete 4.Find 5.ShowAll records 6.Exit");
    int ch = Convert.ToInt32(Console.ReadLine());
    bool status = false;
    switch (ch)
    {
        case 1:
            Console.WriteLine("Enter Empname");
            emp.Empname = Console.ReadLine();
            Console.WriteLine("Etner salary");
            emp.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter deptno");
            emp.Deptno = Convert.ToInt32(Console.ReadLine());
            status = emphelp.AddEmp(emp);
            if (status)
            {

                Console.WriteLine("Added successfully....");
            }
            else
            {
                Console.WriteLine("Check code....");
            }
            break;
        case 2:
            Console.WriteLine("Enter empid to update");
            emp.Empno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Empname");
            emp.Empname = Console.ReadLine();
            Console.WriteLine("Etner salary");
            emp.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter deptno");
            emp.Deptno = Convert.ToInt32(Console.ReadLine());
            status = emphelp.EditEmp(emp.Empno, emp);
            if (status)
            {

                Console.WriteLine("Updated successfully....");
            }
            else
            {
                Console.WriteLine("Check code....");
            }




            break;
        case 3:
            Console.WriteLine("Enter empid to Delete");
            int empid = Convert.ToInt32(Console.ReadLine());
            status = emphelp.RemoveEmpFromDB(empid);
            if (status)
            {

                Console.WriteLine("Deleted successfully....");
            }
            else
            {
                Console.WriteLine("Check code....");
            }
            break;
        case 4:
            try
            {
                Console.WriteLine("Enter empid to Find");
                empid = Convert.ToInt32(Console.ReadLine());

                emp = emphelp.GetEmpByID(empid);
                Console.WriteLine(emp.Empno);
                Console.WriteLine(emp.Empname);
                Console.WriteLine(emp.Salary);
                Console.WriteLine(emp.Deptno);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);

            }

            break;
        case 5:
            List<EmpEntity> emplist = new List<EmpEntity>();
            emplist = emphelp.showEmplist();
            foreach (var item in emplist)
            {
                Console.WriteLine(item.Empno + "|" + item.Empname + "|" + item.Salary + "|" + item.Deptno);
                Console.WriteLine();
            }
            break;

        case 6:
            Environment.Exit(1);
            break;
    }
    Console.WriteLine("Do u want to contiue Y/N");
    ans = Convert.ToChar(Console.ReadLine());
}
while (ans == 'Y');

    {

}
Console.ReadKey();