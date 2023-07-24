namespace BackEndApi.Model
{
    public class ApiResponse
    {
        public bool Success { set; get; }
        public string Message { set; get; }
        public object Data { set; get; }
    }
}
