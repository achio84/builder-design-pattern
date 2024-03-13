
using BuilderDesignPattern;

while (true)
{
    Console.WriteLine("Press 1 to print current date from DB.");
    Console.WriteLine("Press 2 to send email.");
    Console.WriteLine("Enter your selection.");

    var input = Console.ReadKey();
    Console.WriteLine();
    if (input.Key == ConsoleKey.D1)
    {
        var currentDate = await GetCurrentDate().ConfigureAwait(false);
        Console.WriteLine(currentDate);
    }
    else if (input.Key == ConsoleKey.D2)
    {
        await SendEmailAsync().ConfigureAwait(false);
    }
    else
    {
        break;
    }
    Console.WriteLine("".PadRight(100, '_'));
}

async Task<DateTimeOffset> GetCurrentDate(CancellationToken cancellationToken = default)
{
    var dal = new DAL();

    return await dal.GetDateTimeOffset(cancellationToken).ConfigureAwait(false);
}

async Task SendEmailAsync(CancellationToken cancellationToken = default)
{
    var service = new SmtpEmailService();
    await service.SendEmailAsync("chingchong.jong@company1.com.my", "noreply@company1.com.my", "Test subject", "test body", new List<string>());
}