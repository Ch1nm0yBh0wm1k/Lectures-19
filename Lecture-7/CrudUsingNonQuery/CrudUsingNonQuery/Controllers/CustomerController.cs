using CrudUsingNonQuery.Data;
using CrudUsingNonQuery.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace CrudUsingNonQuery.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _dbContext;
        public CustomerController(IConfiguration configuration, ApplicationDbContext dbContext)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Employee> empDetails = new List<Employee>();
            empDetails= _dbContext.Products.ToList();

            Employee e = new Employee();
            e.Name = "Abcd";
            e.Age = 2;

            _dbContext.Products.Update(e);
            _dbContext.SaveChanges();
            
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            List<Customer> cusObj = new List<Customer>();

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "sp_GetCustomer";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                conn.Open();

                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                //adapter.Fill(dt);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cusObj.Add(new Customer
                    {
                        Id = (int)reader["Id"],
                        Name = (string)reader["Name"],
                        Age = (int)reader["Age"]
                    });
                }
            }

            return View(cusObj);
        }

        [HttpPost]
        public IActionResult CreateCustomer(Customer cust, IFormCollection form)
        {
            //string name2 =  Request.Form["Name"];
            //string name3 = form["Name"];
            string connectionString = "Server= localhost;Database=19B1;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Customer (Name, Age) VALUES (@Name, @Age)";
                
                SqlCommand cmd = new SqlCommand(query, conn);

                
                cmd.Parameters.AddWithValue("@Name", cust.Name);
                cmd.Parameters.AddWithValue("@Age", cust.Age);

                conn.Open();
                cmd.ExecuteNonQuery();

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateCustomer(Customer cust)
        {
            string connectionString = "Server= localhost;Database=19B1;Trusted_Connection=True;MultipleActiveResultSets=true";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "update Customer set Name=@Name, Age=@Age where Id = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);


                cmd.Parameters.AddWithValue("@Name", cust.Name);
                cmd.Parameters.AddWithValue("@Age", cust.Age);
                cmd.Parameters.AddWithValue("@Id", cust.Id);

                conn.Open();
                cmd.ExecuteNonQuery();



            }

            return RedirectToAction("Index");
        }
    }
}
