using Application.Services;
using Application.ViewsModels;
using Microsoft.AspNetCore.Mvc;
namespace CajeroMarket9.Controllers
{
	public class CajeroController : Controller
	{

		private readonly CajeroServices _cajeroServices;
		 public CajeroController()
		{
			_cajeroServices = new CajeroServices();
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
        public IActionResult Index(string Modo_Dispensador, int monto)
        {
            if (int.TryParse(Modo_Dispensador, out int modo))
            {

                var cajeroVm = new CreateCajeroViewModels
                {
                    Modo_Dispensador = modo,
                    monto = monto
                };

                string resultado = _cajeroServices.Add(cajeroVm);

                if (resultado.StartsWith("Error") || resultado.StartsWith("Este cajero"))
                {
                    ViewBag.Error = resultado;
                }
                else
                {
                    ViewBag.Resultado = resultado;
                }

                return View();
            }
            else
            {
                ViewBag.Error = "Error: El modo de dispensación no es válido.";
                return View();
            }
        }




        public IActionResult CreateModo()
		{
			return View(_cajeroServices.GetAll());
		}

		[HttpPost]
		public IActionResult CreateModo(CreateCajeroViewModels vm)
		{
			_cajeroServices.Add(vm);
			return RedirectToRoute(new { Controller = "Cajero", Action = "CreateModo"  });
		}

	}
}
