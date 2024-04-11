namespace Projekt.Models;

public class Appointment
{
    public int Id { get; set; }
    
    public int IdAnimal { get; set; }
    public Animal Animal { get; set; }
    public string Opis { get; set; }
    public int Cena { get; set; }
}