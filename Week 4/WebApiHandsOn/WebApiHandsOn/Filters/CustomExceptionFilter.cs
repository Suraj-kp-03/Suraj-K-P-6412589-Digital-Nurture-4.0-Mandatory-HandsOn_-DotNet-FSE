using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace WebApiHandsOn.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            // Log the exception to a file
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "Logs");
            Directory.CreateDirectory(logPath);

            var filePath = Path.Combine(logPath, "exception_log.txt");
            File.AppendAllText(filePath,
                $"{DateTime.Now} - Exception: {exception.Message}\n{exception.StackTrace}\n\n");

            context.Result = new ObjectResult("An unexpected error occurred.")
            {
                StatusCode = 500
            };
        }
    }
}