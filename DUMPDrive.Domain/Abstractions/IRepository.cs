namespace DUMPDrive.Domain.Abstractions;

public interface IRepository<T>
{
    T? GetById(int id);
    List<T> GetAll();
    void Add(T entity);
    void Remove(int id);
}
