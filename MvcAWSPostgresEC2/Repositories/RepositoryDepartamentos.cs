using Microsoft.EntityFrameworkCore;
using MvcAWSPostgresEC2.Data;
using MvcAWSPostgresEC2.Models;

namespace MvcAWSPostgresEC2.Repositories {
    public class RepositoryDepartamentos {

        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context) {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentos() {
            return await this.context.Departamentos.ToListAsync();
        }
        
        public async Task<Departamento?> FindDepartamento(int idDepartamento) {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.IdDepartamento == idDepartamento);
        }

        public async Task InsertDepartamento(string nombre, string localidad) {
            int newId = (await this.context.Departamentos.AnyAsync()) ? await this.context.Departamentos.MaxAsync(x => x.IdDepartamento) + 1 : 1;
            Departamento newDepartamento = new Departamento {
                IdDepartamento = newId,
                Nombre = nombre,
                Localidad = localidad
            };

            this.context.Departamentos.Add(newDepartamento);
            await this.context.SaveChangesAsync();
        }

    }
}
