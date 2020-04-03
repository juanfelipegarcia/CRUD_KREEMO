using CRUD_KREEMO.Clases;
using CRUD_KREEMO.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_KREEMO.Models.Abstrac
{
    public interface IEmpleadoBusiness
    {
        Task guardarEmpleado(Empleado empleado);
        Task eliminarEmpleado(Empleado empleado);
        Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosTodos();
        Task<Empleado> obtenerEmpleadoPorID(int? id);
        Task<List<CargoEmpleado>> obtenerCargoTodos();
        Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosPorNombrePorId(string busqueda);


    }

}
