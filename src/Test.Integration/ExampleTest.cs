using System.Net;

namespace Test.Integration;

public class ExampleTest : IntegrationTest
{
    public ExampleTest(IntegrationFixture integrationFixture) : base(integrationFixture)
    {
    }

    [Fact]
    public async Task Do()
    {
        var response = Client.GetAsync("api/v1/Transactions");
        var result = await response;
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
}