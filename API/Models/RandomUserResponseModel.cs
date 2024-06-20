namespace API.Models
{
    public class RandomUserResponseModel
    {
        public List<ResultModel> Results { get; set; } = new List<ResultModel>();
        public InfoModel Info { get; set; } = new InfoModel();
    }
}
