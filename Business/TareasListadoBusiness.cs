using Data;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class TareasListadoBusiness
    {
        public List<Tarea> ListarTareas()
        {
            var dt = new TareasListadoData().ObtenerTareasDt();
            var list = new TareasListadoData().ConvertirDataTableALista(dt);
            return list;
        }

        public bool EditarTarea(Tarea tarea) {
            var editada = new TareasListadoData().EditarTarea(tarea);
            return editada;
        }
        public bool AgregarTarea(Tarea tarea) {
            var agregada = new TareasListadoData().AgregarTarea(tarea);
            return agregada;
        }

        public bool EliminarTarea(Tarea tarea)
        {
            var eliminada = new TareasListadoData().EliminarTarea(tarea);
            return eliminada;
        }
    }
}
