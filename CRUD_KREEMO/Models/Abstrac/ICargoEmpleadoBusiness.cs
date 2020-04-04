using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_KREEMO.Clases;
using CRUD_KREEMO.Models.Entities;

namespace CRUD_KREEMO.Models.Abstrac
{
    public interface ICargoEmpleadoBusiness
    {
        Task<IEnumerable<CargoEmpleadoDetalle>> obtenerCargoEmpleadosTodos();
        Task guardarCargoEmpleado(CargoEmpleado cargoEmpleado);
        Task eliminarCargoEmpleado(CargoEmpleado cargoEmpleadoo);
        Task<CargoEmpleado> obtenerCargoEmpleadoPorID(int? id);
        Task<List<CargoEmpleado>> obtenerCargoTodos();
        Task<IEnumerable<CargoEmpleadoDetalle>> obtenerCargosPorNombrePorId(string busqueda);



    }
}
