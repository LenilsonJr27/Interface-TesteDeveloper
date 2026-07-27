using InterfaceTestDev.Models;
using Microsoft.AspNetCore.Mvc;
using TesteDeveloper;

public class EstoqueController : Controller
{
    private static List<EstoqueProduto> _produtos = new List<EstoqueProduto>
    {
        
            new EstoqueProduto { Id = 1,  Referencia = "A2342", SaldoEstoque = 10 },
            new EstoqueProduto { Id = 2,  Referencia = "B8765", SaldoEstoque = 4 },
            new EstoqueProduto { Id = 3,  Referencia = "C9546", SaldoEstoque = 6 },
            new EstoqueProduto { Id = 4,  Referencia = "D7862", SaldoEstoque = 45 },
            new EstoqueProduto { Id = 5,  Referencia = "E6423", SaldoEstoque = 7 },
            new EstoqueProduto { Id = 6,  Referencia = "A2342", SaldoEstoque = 10 },
            new EstoqueProduto { Id = 7,  Referencia = "B8765", SaldoEstoque = 4 },
            new EstoqueProduto { Id = 8,  Referencia = "C9546", SaldoEstoque = 6 },
            new EstoqueProduto { Id = 9,  Referencia = "D7862", SaldoEstoque = 45 },
            new EstoqueProduto { Id = 10,  Referencia = "E6423", SaldoEstoque = 7 },
            new EstoqueProduto { Id = 11,  Referencia = "F1289", SaldoEstoque = 18 },
            new EstoqueProduto { Id = 12,  Referencia = "G5431", SaldoEstoque = 32 },
            new EstoqueProduto { Id = 13,  Referencia = "H7764", SaldoEstoque = 5 },
            new EstoqueProduto { Id = 14,  Referencia = "I9052", SaldoEstoque = 12 },
            new EstoqueProduto { Id = 15,  Referencia = "J3378", SaldoEstoque = 0 },
            new EstoqueProduto { Id = 16,  Referencia = "K4419", SaldoEstoque = 67 },
            new EstoqueProduto { Id = 17,  Referencia = "L8923", SaldoEstoque = 14 },
            new EstoqueProduto { Id = 18,  Referencia = "M1257", SaldoEstoque = 3 },
            new EstoqueProduto { Id = 19,  Referencia = "N6734", SaldoEstoque = 21 },
            new EstoqueProduto { Id = 20,  Referencia = "O4521", SaldoEstoque = 39 },
    };

    public IActionResult Index()
    {
        return View(_produtos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(EstoqueProduto produto)
    {
        produto.Id = _produtos.Max(p => p.Id) + 1;

        _produtos.Add(produto);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null)
            return NotFound();

        return View(produto);
    }

    [HttpPost]
    public IActionResult Edit(EstoqueProduto produto)
    {
        var existente = _produtos.FirstOrDefault(p => p.Id == produto.Id);

        if (existente == null)
            return NotFound();

        existente.Referencia = produto.Referencia;
        existente.SaldoEstoque = produto.SaldoEstoque;

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);

        if (produto == null)
            return NotFound();

        return View(produto);
    }

    [HttpPost]
    public IActionResult DeleteConfirmed(int id)
    {
        var produto = _produtos.FirstOrDefault(p => p.Id == id);

        if (produto != null)
            _produtos.Remove(produto);

        return RedirectToAction(nameof(Index));
    }
}