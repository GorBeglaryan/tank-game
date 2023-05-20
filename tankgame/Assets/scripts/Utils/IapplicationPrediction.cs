namespace Utils
{
    public interface IApplicationPrediction<T>
    {
        bool CheckReturnedRequest(T t);
    }
}