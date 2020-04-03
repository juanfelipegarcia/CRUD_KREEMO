using CRUD_KREEMO.Clases;
using CRUD_KREEMO.Models.Abstrac;
using CRUD_KREEMO.Models.DAL;
using CRUD_KREEMO.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_KREEMO.Models.Business
{
    public class EmpleadoBusiness: IEmpleadoBusiness
    {
        private readonly DbContextPrueba _context;
        public EmpleadoBusiness(DbContextPrueba context)
        {
            this._context = context;

        }

        public async Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosTodos()
        {
            //return await _context.Empleados.ToListAsync();

            await using (_context)
            {
                IEnumerable<EmpleadoDetalle> listaEmpleadoDetalles =
                (from empleado in _context.Empleados
                 join cargo in _context.CargoEmpleados
                 on empleado.Cargo equals
                 cargo.IdCargo
                 select new EmpleadoDetalle
                 {
                     IdEmpleado = empleado.IdEmpleado,
                     Nombre = empleado.Nombre,
                     Cargo = cargo.Cargo,
                     Telefono = empleado.Telefono,
                     Documento = empleado.Documento

                 }).ToList();
                return listaEmpleadoDetalles;
            }
        }
        public async Task guardarEmpleado(Empleado empleado)
        {
            if (empleado.IdEmpleado == 0)
                _context.Add(empleado);
            else
                _context.Update(empleado);

            await _context.SaveChangesAsync();

            //await _context.DisposeAsync();

        }

        public async Task eliminarEmpleado(Empleado empleado)
        {
            if (empleado != null)
            {
                _context.Remove(empleado);
                await _context.SaveChangesAsync();

            }

        }

        //Devuelve un empleado
        public async Task<Empleado> obtenerEmpleadoPorID(int? id)
        {
            Empleado empleado;
            empleado = null;

            if (id == null)
            {
                return empleado;
            }
            else
            {
                empleado = await _context.Empleados.FirstOrDefaultAsync(m => m.IdEmpleado == id);
                return empleado;

            }

        }

        //Este metodo deberia tener estar en su clase Businesss
        public async Task<List<CargoEmpleado>> obtenerCargoTodos()
        {
            return await _context.CargoEmpleados.ToListAsync();
        }

        public async Task<IEnumerable<EmpleadoDetalle>> obtenerEmpleadosPorNombrePorId(string busqueda)
        {

            await using (_context)
            {
                IEnumerable<EmpleadoDetalle> listaEmpleadoDetalles =
                (from empleado in _context.Empleados
                 join cargo in _context.CargoEmpleados
                 on empleado.Cargo equals
                 cargo.IdCargo
                 where (empleado.Nombre.Contains(busqueda) || empleado.Documento.ToString().Equals(busqueda))
                 select new EmpleadoDetalle
                 {
                     IdEmpleado = empleado.IdEmpleado,
                     Nombre = empleado.Nombre,
                     Cargo = cargo.Cargo,
                     Telefono = empleado.Telefono,
                     Documento = empleado.Documento

                 }).ToList();
                return listaEmpleadoDetalles;
            }
        }


    }
}
