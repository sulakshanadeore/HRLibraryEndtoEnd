using DAOLibrary;
using EntityLayer;

namespace HelperLib
{
    public class EmpHelper
    {
        EmpRepoService empRepoService = null;
        public EmpHelper()
        {
            
             empRepoService=new EmpRepoService();
        }
        public bool AddEmp(EmpEntity emp)
        { 

        return empRepoService.InsertEmpData(emp);
        
        }

        public bool EditEmp(int empid, EmpEntity emp) 
        {
        return empRepoService.UpdateEmpData(empid, emp);
        
        }

        public List<EmpEntity> showEmplist()
        {

            return empRepoService.GetAllEmps();
        }
            public EmpEntity GetEmpByID(int empid)
        {
            try
            {
                return empRepoService.FindEmployee(empid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            

        }

        public bool RemoveEmpFromDB(int p_empid) 
        {
        
            bool status=empRepoService.DeleteEmp(p_empid);
            return status;
        
        }


    }
}
