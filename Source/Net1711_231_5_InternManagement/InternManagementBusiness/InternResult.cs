namespace InternManagementBusiness
{
    public interface IInternManagementResult
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
    }
    public class InternResult :IInternManagementResult
    {
        public int Status { get; set; }
        public string? Message { get; set; }
        public object? Data { get; set; }
        public InternResult() {
            Status = -1;
            Message = "Action fall";
        }
        public InternResult(int status, string message)
        {
            Status = status;
            Message = message;
        }
        public InternResult(int status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }
    }
}
