using Bogus;
using Models.Components;

namespace Models;

public class PhoneCall
{
    public PhoneCall()
    {
        Id = new Faker().Random.Long();
    }

    public long Id { get; set; }

    public IPhone Phone { get; set; }

    public CallOperator Operator { get; set; }
}