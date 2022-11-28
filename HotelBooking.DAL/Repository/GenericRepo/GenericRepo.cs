

namespace HotelBooking.DAL;

public class GenericRepo<T>:IGenericRepo<T> where T : class
{
    private readonly HB_Context _context;
    public GenericRepo(HB_Context context)
    {
        _context = context;
    }
    public void Add(T entity)
    {
        _context.Set<T>().Add(entity);
    }

    public void Delete(T entity)
    {
        _context.Set<T>().Remove(entity);
    }

    public List<T> GetAll()
    {
        return _context.Set<T>().ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public void SaveChanges()
    {
        _context.SaveChanges();
    }

    public void Update(T entity)
    {
        //as entity framwork tracking the entity we don't need to write any logic
    }
}
