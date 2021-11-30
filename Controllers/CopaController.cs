using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class CopaController : Controller
    {
        private readonly ApplicationDbContext _db;


        public CopaController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Pedido> objPedidoList = _db.tbl_pedido.ToList();
            IEnumerable<Copa> copaList = _db.tbl_copa.ToList();
            if (copaList.Count() == 0)
            {
                ViewBag.naoexiste = true;
            }
            ViewBag.data = copaList;
            return View(objPedidoList);
        }

        //GET
        public IActionResult Deletar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var copaFromDb = _db.tbl_copa.Find(id);
            var pedidoFromDb = _db.tbl_pedido.Find(id);
            ViewBag.data = pedidoFromDb;
            if (copaFromDb == null)
            {
                return NotFound();
            }
            return View(copaFromDb);
        }

        //POST
        [HttpPost, ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarPOST(int? id)
        {
            var objCozinha = _db.tbl_cozinha.Find(id);
            var objPedido = _db.tbl_pedido.Find(id);
            var objCopa = _db.tbl_copa.Find(id);

            if (objCopa == null)
            {
                return NotFound();
            }
            // se o da cozinha foi entregue, então o pedido ja foi totalmente entregue
            if (objCozinha == null)
            {
                _db.tbl_pedido.Remove(objPedido);
                _db.SaveChanges();
            }

            _db.tbl_copa.Remove(objCopa);
            _db.SaveChanges();
            TempData["success"] = "Bebida Liberada com sucesso!";
            return RedirectToAction("Index");

        }
    }
}
