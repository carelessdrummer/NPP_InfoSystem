namespace NPP_InfoSystem.CCL.Security
{
    // Базовий клас користувача
    public abstract class NppUser
    {
        public int Id { get; }
        public string Name { get; }
        public string UserType { get; protected set; } = string.Empty;

        protected NppUser(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }

    // Дочірні класи ролей
    public class Admin : NppUser
    {
        public Admin(int id, string name) : base(id, name)
        {
            UserType = "Admin";
        }
    }

    public class Engineer : NppUser
    {
        public Engineer(int id, string name) : base(id, name)
        {
            UserType = "Engineer";
        }
    }
}