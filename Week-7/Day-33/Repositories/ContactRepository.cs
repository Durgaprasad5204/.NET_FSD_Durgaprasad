using Microsoft.Data.SqlClient;
using WebApplication3.Models;
using Dapper;


namespace WebApplication3.Repositories
{
    public class ContactRepository: IContactRepository
    {
        private readonly string _connStr;

        public ContactRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("ContactConnection");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        public IEnumerable<ContactInfo> GetAll()
        {
            string sqlQuery = @"SELECT c.*, comp.CompanyName, dept.DepartmentName
                                FROM ContactInfo c
                                JOIN Company comp ON c.CompanyId = comp.CompanyId
                                JOIN Department dept ON c.DepartmentId = dept.DepartmentId";

            var db = GetConnection();
            return db.Query<ContactInfo>(sqlQuery);
        }

        public ContactInfo GetById(int id)
        {
            string sqlQuery = @"SELECT c.*, comp.CompanyName, dept.DepartmentName
                                FROM ContactInfo c
                                JOIN Company comp ON c.CompanyId = comp.CompanyId
                                JOIN Department dept ON c.DepartmentId = dept.DepartmentId
                                WHERE ContactId=@Id";

            var db = GetConnection();
            return db.QueryFirstOrDefault<ContactInfo>(sqlQuery, new { Id = id });
        }

        public void Add(ContactInfo contact)
        {
            string sqlQuery = @"INSERT INTO ContactInfo
                                (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
                                VALUES
                                (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";

            var db = GetConnection();
            db.Execute(sqlQuery, contact);
        }

        public void Update(ContactInfo contact)
        {
            string sqlQuery = @"UPDATE ContactInfo
                                SET FirstName=@FirstName,
                                    LastName=@LastName,
                                    EmailId=@EmailId,
                                    MobileNo=@MobileNo,
                                    Designation=@Designation,
                                    CompanyId=@CompanyId,
                                    DepartmentId=@DepartmentId
                                WHERE ContactId=@ContactId";

            var db = GetConnection();
            db.Execute(sqlQuery, contact);
        }

        public void Delete(int id)
        {
            string sqlQuery = "DELETE FROM ContactInfo WHERE ContactId=@Id";
            var db = GetConnection();
            db.Execute(sqlQuery, new { Id = id });
        }

        public IEnumerable<Company> GetCompanies()
        {
            var db = GetConnection();
            return db.Query<Company>("SELECT * FROM Company");
        }

        public IEnumerable<Department> GetDepartments()
        {
            var db = GetConnection();
            return db.Query<Department>("SELECT * FROM Department");
        }
    }
}
