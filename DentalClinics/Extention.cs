using DentalClinic.Middleware;

namespace DentalClinic
{
    public static class Extention
    {
        public static IApplicationBuilder UseShbbatMiddleware(this IApplicationBuilder b)
        {
            return b.UseMiddleware<ShabbatMiddleware>();
        }
    }
}
