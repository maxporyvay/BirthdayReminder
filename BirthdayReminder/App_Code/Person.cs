using System;
using System.Data;

namespace BirthdayReminder.App_Code
{
    public class Person
    {
        public int RowNumb { get; set; }
        public int PersonId { get; set; }
        public string PersonName { get; set; }
        public string PersonPhotoName { get; set; }
        public DateTime PersonBirthdate { get; set; }
        public Person(DataRow dataRow, int index=0){
            RowNumb = index;
            PersonId = (int)dataRow["PersonId"];
            PersonName = dataRow["PersonName"].ToString();
            PersonBirthdate = (DateTime)dataRow["PersonBirthdate"];
            PersonPhotoName = dataRow["PersonPhotoName"].ToString();
        }
        public Person(int id, string name, DateTime birthdate, string photoname, int index=0)
        {
            RowNumb = index;
            PersonId = id;
            PersonName = name;
            PersonBirthdate = birthdate;
            PersonPhotoName = photoname;
        }
    }
}