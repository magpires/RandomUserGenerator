namespace API.ViewModel
{
    public class ResponseViewModel<T>
    {
        public int StatusCode { get; private set; }
        public T? Data { get; private set; }
        public bool Sucess { get; private set; }
        public List<string> Errors { get; set; }

        public ResponseViewModel()
        {
            StatusCode = 200;
            Sucess = true;
            Errors = new List<string>();
        }

        public ResponseViewModel(int statusCode, T data)
        {
            StatusCode = statusCode;
            Sucess = true;
            Data = data;
            Errors = new List<string>();
        }
        public ResponseViewModel(int statusCode, List<string> errors)
        {
            StatusCode = statusCode;
            Errors = errors;
        }
    }
}
