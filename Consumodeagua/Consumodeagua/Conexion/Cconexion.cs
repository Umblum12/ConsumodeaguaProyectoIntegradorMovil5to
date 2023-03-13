using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;

namespace Consumodeagua.Conexion
{
    public class Cconexion
    {
        public static FirebaseClient firebase = new FirebaseClient("https://consumodeagua-7debb-default-rtdb.firebaseio.com/");
    }
}
