namespace Test.Integration;

public class Test : IntegrationTest
{
    public Test(IntegrationFixture integrationFixture) : base(integrationFixture)
    {
    }

    [Fact]
    public async Task Do()
    {
        var result = Client.GetAsync("api/v1.0/Transactions");
        await result;
    }
}