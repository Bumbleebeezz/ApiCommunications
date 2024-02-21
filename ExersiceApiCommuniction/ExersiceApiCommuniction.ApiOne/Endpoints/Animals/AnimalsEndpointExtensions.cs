namespace ExersiceApiCommuniction.ApiOne.Endpoints.Animals;

public static class AnimalsEndpointExtensions
{
    //public static IEndpointRouteBuilder MapAnimalEndpoints(this IEndpointRouteBuilder app)
    //{
    //    var group = app.MapGroup("api/animal");

    //    //CREATE
    //    group.MapPost("/", AddAnimal);
    //    //READ
    //    group.MapGet("/", GetAllAnimals);
    //    //UPDATE
    //    group.MapPut("/{id}", ReplaceAnimal);
    //    group.MapPatch("/{id}", UpdateAnimal);
    //    //DELETE
    //    group.MapDelete("/{id}", RemoveAnimal);

    //    return app;
    //}

    //private static void RemoveAnimal(AnimalsService service, Animal animal)
    //{
    //    service.Animals.Remove(animal);
    //}

    //private static void UpdateAnimal(AnimalsService service, string type, int id)
    //{
    //    service.Animals[id].Type = type;
    //}

    //private static void ReplaceAnimal(AnimalsService service, int id, Animal animal)
    //{
    //    service.Animals[id] = animal;
    //}

    //private static List<Animal> GetAllAnimals(AnimalsService service)
    //{
    //    return service.Animals;
    //}

    //private static void AddAnimal(AnimalsService service, Animal animal)
    //{
    //    service.Animals.Add(animal);
    //}
}