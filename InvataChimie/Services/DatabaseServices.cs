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
using Android.Database;

namespace InvataChimie.Services
{
    class DatabaseServices : SQLiteOpenHelper
    {
        private const int DatabaseVersion = 5;
        private const string DatabaseName = "chimie";
        private static Context _currentContext;
        private SQLiteDatabase _db;
        private const String QUESTIONS_TABLE_NAME = "Questions";


        public DatabaseServices(Context context)
                : base(context, DatabaseName, null, DatabaseVersion)
        {
            _currentContext = _currentContext ?? context;
            _db = WritableDatabase;
        }

        public override void OnCreate(SQLiteDatabase db)
        {
            string databasecreate = "CREATE TABLE IF NOT EXISTS " + "Questions" + "(" +
                                    "id " + "integer, " +
                                    "name " + "text, " +
                                    "answer_good " + "text, " +
                                    "answer1 " + "text, " +
                                    "answer2 " + "text, " +
                                    "answer3 " + "text, " +
                                    "image_key " + "text);";
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

        public int getQuestionsCount()
        {
            var db = GetDatabase();
            const string query = "Select * from " + QUESTIONS_TABLE_NAME;
            int count = 0;
            try
            {
                var cursor = db.RawQuery(query, null);
                if(cursor != null)
                {
                    count = cursor.Count;
                    cursor.Close();
                }              
            } catch (SQLException s)
            {
                var abc = 0;
            }
            return count;
        }

        public Question getQuestion(int rowId)
        {
            var db = GetDatabase();

            var question = new Question();
            string query = "Select * from " + QUESTIONS_TABLE_NAME + " WHERE id = " + rowId.ToString() + "; ";
            try
            {
                var cursor = db.RawQuery(query, null);
                if (cursor.MoveToFirst())
                {
                    do
                    {
                        //var abc = cursor.GetString (9);

                        question.Id = cursor.GetInt(0);
                        question.Name = cursor.GetString(1);
                        question.AnswerGood = cursor.GetString(2);
                        question.Answer1 = cursor.GetString(3);
                        question.Answer2 = cursor.GetString(4);
                        question.Answer3 = cursor.GetString(5);
                        question.ImageKey = cursor.GetString(6);                       
                    } while (cursor.MoveToNext());
                }

                cursor.Close();
            }
            catch (SQLException s)
            {
                var abc = 0;
            }
            ////db.Close();
            return question;
        }

        public void InsertQuestion(Question question)
        {
            var db = GetDatabase();
            var values = new ContentValues();
            values.Put("id", question.Id);
            values.Put("name", question.Name);
            values.Put("answer_good", question.AnswerGood);
            values.Put("answer1", question.Answer1);
            values.Put("answer2", question.Answer2);
            values.Put("answer3", question.Answer3);
            values.Put("image_key", question.ImageKey);
            
            db.Insert(QUESTIONS_TABLE_NAME, null, values);
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