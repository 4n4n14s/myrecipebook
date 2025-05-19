namespace MyRecipeBook.Exceptions.ExceptionsBase
{
    public class ErrorOnValidationException(IList<string> errorMesseges) : MyRecipeBookExceptions
    {
        public IList<string> ErrorMesseges { get; set; } = errorMesseges;
    }
    
    
}
