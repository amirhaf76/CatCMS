namespace UnitTest.Helpers
{
    internal class TestHelper
    {
        public const string TEST_DIRECTORY_NAME = "Test";
        public const string TEST_RESULT_DIRECTORY_NAME = "Result";
        public const string FAKE_DATA_NAME = "FakeData";

        public static string GetFakeDataAddress()
        {
            var thePath = Path.Combine(
                TEST_DIRECTORY_NAME,
                FAKE_DATA_NAME);

            return thePath;
        }

        public static string GetResultAddress()
        {
            var thePath = Path.Combine(
                TEST_DIRECTORY_NAME,
                TEST_RESULT_DIRECTORY_NAME);

            return thePath;
        }

        public static string GetAbsoluteFakeDataAddress()
        {
            var thePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                GetFakeDataAddress());

            return thePath;
        }

        public static string GetAbsoluteResultAddress()
        {
            var thePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                 GetResultAddress());

            return thePath;
        }

        public static string[] GetTestResultFilesSystemEntryAndDelete()
        {
            var theTestResultPath = GetAbsoluteResultAddress();

            var fileSystemEntries = Directory.GetFileSystemEntries(theTestResultPath, "*", SearchOption.AllDirectories);

            Directory.Delete(theTestResultPath, true);

            return fileSystemEntries;
        }
    }
}
