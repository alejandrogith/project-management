using System.Net.Http.Json;
using Xunit.Abstractions;

namespace WebApiTest
{
    public class UnitTest1
    {

        private readonly ITestOutputHelper _output;

        public UnitTest1(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public async Task Change() {


            Assert.Equal(2,2); 
        }


        [Fact]
        public  async Task Test1()
        {

            using  var Application =new ApiWebApplicationFactory();

            var client = Application.CreateClient();


            var res =await client.GetStringAsync("/example")  ;
            
           //    var response= await client.GetFromJsonAsync<List<string>>("api/Task",new JsonSerializerOptions {PropertyNameCaseInsensitive=true } );

            _output.WriteLine(res.ToString());

         //   response.ForEach(res => _output.WriteLine("->  " + res));

        //   Assert.Equal("HELLO", res);

          


        }




    }
}