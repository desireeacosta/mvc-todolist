using Microsoft.AspNetCore.Mvc;
using modelos_webdev.Models;
using modelos_webdev.Services;

namespace modelos_webdev.Controllers;
public class HomeController : Controller
{
  private readonly MongoDBService _mongoDBService;

  public HomeController(MongoDBService mongoDBService)
  {
    _mongoDBService = mongoDBService;
  }

  public async Task<IActionResult> Index()
  {
    var cards = await _mongoDBService.GetAsync();
    return View(cards);
  }

  [HttpGet]
  public async Task<ActionResult<Card>> Get(string id)
  {
    var card = await _mongoDBService.GetAsync(id);

    if (card is null)
    {
      return NotFound();
    }

    return card;
  }

  public IActionResult AddTaskPage()
  {
    return View();
  }

  [HttpPost]
  public async Task<IActionResult> AddCard(Card newCard)
  {
    if (ModelState.IsValid)
    {
      await _mongoDBService.CreateAsync(newCard);
      return RedirectToAction("Index");
    }

    return View("Index", await _mongoDBService.GetAsync());
  }

  [HttpDelete]
  public async Task<IActionResult> DeleteCard(string id)
  {
    await _mongoDBService.RemoveAsync(id);
    return Ok();
  }

  [HttpPut]
  public async Task<IActionResult> SaveCard(string id, [FromBody] Card editedCard)
  {
    var existingCard = await _mongoDBService.GetAsync(id);
    if (existingCard == null)
    {
      return NotFound();
    }

    existingCard.Name = editedCard.Name;
    existingCard.Status = editedCard.Status;

    await _mongoDBService.UpdateAsync(id, existingCard);

    return Ok();
  }
}
