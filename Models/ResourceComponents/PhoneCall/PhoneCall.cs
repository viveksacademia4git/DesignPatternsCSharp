using Bogus;

namespace Models.ResourceComponents.PhoneCall;

public class PhoneCall
{
    public PhoneCall()
    {
        Id = new Faker().Random.Long();
    }

    public long Id { get; set; }

    public string PhoneNumber { get; set; }

    public CallOperator Operator { get; set; }
}