using ProductManagementAPI.Exceptions;

namespace ProductManagementAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public ErrorHandlingMiddleware()
        {

        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var response = context.Response;

            try
            {
                await next.Invoke(context);
            }
            catch (ProductNotFoundException productNotFoundException)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                await response.WriteAsync(productNotFoundException.Message);
            }
            catch (Exception ex)
            {
                response.StatusCode = StatusCodes.Status404NotFound;
                await response.WriteAsync(ex.Message);
            }
        }
    }
}
