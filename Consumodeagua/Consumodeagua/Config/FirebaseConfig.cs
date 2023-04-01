using Firebase.Auth;
using Firebase.Auth.Providers;

namespace Consumodeagua.Config
{
    public static class FirebaseConfig
    {
        public static string ApiKey = "AIzaSyD8d76S07BjkoyJFErIqojRGQ5gGJUQeI4";
        public static string AuthDomain = "consumodeaguapi.firebaseapp.com";
        public static FirebaseAuthProvider[] Providers = new FirebaseAuthProvider[]
        {
            new EmailProvider()
        };
        public static FirebaseAuthConfig AuthConfig = new FirebaseAuthConfig
        {
            ApiKey = ApiKey,
            AuthDomain = AuthDomain,
            Providers = Providers
        };
    }
}
