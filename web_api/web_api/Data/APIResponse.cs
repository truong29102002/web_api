namespace web_api.Data
{
    // class chứa các dữ liệu hệ thống phản hồi cho user khi thực hiện đăng nhập

    public class APIResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
