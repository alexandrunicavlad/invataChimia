using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Database.Sqlite;

namespace InvataChimie.Services
{
    class DatabaseServices : SQLiteOpenHelper
    {
        private const int DatabaseVersion = 5;
        private const string DatabaseName = "LaCabanaDb";
        private static Context _currentContext;
        private SQLiteDatabase _db;


        public DatabaseServices(Context context)
                : base(context, DatabaseName, null, DatabaseVersion)
        {
            _currentContext = _currentContext ?? context;
            _db = WritableDatabase;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            string databasecreate = "CREATE TABLE IF NOT EXISTS " + "intrebari" + "(" +
                                    "Id " + "text, " +
                                    "Intrebare " + "text, " +
                                    "Raspuns1 " + "text, " +
                                    "Raspuns2 " + "text, " +
                                    "Raspuns3 " + "text, " +
                                    "Poza " + "text);";
            db.ExecSQL(databasecreate);
        }

        public override void OnUpgrade(SQLiteDatabase db, int oldVersion, int newVersion)
        {
          
        }

        private SQLiteDatabase GetDatabase()
        {
            if (_db != null && _db.IsOpen)
                return _db;
            _db = WritableDatabase;
            return _db;
        }

        public void CloseDatabase()
        {
            if (_db == null)
                return;
            _db.Close();
        }
        /*
        public List<CabinModel> GetAllCabins()
        {
            var db = GetDatabase();

            var cabins = new List<CabinModel>();
            const string query = "Select * from cabins";
            try
            {
                var cursor = db.RawQuery(query, null);
                if (cursor.MoveToFirst())
                {
                    do
                    {
                        //var abc = cursor.GetString (9);

                        var account = new CabinModel()
                        {
                            Name = cursor.GetString(0),
                            Latitude = cursor.GetDouble(1),
                            Longitude = cursor.GetDouble(2),
                            Phone = cursor.GetInt(3),
                            PhoneType = cursor.GetString(4),
                            Email = cursor.GetString(5),
                            EmailType = cursor.GetString(6),
                            Price = cursor.GetFloat(7),
                            Rating = cursor.GetInt(8)
                            // cursor.GetString (9)
                        };
                        cabins.Add(account);
                    } while (cursor.MoveToNext());
                }

                cursor.Close();
            }
            catch (SQLException s)
            {
                var abc = 0;
            }
            ////db.Close();
            return cabins;

        }
        */

    }
}