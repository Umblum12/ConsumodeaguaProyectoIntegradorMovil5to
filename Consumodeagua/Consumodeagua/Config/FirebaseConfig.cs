using Firebase.Auth;
using Firebase.Auth.Providers;

namespace Consumodeagua.Config
{
    public static class FirebaseConfig
    {
        public static string ApiKey = "AIzaSyAtKvrBOrIfasAvix3UxYta7CiMlvTDJWg";
        public static string AuthDomain = "consumodeagua-7debb.firebaseapp.com";
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
