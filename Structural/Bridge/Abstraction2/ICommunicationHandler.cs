using IO;
using Models.Components;

namespace Bridge.Abstraction2;

public interface ICommunicationHandler
{
    void Send();
}

public class LetterCommunicationHandler : ICommunicationHandler
{
    private readonly IAddress _address;

    public LetterCommunicationHandler(IAddress address)
    {
        _address = address;
    }

    public void Send()
    {
        $"Sending Letter at address '{_address.Suite}, {_address.Street}, {_address.Zip} {_address.City}'.".Print();
    }
}

public class EmailCommunicationHandler : ICommunicationHandler
{
    private readonly IEmail _email;

    public EmailCommunicationHandler(IEmail email)
    {
        _email = email;
    }

    public void Send()
    {
        $"Sending Email at email address '{_email.EmailAddress}'.".Print();
    }
}

public class SmsCommunicationHandler : ICommunicationHandler
{
    private readonly IPhone _phone;

    public SmsCommunicationHandler(IPhone phone)
    {
        _phone = phone;
    }

    public void Send()
    {
        $"Sending Sms at phone number '{_phone.Number}'.".Print();
    }
}