

using System.Text.Json;
using FluentAssertions;

namespace Nibblebit.Lemmy.Tests;

public class SnakeCasePolicyTest
{
    internal class TestModel
    {
        public string TestStringPropery { get; set; }
        public int TestIntPropery { get; set; }
        public DateTime TestDateTimePropery { get; set; }
    }
    
    [Fact]
    public async Task CreatePostTestAsync()
    {
        var model = new TestModel
        {
            TestStringPropery = "test",
            TestIntPropery = -1,
            TestDateTimePropery = new DateTime(2023, 01, 01)
        };
        var j = new JsonSerializerOptions { PropertyNamingPolicy = new JsonSnakeCaseNamingPolicy() };
        var str = JsonSerializer.Serialize(model,j);

        var res = JsonSerializer.Deserialize<TestModel>(str,j);
        res.TestIntPropery.Should().Be(-1);
        res.TestStringPropery.Should().Be("test");
    }
    
    [Fact]
    public async Task TestConverter()
    {
        Json.ConvertSnakeCase("JsonConverterTest", "_").Should().Be("json_converter_test");
    }
}
