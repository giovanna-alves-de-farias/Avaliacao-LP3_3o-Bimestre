using Microsoft.AspNetCore.Mvc;
using ShoppingMVC.ViewModels;

namespace ShoppingMVC.Controllers;

public class LojaController : Controller
{
    private static List<LojaViewModel> lojas = new List<LojaViewModel>();

    public IActionResult Index() => View(lojas);

    public IActionResult Admin() => View(lojas);

    public IActionResult Show(int id) => View(lojas[id-1]);

    public IActionResult Cadastrar() => View();

    public IActionResult CreateLoja(int id, string? piso, string? nome, string? descricao, string? tipo, string? email)
    {
        if (lojas.Any(y => y.Nome == nome))
        {
            TempData["NameError"] = "Loja localizada com esse nome!";
            return RedirectToAction("Admin");
        } 
        else
        {
            id = lojas.Count + 1;

            lojas.Add(new LojaViewModel(id, piso, nome, descricao, tipo, email));

            return RedirectToAction("Admin");
        }
    }

    public IActionResult DeleteLoja(int id)
    {
        lojas.RemoveAll(x => x.Id == id);

        return RedirectToAction("Admin");
    }
}