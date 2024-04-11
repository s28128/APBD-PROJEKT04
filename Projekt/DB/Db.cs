using Projekt.Models;
namespace Projekt.DB;

public class Db
{
    public static List<Animal> Animals = new()
    {
        new Animal { Id = 1, Imie = "Pimpek", Kolor_siersci = "brązowy", Masa = 10,Kategoria = new Category { Name = "Pies", Code = 1 }},
        new Animal { Id = 2, Imie = "Kratos", Kolor_siersci = "rudy", Masa = 15,Kategoria = new Category { Name = "Kot", Code = 2 }},
        new Animal { Id = 3, Imie = "Kropka", Kolor_siersci = "czarny", Masa = 12,Kategoria = new Category { Name = "Pies", Code = 3 }}
    };

    public static List<Appointment> Visits = new()
    {
        new Appointment { Id = 1, IdAnimal = 1, Animal = Animals[0], Opis = "Badanie rutynowe", Cena = 50 },
        new Appointment { Id = 2, IdAnimal = 1, Animal = Animals[0], Opis = "Szczepienie przeciwko wściekliźnie", Cena = 80 },
        new Appointment { Id = 3, IdAnimal = 1, Animal = Animals[0], Opis = "Zabieg usuwania kamienia nazębnego", Cena = 120 }
    };
}