
using Projekt.Models;
using Projekt.DB;



var builder = WebApplication.CreateBuilder(args);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();

// Endpoint dla listy animala
app.MapGet("/api/animals", () =>
{
    return Results.Ok(Db.Animals);
}).Produces<List<Animal>>();

// Endpoint dla specyficznego animala z id
app.MapGet("/api/animals/{id}", (int id) =>
{
    var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
    if (animal == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(animal);
}).Produces<Animal>();

// Endpoint dla dodawania nowego animala
app.MapPost("/api/animals", (Animal animal) =>
{
    Db.Animals.Add(animal);
    return Results.Created($"/api/animals/{animal.Id}", animal);
}).Produces<Animal>();

// Endpoint dla updetu istniejacych animalsow
app.MapPut("/api/animals/{id}", (int id, Animal updatedAnimal) =>
{
    var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
    if (animal == null)
    {
        return Results.NotFound();
    }

    animal.Imie = updatedAnimal.Imie;
    animal.Masa = updatedAnimal.Masa;
    animal.Kolor_siersci = updatedAnimal.Kolor_siersci;
    animal.Kategoria = updatedAnimal.Kategoria;

    return Results.NoContent();
}).Produces<Animal>();

// Endpoint dla Delete animalsow
app.MapDelete("/api/animals/{id}", (int id) =>
{
    var animal = Db.Animals.FirstOrDefault(a => a.Id == id);
    if (animal == null)
    {
        return Results.NotFound();
    }

    Db.Animals.Remove(animal);
    return Results.NoContent();
});

// Endpoint dla listy wybraych zwierzakow
app.MapGet("/api/visits/{animalId}", (int animalId) =>
{
    var visits = Db.Visits.Where(v => v.IdAnimal == animalId).ToList();
    return Results.Ok(visits);
}).Produces<List<Appointment>>();

// Endpoint do dodania wizyty
app.MapPost("/api/visits", (Appointment visit) =>
{
    Db.Visits.Add(visit);
    return Results.Created($"/api/visits/{visit.Id}", visit);
}).Produces<Appointment>();

app.Run();
