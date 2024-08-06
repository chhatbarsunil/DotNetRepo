using ManageUser_MVC_CRUD_ADO.NET.Models;
using System.Data;
using System.Data.SqlClient;

namespace ManageUser_MVC_CRUD_ADO.NET.Repository
{
    public class UserRepository:IUserRepository
    {
        private SqlConnection con;
        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private readonly IConfiguration _configuration;

        //To Handle connection related activities    
        private void connection()
        {
            string constr = _configuration.GetConnectionString("Default");
            con = new SqlConnection(constr);

        }
        //To Add User details    
        public bool AddUser(User obj)
        {

            connection();
            SqlCommand com = new SqlCommand("AddNewUser", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Mobile", obj.Mobile);
            com.Parameters.AddWithValue("@Age", obj.Age);
            com.Parameters.AddWithValue("@Address", obj.Address);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;

            }
            else
            {

                return false;
            }


        }
        //To view user details with generic list     
        public List<User> GetAllUsers()
        {
            connection();
            List<User> UserList = new List<User>();


            SqlCommand com = new SqlCommand("spGetAllUsers", con);
            com.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();

            con.Open();
            da.Fill(dt);
            con.Close();
            
            foreach (DataRow dr in dt.Rows)
            {

                UserList.Add(

                    new User
                    {

                        UserID = Convert.ToInt32(dr["UserId"]),
                        Name = Convert.ToString(dr["Name"]),
                        Mobile = Convert.ToString(dr["Mobile"]),
                        Age = Convert.ToInt32(dr["Age"]),
                        Address = Convert.ToString(dr["Address"])

                    }
                    );
            }

            return UserList;
        }
        //To Update User details
        //

        //Get : Get User by Id
        public User GetUserById(int id)
        {

            connection();
            User user = new();
            var sql = "Select * from [User] where UserID=" + id;
          
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        user.UserID = reader.GetInt32(reader.GetOrdinal("UserID"));
                        user.Name = reader.GetString(reader.GetOrdinal("Name"));
                        user.Mobile = reader.GetString(reader.GetOrdinal("Mobile"));
                        user.Age = reader.GetInt32(reader.GetOrdinal("Age"));
                        user.Address = reader.GetString(reader.GetOrdinal("Address"));
                        // ... populate other user properties based on column names
                    }
                }
            }

            return user;
        }
        public bool UpdateUser(User obj)
        {

            connection();
            SqlCommand com = new SqlCommand("UpdateUserDetails", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserID", obj.UserID);
            com.Parameters.AddWithValue("@Name", obj.Name);
            com.Parameters.AddWithValue("@Mobile", obj.Mobile);
            com.Parameters.AddWithValue("@Age", obj.Age);
            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {

                return true;
            }
            else
            {
                return false;
            }
        }
        //To delete User details    
        public bool DeleteUser(int Id)
        {

            connection();
            SqlCommand com = new SqlCommand("DeleteUserById", con);

            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserID", Id);

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
            {
                return true;
            }
            else
            {

                return false;
            }
        }
    }
}