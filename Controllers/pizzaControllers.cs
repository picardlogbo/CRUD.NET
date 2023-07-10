using project.net.Models;
using project.net.Services;
using Microsoft.AspNetCore.Mvc;

namespace project.net.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
	public PizzaController()
	{
	}

	// GET all action
	[HttpGet]
	public ActionResult<List<pizza>> getAll() => PizzaService.GetAll();

	// GET by Id action
	[HttpGet("id")]
	public ActionResult<pizza> get(int id)
	{
		var pizza = PizzaService.Get(id);
		
		if (pizza == null)
		{
			return NotFound();
		}
		return pizza;
	}

	// POST action
	[HttpPost]
	public IActionResult Create(pizza pizza)
	{
		PizzaService.Add(pizza);
		return CreatedAtAction(nameof(get), new { id = pizza.id }, pizza);
	}
	
	// PUT action
	[HttpPut("{id}")]
	public IActionResult Update(int id, pizza pizza)
	{
		if (id != pizza.id)
		{
			return BadRequest();
		}
		var existingPizza = PizzaService.Get(id);
		if (existingPizza == null)
		{
			return NotFound();
		}
		PizzaService.Update(pizza);
		return NoContent();
	}
	

	// DELETE action
	
	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
{
		var pizza = PizzaService.Get(id);
		if (pizza == null)
		{
			return NotFound();
		}
		PizzaService.Delete(id);

        return NoContent();
    }
}