namespace Models.Components;

internal class Address : IAddress
{
    public long RefId { get; set; }
    public string? Suite { get; set; }
    public string Street { get; set; }
    public string City { get; set; }
    public string Zip { get; set; }
}