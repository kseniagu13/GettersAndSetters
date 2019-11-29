using System;
using System.Collections.Generic;
using System.Linq;

namespace GettersAndSetters
{
    class Program
    {
        class Person
        {
            string name;
            string gender;
            int age;
            string idCode;

            //loome objekti konstruktori abil
            public Person(string _name, string _gender, int _age, string _idCode)
            {
                Name = _name;
                Gender = _gender;
                Age = _age;
                IdCode = _idCode;
            }

            //määrame Getters and Setters (selleks, et saaks kasutada private andmed Mainis)
            //kasutame Getters ja Setters objektide omaduste kaitsmiseks
            public string Name //see on eraldi meetod nimega Getters ja Setters
            {
                get { return name; } //getter
                set { name = value; } //setter
            }
            public string Gender
            {
                get { return gender; }
                set //kontrollime, kui kasutaja lisab midagi muud kui male või female, siis ta on unicorn
                {
                    if (value == "male" || value == "female")
                    {
                        gender = value;
                    }
                    else
                    {
                        gender = "unicorn";
                    }
                }
            }

            public string IdCode //lisame IdCode, et kontrollida, kas ta võrdub 11 tähemärki
            {
                get { return idCode; }
                set
                {
                    if (value.Length == 11) // kui idcode võrdu 11 märki
                    {
                        idCode = value;
                    }
                    else
                    {
                        idCode = "undefined"; // ei ole leitud
                    }
                }
            }

            public int Age
            {
                get { return age; }
                set //kontrollime, kui age väiksem kui 0 siis näitab age=0
                {
                    if (value < 0)
                    {
                        age = 0;
                    }
                    else
                    {
                        age = value;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Person newPerson = new Person("John", "male", 34, "49101135717"); //lõime uue objekti ja andsime talle parameetrid
            Console.WriteLine($"A new person {newPerson.Name}."); //kutsume välja, nime
            newPerson.Name = "Joanna"; //vahetame newPersonile nime, selle jaoks on vaja luua getter and setter, sest Name on private
            Console.WriteLine($"A new person {newPerson.Name}.");//kuvame uus nimi
            newPerson.Gender = "Fairy"; // uus gender
            Console.WriteLine($"Your gender is {newPerson.Gender}."); // näitab unicorn, kui ei ole male või female

            newPerson.IdCode = "49101135717"; // uus idcode, võib teha lühemaks, et kontrollida IdCode meetodi(kas leitud või mitte)
            Console.WriteLine($"Your IdCode is {newPerson.IdCode}.");

            Console.WriteLine($"Your age is {newPerson.Age}."); // kui vanus on vähem kui 0, siis näitab 0


        }
    }
}
