using System.Net;
using Contracts.Transactions;
using Newtonsoft.Json;

namespace Test.Integration.Controllers.Transactions;

public class GetTransactionsTest : IntegrationTest
{
    public GetTransactionsTest(IntegrationFixture integrationFixture) : base(integrationFixture)
    {
    }

    [Fact]
    public async Task Do()
    {
        var response = Client.GetAsync("api/v1/Transactions");
        var result = await response;
        var deserializedResponse =
            JsonConvert.DeserializeObject<GetTransactionsResponse>(await result.Content.ReadAsStringAsync());
        Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        // TODO: create
        var expected = deserializedResponse;
        deserializedResponse.Should().Be(expected);
    }
}