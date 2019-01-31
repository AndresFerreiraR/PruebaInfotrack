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
    public class NotasService : INotasService
    {
        static ModelContext _contexto = new ModelContext();
        GenericRepository<Notas> repositorio = new GenericRepository<Notas>(_contexto);
        public JObject CreateScore(Notas notas)
        {
            var JObject = new JObject();
            try
            {

                var score = new Notas
                {
                    IdEstudiante = notas.IdEstudiante,
                    IdMateria = notas.IdMateria,
                    Nota = notas.Nota,
                    Descripcion = notas.Descripcion
                };
                repositorio.Insert(score);
                repositorio.Save();
                JObject["Codigo"] = "0000";
                JObject["Descripcion"] = "Nota registrada correctamente" + notas.IdNota;
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

        public JObject DeleteScore(Notas notas)
        {
            var JObject = new JObject();
            try
            {
                var score = repositorio.GetByID(notas.IdNota);
                if (score != null)
                {
                    var idScore = notas.IdNota;
                    repositorio.Delete(score);
                    repositorio.Save();
                    JObject["Codigo"] = "0000";
                    JObject["Descripcion"] = idScore;
                    return JObject;
                }
                else
                {
                    JObject["Codigo"] = "0100";
                    JObject["Descripcion"] = "No existen notas";
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

        public JObject GetAllScores()
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
                    JObject["Descripcion"] = "No existen notas actualmente.";
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

        public JObject UpdateScore(Notas notas)
        {
            var JObject = new JObject();
            try
            {
                var score = repositorio.GetByID(notas.IdNota);
                if (score != null)
                {
                    score.IdEstudiante = notas.IdEstudiante;
                    score.IdMateria = notas.IdMateria;
                    score.Nota = notas.Nota;
                    score.Descripcion = notas.Descripcion;
                    repositorio.Update(score);
                    repositorio.Save();
                    JObject["Codigo"] = "0000";
                    JObject["Descripcion"] = "Registro modificado correctamente";
                    return JObject;
                }
                else
                {
                    JObject["Codigo"] = "0100";
                    JObject["Descripcion"] = "La nota no existe" + notas.IdNota + notas.Nota;
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
