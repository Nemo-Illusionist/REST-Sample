using Npgsql;
using Radilovsoft.Rest.Data.Core.Contract;
using Sample.Db.Exception;

namespace Sample.Db.Manager
{
    public class PostgresDbExceptionManager : IDataExceptionManager
    {
        public System.Exception Normalize(System.Exception exception)
        {
            if (exception != null && exception.InnerException is PostgresException ex)
            {
                var message = ex.Message + ex.Detail;

                switch (ex.SqlState)
                {
                    case PostgresErrorCodes.ForeignKeyViolation:
                        throw new ForeignKeyViolationException(message, ex);
                    case PostgresErrorCodes.UniqueViolation:
                        throw new ObjectAlreadyExistsException(message, ex);
                    case PostgresErrorCodes.SerializationFailure:
                        throw new ConcurrentModifyException(message, ex);
                    default:
                        throw ex;
                }
            }

            return exception;
        }

        public bool IsRepeatAction(System.Exception ex)
        {
            return ex is ConcurrentModifyException;
        }
    }
}