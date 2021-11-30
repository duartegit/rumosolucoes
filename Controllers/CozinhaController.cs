using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class CozinhaController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CozinhaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Pedido> objPedidoList = _db.tbl_pedido.ToList();
            IEnumerable<Cozinha> personlist = _db.tbl_cozinha.ToList();
            if (personlist.Count() == 0)
            {
                ViewBag.naoexiste = true;
            }
            ViewBag.data = personlist;
            return View(objPedidoList);
        }

        //GET
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cozinhaFromDb = _db.tbl_cozinha.Find(id);
            var pedidoFromDb = _db.tbl_pedido.Find(id);
            ViewBag.data = pedidoFromDb;
            ViewBag.prazo = cozinhaFromDb?.Prazo;
            if (cozinhaFromDb == null)
            {
                return NotFound();
            }
            return View(cozinhaFromDb);
        }

        //POST
        [HttpPost, ActionName("Editar")]
        [ValidateAntiForgeryToken]
        public IActionResult EditarPOST(Cozinha obj)
        {
            if (ModelState.IsValid)
            {
                _db.tbl_cozinha.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Prazo Editado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Deletar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cozinhaFromDb = _db.tbl_cozinha.Find(id);
            var pedidoFromDb = _db.tbl_pedido.Find(id);
            ViewBag.data = pedidoFromDb;
            if (cozinhaFromDb == null)
            {
                return NotFound();
            }
            return View(cozinhaFromDb);
        }

        //POST
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarPOST(int? id)
        {
            var objCozinha = _db.tbl_cozinha.Find(id);
            var objPedido = _db.tbl_pedido.Find(id);
            var objCopa = _db.tbl_copa.Find(id);
            if (objCozinha == null)
            {
                return NotFound();
            }
            // se o da copa foi entregue, então o pedido ja foi totalmente entregue
            if (objCopa == null)
            {
                _db.tbl_pedido.Remove(objPedido);
                _db.SaveChanges();
            }

            _db.tbl_cozinha.Remove(objCozinha);
            _db.SaveChanges();
            TempData["success"] = "Pedido Liberado com sucesso!";
            return RedirectToAction("Index");

        }
    }
}

