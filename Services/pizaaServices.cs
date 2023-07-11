using project.net.Models;

namespace project.net.Services;

public static class PizzaService
{
    static List<pizzas> Pizzas { get; }
    static int nextId = 3;
    static PizzaService()
    {
        Pizzas = new List<pizzas>
        {
            new pizzas { id = 1, name = "Classic Italian", IsGlutenFree = false },
            new pizzas { id = 2, name = "Veggie", IsGlutenFree = true }
        };
    }

   public static  List<pizzas> GetAll() => Pizzas;

    public static pizzas? Get(int id) => Pizzas.FirstOrDefault(p => p.id == id);

    public static void Add(pizzas pizza)
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

    public static void Update(pizzas pizza)
    {
        var index = Pizzas.FindIndex(p => p.id == pizza.id);
        if(index == -1)
            return;

        Pizzas[index] = pizza;
    }
}