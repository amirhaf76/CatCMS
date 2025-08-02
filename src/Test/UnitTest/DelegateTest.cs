using Xunit.Abstractions;

namespace UnitTest
{
    public delegate string SumFunc(int x, string s);
    public delegate void SumFunc2(int x, string s);



    public class DelegateTest
    {
        private ITestOutputHelper _output;

        public event SumFunc? FirstEvent;

        public DelegateTest(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact]
        public void Test1()
        {
            var sumFunc = new SumFunc(Hello);
            sumFunc += Hello2;
            sumFunc += delegate (int x, string s)
            {
                _output.WriteLine("Hello3");
                return "The last one.The input is \"{x}\" and \"{s}\" ";
            };

            FirstEvent = Hello;

            FirstEvent?.Invoke(3, "");

            _output.WriteLine(sumFunc(2, "fdafds"));
        }

        private string Hello(int x, string s)
        {
            _output.WriteLine("Hello");
            return $"The input is \"{x}\" and \"{s}\"";
        }

        private string Hello2(int x, string s)
        {
            _output.WriteLine("Hello2");
            return $"it's second one.The input is \"{x}\" and \"{s}\"";
        }
    }
}
