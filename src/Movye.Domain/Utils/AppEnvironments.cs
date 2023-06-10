namespace Movye.Api.Utils
{
    public class AppEnvironments
    {
        public AppEnvironments() { }

        public string POSTGRE_DB_CONNECTION_STRING { get; set; }
        public string JWT_SECRET { get; set; }
        public string JWT_ISSUER { get; set; }
        public string JWT_AUDIENCE { get; set; }
        public string JWT_EXPIRATION { get; set; }
        public string JWT_REFRESH_EXPIRATION { get; set; }
        public string SMTP_HOST { get; set; }
        public int SMTP_PORT { get; set; }
        public string SMTP_SENDER_EMAIL { get; set; }
        public string SMTP_SENDER_PASSWORD { get; set; }
        public string THEMOVIEDB_API_KEY { get; set; }
    }
}
