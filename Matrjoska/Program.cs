using System;
using System.Linq;
using System.Collections.Generic;


namespace Matrjoska
{
    class Program
    {
        class Matroska
        {
            public static int Count=0; //loeb mitu Matroskat me loome
            string name;
            string colour;
            int size;
            string image;


            public Matroska( string _name, string _colour, int _size, string _image)
            {
                name = _name;
                colour = _colour; // suure tähega ei ole vaja kuna pole Setters, pole midagi kontrollida
                Size = _size;
                image = _image;
                Count++; //iga kord loeb uut matroskat
            }

            public int Size
            {
                get { return size; }
                set
                {
                    if (value > 0 && value <= 10)
                    {
                        size = value;
                    }
                    else
                    {
                        size = 1;
                    }
                }
            }

            public string Name
            {
                get { return name; }
               
            }

            public string Colour
            {
                get { return colour; }
                
            }

            public string Image
            {
                get { return image; }
            }

            public Matroska OpenMatroska (string name, string colour, string image) //suurust pole, sest kasutaja ei saaks muuta matroskat suurust, seda määrab kasutaja esialgu ja siis automaatselt -2
            {
                Matroska newMatroska = new Matroska(name, colour, size - 2, image); //ajutine objekt
                return newMatroska;
            }


        }
        static void Main(string[] args)
        {
            List<Matroska> boxOfMatroskas = new List<Matroska>(); //salvestame objekte listi, siis list teab palju mälu on vaja, et salvestada objekti tüüpi andmeid
            Matroska matroska1 = new Matroska("Matroska1", "green", 10, "image1"); //lõime Matroskat nr 1 suurusega 10, ise ette määrasime
            boxOfMatroskas.Add(matroska1);

            //Open Matroska
            Matroska matroska2 = matroska1.OpenMatroska("Matroska2", "yellow", "image2");
            boxOfMatroskas.Add(matroska2);
            Matroska matroska3 = matroska2.OpenMatroska("Matroska3", "pink", "image3");
            boxOfMatroskas.Add(matroska3);
            Matroska matroska4 = matroska3.OpenMatroska("Matroska4", "orange", "image4");
            boxOfMatroskas.Add(matroska4);
            Matroska matroska5 = matroska4.OpenMatroska("Matroska5", "grey", "image5");
            boxOfMatroskas.Add(matroska5);

            foreach ( Matroska  matroska in boxOfMatroskas)
            {
                Console.WriteLine($"A {matroska.Colour} {matroska.Name} is in the box. Size is {matroska.Size}");
            }

            Console.WriteLine($"There are {Matroska.Count} matroskas in the box.");

            Console.WriteLine("What colour of Matroskas would you like to take from the box?");
            string userInput = Console.ReadLine();
            //foreach ei luba Listist midagi kustutada seega peab kasutama forloop

            for (int i =0; i< boxOfMatroskas.Count; i++)
            {
                if (boxOfMatroskas[i].Colour == userInput)
                {
                    Console.WriteLine($"You have taken {boxOfMatroskas[i].Name} from the box.");
                    boxOfMatroskas.Remove(boxOfMatroskas[i]);
                    Matroska.Count--; //vähem objekte, 4 jäänud
                    break; //kui ta leiab Matroskat, siis läheb välja, et enam tööd ei teeks
                }
            }
            Console.WriteLine();

            foreach (Matroska matroska in boxOfMatroskas)
            {
                Console.WriteLine($"Name: {matroska.Name}, colour: {matroska.Colour} is in the box. ");
            }
            Console.WriteLine($"There are {Matroska.Count} matroskas in the box.");

            Console.ReadLine();
        }
    }
}
