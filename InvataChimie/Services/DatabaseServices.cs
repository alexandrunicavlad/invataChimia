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
using Android.Util;

namespace InvataChimie.Services
{
    class DatabaseServices : SQLiteOpenHelper
    {
        private const int DatabaseVersion = 5;
        
        private static Context _currentContext;
        private SQLiteDatabase _db;
        private const String QUESTIONS_TABLE_NAME = "Questions";


        public DatabaseServices(Context context)
                : base(context, "chimie", null, DatabaseVersion)
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
                                    "image_key " + "text, " +
                                    "resolved " + "integer);";
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
                Log.Info("da", s.Message);
            }
            return count;
        }

        public List<Question> getAllQuestions()
        {
            var db = GetDatabase();
            string query = "Select * from " + QUESTIONS_TABLE_NAME + " ORDER BY RANDOM() ; ";
            var questions = new List<Question> ();
            try
            {
                var cursor = db.RawQuery(query, null);
                if (cursor.MoveToFirst())
                {
                    do
                    {
                        Question question = new Question();
                        question.Id = cursor.GetInt(0);
                        question.Name = cursor.GetString(1);
                        question.AnswerGood = cursor.GetString(2);
                        question.Answer1 = cursor.GetString(3);
                        question.Answer2 = cursor.GetString(4);
                        question.Answer3 = cursor.GetString(5);
                        question.ImageKey = cursor.GetString(6);
                        question.Resolved = cursor.GetInt(7);
                        questions.Add(question);
                    } while (cursor.MoveToNext());
                }

                cursor.Close();
            }
            catch (SQLException s)
            {
                Log.Info("da", s.Message);
            }

            return questions;
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
                        question.Id = cursor.GetInt(0);
                        question.Name = cursor.GetString(1);
                        question.AnswerGood = cursor.GetString(2);
                        question.Answer1 = cursor.GetString(3);
                        question.Answer2 = cursor.GetString(4);
                        question.Answer3 = cursor.GetString(5);
                        question.ImageKey = cursor.GetString(6);
                        question.Resolved = cursor.GetInt(7);                    
                    } while (cursor.MoveToNext());
                }

                cursor.Close();
            }
            catch (SQLException s)
            {
                Log.Info("da", s.Message);
            }
            ////db.Close();
            return question;
        }

        public void UpdateQuestion(Question question)
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
            values.Put("resolved", question.Resolved);
            db.Update(QUESTIONS_TABLE_NAME, values, "id=" + question.Id, null);
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
            values.Put("resolved", question.Resolved);
            
            db.Insert(QUESTIONS_TABLE_NAME, null, values);
        }

        public void DeleteQuestions()
        {
            var db = GetDatabase();
            string query = "delete from " + QUESTIONS_TABLE_NAME ;
            db.ExecSQL(query);
        }

    }
}