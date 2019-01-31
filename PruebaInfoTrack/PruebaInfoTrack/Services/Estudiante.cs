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
    public class Estudiante : IEstudiante
    {

        static ModelContext _contexto = new ModelContext();
        GenericRepository<Alumno> repositorio = new GenericRepository<Alumno>(_contexto);

        public JObject GetAllStudents()
        {
            var JObject = new JObject();

            try
            {
                var entity = repositorio.GetAll();

                if (entity != null || entity.Count() > 0)
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
                    JObject["Descripcion"] = "Alumno no existe";
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

        public JObject CreateStudent(Alumno alumno)
        {
            var JObject = new JObject();
            try
            {

                var student = new Alumno

                {
                    Nombres = alumno.Nombres,
                    Apellidos = alumno.Apellidos,
                    Identificacion = alumno.Identificacion,
                    Telefono = alumno.Telefono,
                    Correo = alumno.Correo,
                };
                repositorio.Insert(student);
                repositorio.Save();
                JObject["Codigo"] = "0000";
                JObject["Descripcion"] = "Alumno Creado Correctamente" + student.IdAlumno;
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

        public JObject DeleteStudent(Alumno alumno)
        {
            var JObject = new JObject();
            try
            {
                var student = repositorio.GetByID(alumno.IdAlumno);
                if (student != null)
                {
                    var idStudent = alumno.IdAlumno;
                    repositorio.Delete(student);
                    repositorio.Save();
                    JObject["Codigo"] = "0000";
                    JObject["Descripcion"] = idStudent;
                    return JObject;
                }
                else
                {
                    JObject["Codigo"] = "0100";
                    JObject["Descripcion"] = "No se encontro alumno";
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

        public JObject UpdateStudent(Alumno alumno)
        {
            var JObject = new JObject();
            try
            {
                var student = repositorio.GetByID(alumno.IdAlumno);
                if (student != null)
                {
                    student.Nombres = alumno.Nombres;
                    student.Apellidos = alumno.Apellidos;
                    student.Identificacion = alumno.Identificacion;
                    student.Telefono = alumno.Telefono;
                    student.Correo = alumno.Correo;
                    repositorio.Update(student);
                    repositorio.Save();
                    JObject["Codigo"] = "0000";
                    JObject["Descripcion"] = "Registro modificado correctamente";
                    return JObject;
                }
                else
                {
                    JObject["Codigo"] = "0100";
                    JObject["Descripcion"] = "El alumno no existe" + student.IdAlumno;
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
