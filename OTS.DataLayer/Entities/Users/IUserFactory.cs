namespace OTS.DataLayer.Entities.Users
{
    public interface IUserFactory
    {
        User Create(string name, string surname, string email, string login, string password, bool isAdmin);
    }
}