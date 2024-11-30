using System.Net;
using Contracts.Transactions;
using Newtonsoft.Json;

namespace Test.Integration.Api.Controllers.V1.TransactionsController;

public class GetTransactionsShould : IntegrationTest
{
    public GetTransactionsShould(IntegrationFixture integrationFixture) : base(integrationFixture)
    {
    }

    [Fact]
    public async Task Get_NoParameters_ReturnsAllTransactions()
    {
        // Arrange.
        // Act.
        var responseTask = Client.GetAsync(HttpHelper.Urls.GetAllTransactionsV1);
        // Assert.
        var response = await responseTask;
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        var deserializedResponse =
            JsonConvert.DeserializeObject<GetTransactionsResponse>(await response.Content.ReadAsStringAsync());
        // TODO: check the result too, not only the status code.
    }
}