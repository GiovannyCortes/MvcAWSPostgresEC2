using Microsoft.AspNetCore.Mvc;
using MvcAWSPostgresEC2.Models;
using MvcAWSPostgresEC2.Repositories;

namespace MvcAWSPostgresEC2.Controllers {
    public class DepartamentosController : Controller {

        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo) {
            this.repo = repo;
        }

        public async Task<IActionResult> Index() {
            List<Departamento> departamentos = await this.repo.GetDepartamentos();
            return View(departamentos);
        }

        public async Task<IActionResult> Details(int idDepartamento) {
            Departamento? departamento = await this.repo.FindDepartamento(idDepartamento);
            return View(departamento);
        }

        public IActionResult Create() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Departamento departamento) {
            await this.repo.InsertDepartamento(departamento.Nombre, departamento.Localidad);
            return RedirectToAction("Index");
        }

    }
}
