using Microsoft.AspNetCore.Mvc;
using test.Data;
using test.Models;

namespace test.Controllers
{
    public class PedidoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PedidoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Pedido> objPedidoList = _db.tbl_pedido.ToList();
            return View(objPedidoList);
        }

        //GET
        public IActionResult Adicionar()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Pedido obj)
        {
            
            if (obj.Bebida==null)
            {
                obj.Bebida = "Não quer bebida";
            }
            if (obj.Bebida == "Não quer bebida")
            {
                obj.Quantidade= 0;
            }
            if (ModelState.IsValid) 
            {
                _db.tbl_pedido.Add(obj);
                _db.SaveChanges();

                Cozinha pedido_cozinha = new Cozinha();
                pedido_cozinha.FK_id_pedido = _db.tbl_pedido.OrderBy(x => x.Id_pedido).Last().Id_pedido;
                pedido_cozinha.Prazo = null;

                _db.tbl_cozinha.Add(pedido_cozinha);
                _db.SaveChanges();

                Copa pedido_copa = new Copa();
                pedido_copa.FK_id_pedido = _db.tbl_pedido.OrderBy(x => x.Id_pedido).Last().Id_pedido;
                pedido_copa.Bebida = obj.Bebida;
                pedido_copa.Quantidade = obj.Quantidade;

                _db.tbl_copa.Add(pedido_copa);
                _db.SaveChanges();

                TempData["success"] = "Pedido Criado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        //GET
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }
            var pedidoFromDb = _db.tbl_pedido.Find(id);

            if (pedidoFromDb == null) 
            {
                return NotFound();
            }
            return View(pedidoFromDb);
        }

        //POST
        [HttpPost, ActionName("Editar")]
        [ValidateAntiForgeryToken]
        public IActionResult EditarPOST(Pedido obj)
        {
            if (obj.Bebida == null)
            {
                obj.Bebida = "Não quer bebida";
            }
            if (obj.Bebida == "Não quer bebida")
            {
                obj.Quantidade = 0;
            }
            if (ModelState.IsValid)
            {
                _db.tbl_pedido.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Pedido Editado com sucesso!";
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
            var pedidoFromDb = _db.tbl_pedido.Find(id);

            if (pedidoFromDb == null)
            {
                return NotFound();
            }
            return View(pedidoFromDb);
        }

        //POST
        [HttpPost,ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarPOST(int? id)
        {
            var objCozinha = _db.tbl_cozinha.Find(id);
            var objPedido = _db.tbl_pedido.Find(id);
            var objCopa = _db.tbl_copa.Find(id);
            if (objPedido == null)
            {
                return NotFound();
            }
            //se pedido deletado, deleta da cozinha e copa também
            _db.tbl_pedido.Remove(objPedido);
            _db.SaveChanges();

            _db.tbl_cozinha.Remove(objCozinha);
            _db.SaveChanges();

            _db.tbl_copa.Remove(objCopa);
            _db.SaveChanges();

            TempData["success"] = "Pedido Deletado com sucesso!";
            return RedirectToAction("Index");

        }
    }
}
