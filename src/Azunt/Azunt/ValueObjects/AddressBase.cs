using System;

namespace Azunt.ValueObjects
{
    public abstract class AddressBase
    {
#if NET8_0_OR_GREATER
        public required string Line1 { get; set; }
        public string? Line2 { get; set; }
        public required string City { get; set; }
        public required string Country { get; set; }   // ISO 3166-1 권장
        public required string PostCode { get; set; }
#else
        // netstandard2.0에서는 생성자로 필수성 보장
        protected AddressBase() { }
        protected AddressBase(string line1, string city, string country, string postCode)
        {
            Line1 = line1 ?? throw new ArgumentNullException(nameof(line1));
            City = city ?? throw new ArgumentNullException(nameof(city));
            Country = country ?? throw new ArgumentNullException(nameof(country));
            PostCode = postCode ?? throw new ArgumentNullException(nameof(postCode));
        }

        public string Line1 { get; set; }
        public string? Line2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
#endif
    }
}
