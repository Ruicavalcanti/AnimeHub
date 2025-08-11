namespace AnimeHub.Domain.Validation
{
    public class DomainValidation : Exception
    {
        public DomainValidation(string error) : base(error)
        { }
        public static void When(bool haserror, string error)
        {
            if (haserror)
            {
                throw new DomainValidation(error);
            }
        }

    }
}
