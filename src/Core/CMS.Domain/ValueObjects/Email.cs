namespace CMS.Domain.ValueObjects
{
    public record Email
    {
        private Email(string address)
        {
            Address = address;
        }


        public string Address { get; init; }



        public static Email Empty { get; } = Create(string.Empty);

        public static Email Create(string address)
        {
            return new Email(address);
        }
    }
}
