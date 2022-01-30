using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreJenkinsDocker.Api.Helper
{ 
    public class NCJDResult<DataType>
    {
        public DataType Data { get; set; }
        public int StatusCode { get; set; }
        public List<string> Messages { get; set; }
        public bool IsSuccess { get; set; }
        public string UUID { get; set; }
    }

    public class PagingInfo
    {
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
    }

    public static class NCJDResponse
    {
        public static NCJDResult<TResult> Success<TResult>(
            TResult tresult,
            string UUID = null,
            PagingInfo pagingInfo = null,
            List<string> message = null
           )
        {
            var result = new NCJDResult<TResult>();
            result.Data = tresult;
            result.StatusCode = 200;
            result.Messages = message ?? new List<string>();
            result.UUID = UUID;
            result.IsSuccess = true;
            return result;
        }

        public static NCJDResult<TResult> NotFound<TResult>(
           TResult tresult,
           string UUID = null,
           List<string> message = null
          )
        {
            var result = new NCJDResult<TResult>();
            result.Data = tresult;
            result.StatusCode = 204;
            result.Messages = message ?? new List<string>();
            result.UUID = UUID;
            return result;
        }

        public static NCJDResult<TResult> Error<TResult>(
            string error,
            Exception exception = null,
            string UUID = null)
        {
            var result = new NCJDResult<TResult>();
            if (result.Messages == null)
            {
                result.Messages = new List<string>
                {
                    exception?.Message
                };
            }

            result.Messages.AddRange(GetInnerExceptionMessage(exception));
            result.Messages.Insert(0, error);
            result.Messages = result?.Messages?.Where(w => !string.IsNullOrEmpty(w)).Distinct().ToList();
            result.StatusCode = 500;
            result.UUID = UUID;
            result.IsSuccess = false;
            return result;
        }

        public static NCJDResult<TResult> Error<TResult>(
            string[] errors,
            Exception exception = null,
            string UUID = null)
        {
            var result = new NCJDResult<TResult>();
            result.Messages = GetInnerExceptionMessage(exception);
            foreach (var error in errors)
            {
                result.Messages.Insert(0, error);
            }

            result.Messages = result?.Messages?.Where(w => !string.IsNullOrEmpty(w)).Distinct().ToList();
            result.StatusCode = 500;
            result.UUID = UUID;
            result.IsSuccess = false;
            return result;
        }

        public static NCJDResult<TResult> Error<TResult>(
            List<string> errors,
            Exception exception = null,
            string UUID = null)
        {
            return Error<TResult>(errors.ToArray(), exception, UUID);
        }

        private static List<string> GetInnerExceptionMessage(Exception exception)
        {
            var errorTextList = new List<string>();
            var error = GetSubInnerExceptionMessage(exception);
            while (!string.IsNullOrEmpty(error?.Trim()))
            {
                errorTextList.Add(error);
                if (errorTextList.Count() > 10)
                {
                    errorTextList = errorTextList.Distinct().ToList();
                    break;
                }
                error = GetSubInnerExceptionMessage(exception);
            }
            return errorTextList;
        }

        private static string GetSubInnerExceptionMessage(Exception exception)
        {
            return exception?.InnerException?.Message;
        }
    }
}
