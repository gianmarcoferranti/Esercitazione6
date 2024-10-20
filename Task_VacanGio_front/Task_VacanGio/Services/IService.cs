namespace Task_VacanGio.Services
{
    public interface IService<T>
    {
        List<T> Lista();

        T? Cerca(string varCod);
    }
}
