using EntityLayer;
using Microsoft.Data.SqlClient;
using UtilityProj;
using ExceptionLib;
namespace DAOLibrary
{

    
    public interface IEmpServiceRepo
    {
        
        public bool InsertEmpData(EmpEntity emp);
        public bool UpdateEmpData(int empid,EmpEntity emp);

        public bool DeleteEmp(int p_empid);

        public EmpEntity FindEmployee(int empid);

        public List<EmpEntity> GetAllEmps();


    }
    public class EmpRepoService : IEmpServiceRepo
    {
        public List<EmpEntity> GetAllEmps() {

            string cnstr = DBPropertyUtil.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            
            SqlCommand cmd = new SqlCommand("Select * from emp", cn);
            cn.Open();
            SqlDataReader dr=cmd.ExecuteReader();
            List<EmpEntity> emplist=new List<EmpEntity>();
            while (dr.Read())
            {
                EmpEntity emp=new EmpEntity();
                emp.Empno = Convert.ToInt32(dr["Empno"]);
                emp.Empname = dr["Ename"].ToString();
                emp.Salary = Convert.ToInt32(dr["Sal"]);
                emp.Deptno = Convert.ToInt32(dr["Deptno"]);
                emplist.Add(emp);   

            }
            cn.Close();
            return emplist; 
        }

        public bool DeleteEmp(int p_empid)
        {
            bool status = false;
            status = DeleteEmpRecord(p_empid, status);
            return status;

        }

        private static bool DeleteEmpRecord(int p_empid, bool status)
        {
            
            string cnstr = Utilitycn.ReturnCn("DefaultConnection");
            SqlConnection cn = new SqlConnection(cnstr);
            try
            {

                SqlCommand cmd = new SqlCommand("delete from emp where empno=" + p_empid, cn);
                cn.Open();
                int cnt = cmd.ExecuteNonQuery();
                if (cnt > 0)
                {
                    status = true;
                }

                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
                cn.Dispose();

            }
        }

        public EmpEntity FindEmployee(int empid)
        {
            try
            {
                return SearchEmployeeByID(empid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        private static EmpEntity SearchEmployeeByID(int empid)
        {
           string cnstr= Utilitycn.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand("select * from emp where empno=" + empid, cn);
            cn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            EmpEntity empfound = new EmpEntity();
            if (dr.HasRows) 
            {
                dr.Read();//readonly forward only
                empfound.Empno = Convert.ToInt32(dr["Empno"]);
                empfound.Empname = dr["Ename"].ToString();
                empfound.Salary = Convert.ToInt32(dr["Sal"]);
                empfound.Deptno = Convert.ToInt32(dr["Deptno"]);
            }
            else
            {
                throw new EmployeeNotFoundException("Such a employeeid doesnot exists......");
            }
            cn.Close();
            cn.Dispose();
            return empfound;
        }

        public bool InsertEmpData(EmpEntity emp)
        {
            bool status = false;

            return InsertEmpRecord(emp, out status);

        }

        private static bool InsertEmpRecord(EmpEntity emp, out bool status)
        {
            string cnstr = Utilitycn.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand("insert into emp values(@ename,@sal,@deptno)", cn);
            cmd.Parameters.AddWithValue("@ename", emp.Empname);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@deptno", emp.Deptno);
            cn.Open();
            int cnt = cmd.ExecuteNonQuery();
            if (cnt > 0)
            {
                status = true;
            }
            else
            {
                status = false;
            }


            cn.Close();
            return status;
        }

        public bool UpdateEmpData(int empid, EmpEntity emp)
        {
            bool status=false;
            string cnstr = Utilitycn.ReturnCn("dbCn");
            SqlConnection cn = new SqlConnection(cnstr);
            SqlCommand cmd = new SqlCommand("update emp set Ename=@ename,Sal=@sal,Deptno=@deptno where Empno=" + empid, cn);
            cn.Open();
            cmd.Parameters.AddWithValue("@ename", emp.Empname);
            cmd.Parameters.AddWithValue("@sal", emp.Salary);
            cmd.Parameters.AddWithValue("@deptno", emp.Deptno);
            int cnt=cmd.ExecuteNonQuery();
            if (cnt > 0) {
            status = true;
            }
            else
            {
                status=false;   
            }
            cn.Close();
            return status;
        }
    }
}
