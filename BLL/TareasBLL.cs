using Microsoft.EntityFrameworkCore;
using Parcial2_ap1_2018_0553.DAL;
using Parcial2_ap1_2018_0553.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_ap1_2018_0553.BLL
{
    class TareasBLL
    {
        public static Tareas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Tareas tareas;
            try
            {
                tareas = contexto.Tareas.Include(e => e.TipoTarea).Where(p => p.TareaId == id).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return tareas;
        }

        public static List<Tareas> GetList(Expression<Func<Tareas, bool>> criterio)
        {
            List<Tareas> lista = new List<Tareas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Tareas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static List<Tareas> GetTareas()
        {
            List<Tareas> lista = new List<Tareas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Tareas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }
    }
}
