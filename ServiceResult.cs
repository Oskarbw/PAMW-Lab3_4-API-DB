namespace PAMW3_API
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }

        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

    }
}
