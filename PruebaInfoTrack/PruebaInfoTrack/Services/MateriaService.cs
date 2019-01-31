using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PruebaInfoTrack.GenericRepository;
using PruebaInfoTrack.Models;

namespace PruebaInfoTrack.Services
{
    public class MateriaService : IMateriaService
    {
        static ModelContext _contexto = new ModelContext();
        GenericRepository<Materia> repositorio = new GenericRepository<Materia>(_contexto);

        public JObject CreateSubject(Materia materia)
        {
            var JObject = new JObject();
            try
            {
                var matter = new Materia
                {
                    Nombres = materia.Nombres,
                    Codigo = materia.Codigo,
                    Docente = materia.Docente,
                    Descripcion = materia.Descripcion
                };
                repositorio.Insert(matter);
                repositorio.Save();
                JObject["Codigo"] = "0000";
                JObject["Descripcion"] = "Materia Creada Correctamente" + matter.IdMateria;
                return JObject;
            }
            catch (Exception e)
            {
                var cod = new ErrorCode();
                var codigoError = cod.Error(e.ToString());
                JObject["Codigo"] = codigoError;
                JObject["Descripcion"] = e.ToString();
                return JObject;
            }
        }

        public JObject DeleteSubject(Materia materia)
        {
            var JObject = new JObject();
            try
            {
                var matter = repositorio.GetByID(materia.IdMateria);
                if (matter != null)
                {
                    var idMatter = materia.IdMateria;
                    repositorio.Delete(matter);
                    repositorio.Save();
                    JObject["Codigo"] = "0000";
                    JObject["Descripcion"] = idMatter;
                    return JObject;
                }
                else
                {
                    JObject["Codigo"] = "0100";
                    JObject["Descripcion"] = "La materia no existe";
                    return JObject;
                }
            }
            catch (Exception e)
            {
                var CodigoError = new ErrorCode();
                var error = CodigoError.Error(e.ToString());
                JObject["Codigo"] = error;
                JObject["Descripcion"] = e.ToString();
                return JObject;
            }
        }

        public JObject GetAllSubjects()
        {
            var JObject = new JObject();

            try
            {
                var entity = repositorio.GetAll();

                if (entity != null)
                {
                    var json = JsonConvert.SerializeObject(entity);
                    var arrayr = JArray.Parse(json);
                    JObject["Codigo"] = "0000";
                    JObject["Descripcion"] = arrayr;
                    return JObject;
                }
                else
                {
                    JObject["Codigo"] = "0100";
                    JObject["Descripcion"] = "No existen materias actualmente.";
                    return JObject;
                }
            }
            catch (Exception e)
            {
                var CodigoError = new ErrorCode();
                var error = CodigoError.Error(e.ToString());
                JObject["Codigo"] = error;
                JObject["Descripcion"] = e.ToString();
                return JObject;
            }
        }

        public JObject UpdateSubject(Materia materia)
        {
            var JObject = new JObject();
            try
            {
                var matter = repositorio.GetByID(materia.IdMateria);
                if (matter != null)
                {
                    matter.Nombres = materia.Nombres;
                    matter.Docente = materia.Docente;
                    matter.Codigo = materia.Codigo;
                    matter.Descripcion = materia.Descripcion;
                    repositorio.Update(matter);
                    repositorio.Save();
                    JObject["Codigo"] = "0000";
                    JObject["Descripcion"] = "Registro modificado correctamente";
                    return JObject;
                }
                else
                {
                    JObject["Codigo"] = "0100";
                    JObject["Descripcion"] = "La materia no existe" + materia.IdMateria + materia.Nombres;
                    return JObject;
                }

            }
            catch (Exception e)
            {
                var cod = new ErrorCode();
                var codigoError = cod.Error(e.ToString());
                JObject["Codigo"] = codigoError;
                JObject["Descripcion"] = e.ToString();
                return JObject;
            }
        }

    }
}
