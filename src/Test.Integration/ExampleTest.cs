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
        // TODO: check integration tests youtube video from the playlist and the net core doc.
        var response = Client.GetAsync("api/v1/Transactions");
        var result = await response;
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
    }
}