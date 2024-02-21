namespace ExersiceApiCommuniction.ApiOne.Endpoints.Animals;

public class AnimalsService
{
    public List<Animal> Animals { get; set; } = new List<Animal>()
    {
        new Animal("Fish"),
        new Animal("Cat"),
        new Animal("Dog")
    };
}