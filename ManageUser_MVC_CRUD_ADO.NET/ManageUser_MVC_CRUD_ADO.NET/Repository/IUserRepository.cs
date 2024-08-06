using ManageUser_MVC_CRUD_ADO.NET.Models;

namespace ManageUser_MVC_CRUD_ADO.NET.Repository
{
    public interface IUserRepository
    {
        public bool AddUser(User obj);
        public bool UpdateUser(User obj);
        public bool DeleteUser(int id);
        public User GetUserById(int id);
        public List<User> GetAllUsers();
    }
}
