namespace Models.Components;

public interface IAddress
{
    public long RefId { get; }
    public string? Suite { get; }
    public string Street { get; }
    public string City { get; }
    public string Zip { get; }
}