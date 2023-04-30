namespace Movye.Domain.Interfaces.DTOs
{
    public abstract class IResponse
    {

        public IResponse() =>
            Errors = new List<string>();

        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public void AddError(IEnumerable<string> errors)
        {
            Errors.AddRange(errors);
            Success = false;
        }
    }
}
