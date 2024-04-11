namespace Projekt.Models;
public class Animal
{
    public int Id { get; set; }
    public string Imie { get; set; }
    public int Masa { get; set; }
    public string Kolor_siersci { get; set; }
    public Category Kategoria { get; set; } 

    public Animal()
    {
        Kategoria = new Category();
    }
}

public class Category
{
    public string Name { get; set; }
    public int Code { get; set; }
}