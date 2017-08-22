namespace Sterling.Core.Exceptions 
{
    public static class Exceptions 
    {
        public static string SterlingActivationException = "The operation {0} is not allowed. A Sterling engine is already active for this application. You must dispose the engine before activating a new one.";
        public static string SterlingDatabaseNotFoundException = "A definition for database with name {0} was not found.";
        public static string SterlingDuplicateDatabaseException = "A database of type {0} has already been created. Only one database may exist.";
        public static string SterlingDuplicateIndexException = "An index with the name {0} for type {1} already exists in Sterling database {1}.";
        public static string SterlingDuplicateTypeException = "A duplicate definition for type {0} already exists in Sterling database {1}.";
        public static string SterlingIndexNotFoundException = "An index with the name {0} was not found for type {1}.";
        public static string SterlingIsolatedStorageException = "There was an issue accessing isolated storage: {0}. Check the inner exception for details.";
        public static string SterlingLoggerNotFoundException = "An attempt to unregister the logger with id {0} failed. The logger was not found.";
        public static string SterlingNoTableDefinitionsException = "No table defintions were provided for the database. At least one table definition is required.";
        public static string SterlingNotReadyException = "Operation failed. Sterling is not activated. Call ISterlingDatabase.Activate() to prepare the database for use.";
        public static string SterlingNullException = "Sterling does not support serialization of NULL properties (property {0} on type {1}).";
        public static string SterlingSerializerException = "Serialization/deserialization failed because the serializer {0} could not process the type {1} requested.";
        public static string SterlingTableNotFoundException = "A definition for type {0} was not found in Sterling database {1}.";
        public static string SterlingTriggerException_SterlingTriggerException_Sterling_trigger_exception = "Sterling trigger exception occurred for trigger {0}: {1}";
        public static string BaseDatabaseInstance_Save_Save_suppressed_by_trigger = "Save suppressed by trigger.";
        public static string BaseDatabaseInstance_Delete_Delete_failed_for_type = "Delete failed for type {0}: delete suppressed by trigger.";
        public static string BaseDatabaseInstance_Truncate_Cannot_truncate_when_background_operations = "Cannot truncate when background operations are still running.";
        public static string BaseDatabaseInstance_RegisterInterceptor_Interceptor_not_null = "Interceptor can't be null";
    }
}