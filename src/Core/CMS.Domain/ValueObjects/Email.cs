using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Domain.ValueObjects
{
    public record Email
    {
        private Email(string address)
        {
            Address = address;
        }


        public string Address { get; init; }



        public static Email Empty { get; } = CreateEmail(string.Empty);

        public static Email CreateEmail(string address)
        {
            return new Email(address);
        }
    }
}
