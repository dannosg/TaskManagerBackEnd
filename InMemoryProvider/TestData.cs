using TaskProject.Data;

namespace TaskProject.InMemoryProvider
{
    public static class TestData
    {
        public static void AddTestData(DataContext context)
        {
            //Insert testdata
            context.SaveChanges();
        }
    }
}