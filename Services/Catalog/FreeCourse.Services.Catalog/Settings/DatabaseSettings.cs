namespace FreeCourse.Services.Catalog.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public DatabaseSettings(string courseCollectionName, string categoryCollectionName, string connectionString, string databaseName)
        {
            CourseCollectionName = courseCollectionName;
            CategoryCollectionName = categoryCollectionName;
            ConnectionString = connectionString;
            DatabaseName = databaseName;
        }
        public DatabaseSettings() //Cannot dynamically create an instance of type 'FreeCourse.Services.Catalog.Settings.DatabaseSettings'. Reason: No parameterless constructor defined. That is why we need this constructor.
        {

        }

        public string CourseCollectionName { get; set; }
        public string CategoryCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
