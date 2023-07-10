using project.net.Models;

namespace project.net.Services;

public static class PizzaService
{
    static List<pizza> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<pizza>
        {
            new pizza { id = 1, name = "Classic Italian", IsGlutenFree = false },
            new pizza { id = 2, name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<pizza> GetAll() => Pizzas;

    public static pizza? Get(int id) => Pizzas.FirstOrDefault(p => p.id == id);

    public static void Add(pizza pizza)
    {
        pizza.id = nextId++;
        Pizzas.Add(pizza);
    }

    public static void Delete(int id)
    {
        var pizza = Get(id);
        if(pizza is null)
            return;

        Pizzas.Remove(pizza);
    }

    public static void Update(pizza pizza)
    {
        var index = Pizzas.FindIndex(p => p.id == pizza.id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }
}