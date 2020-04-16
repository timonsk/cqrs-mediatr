namespace CQRS.MediatR.Models.ResponseModels.Commands
{
    public class CreateCategoryResponseModel
    {
        public bool IsSuccessful
        {
            get { return string.IsNullOrEmpty(ErrorMessage); }
        }

        public string ErrorMessage { get; set; }
    }
}
