namespace Movye.Api.Utils
{
    public class AppEnvironments
    {
        public AppEnvironments(
            string pOSTGRE_DB_CONNECTION_STRING,
            string jWT_SECRET,
            string jWT_ISSUER,
            string jWT_AUDIENCE,
            string jWT_EXPIRATION,
            string jWT_REFRESH_EXPIRATION,
            string sMTP_HOST,
            int sMTP_PORT,
            string sMTP_SENDER_EMAIL,
            string sMTP_SENDER_PASSWORD,
            string tHEMOVIEDB_API_KEY
        )
        {
            POSTGRE_DB_CONNECTION_STRING = pOSTGRE_DB_CONNECTION_STRING;
            JWT_SECRET = jWT_SECRET;
            JWT_ISSUER = jWT_ISSUER;
            JWT_AUDIENCE = jWT_AUDIENCE;
            JWT_EXPIRATION = jWT_EXPIRATION;
            JWT_REFRESH_EXPIRATION = jWT_REFRESH_EXPIRATION;
            SMTP_HOST = sMTP_HOST;
            SMTP_PORT = sMTP_PORT;
            SMTP_SENDER_EMAIL = sMTP_SENDER_EMAIL;
            SMTP_SENDER_PASSWORD = sMTP_SENDER_PASSWORD;
            THEMOVIEDB_API_KEY = tHEMOVIEDB_API_KEY;
        }

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
