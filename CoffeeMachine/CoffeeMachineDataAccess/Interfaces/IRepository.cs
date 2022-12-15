namespace CoffeeMachineDataAccess.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
    }
}
