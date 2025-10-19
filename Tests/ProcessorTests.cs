using NUnit.Framework;
using Moq;

namespace Tests
{
    public interface Processor
    {
        void Process(string input);
        int GetStatus();
    }

    [TestFixture]
    public class ProcessorTests
    {
        private Mock<Processor> _processorMock;

        [SetUp]
        public void SetUp()
        {
            _processorMock = new Mock<Processor>();
        }

        [Test]
        public void Process_ShouldBeCalled_WithCorrectInput()
        {
            var input = "test";
            _processorMock.Object.Process(input);
            _processorMock.Verify(p => p.Process(input), Times.Once);
        }

        [Test]
        public void GetStatus_ShouldReturnExpectedValue()
        {
            _processorMock.Setup(p => p.GetStatus()).Returns(1);
            var status = _processorMock.Object.GetStatus();
            Assert.AreEqual(1, status);
        }
    }
}