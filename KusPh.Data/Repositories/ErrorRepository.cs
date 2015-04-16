using System;
using System.Data.Entity;
using SystemTools.Extensions;
using DataRepository;
using KusPh.Data.Models;

namespace KusPh.Data.Repositories
{
    internal class ErrorRepository : RepositoryBase<Error>
    {
        private static ErrorRepository _instance;

        public void SaveError(string errorMessage)
        {
            var error = Set.Create();
            error.TypeError = "DbContextLog";
            error.Message = errorMessage;

            Set.Add(error);
            SaveChanges();
        }

        public void SaveError(Exception e)
        {
            var error = Set.Create();
            error.TypeError = e.GetType().FullName;
            error.Message = e.GetErrorMessage();
            error.StackTrace = e.StackTrace;

            Set.Add(error);
            SaveChanges();
        }

        private ErrorRepository()
        {
        }

        public static ErrorRepository Errors
        {
            get { return _instance ?? (_instance = new ErrorRepository()); }
        }

        protected override DbContext GetContext()
        {
            return new KusPhContext();
        }
    }

    public class ErrorLog
    {
        public static void SaveError(string errorMessage)
        {
            ErrorRepository.Errors.SaveError(errorMessage);
        }

        public static void SaveError(Exception e)
        {
            ErrorRepository.Errors.SaveError(e);
        }
    }
}
