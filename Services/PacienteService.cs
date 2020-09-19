using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using backend.Models;
using MongoDB.Bson;
using MongoDB.Driver;


namespace backend.Service{

    public class PacienteService: ConnectionService{
        private readonly IMongoCollection<PacienteModel> _pacientes;

        public PacienteService(): base(){
            var database = client.GetDatabase("Medikapp");
            _pacientes = database.GetCollection<PacienteModel>("Paciente");
        }

        public async Task<List<PacienteModel> >  GetAll() {
            return await _pacientes.FindSync<PacienteModel> (new BsonDocument()).ToListAsync();
            
        }

        public List<PacienteModel> GetByName(string nombre){
            Console.WriteLine(nombre);

            var filter = Builders<PacienteModel>.Filter.Regex("nombre","/" + nombre +"/i");
            var cursor = _pacientes.Find(filter).ToCursor();

        return _pacientes.Find(filter).ToList();

             
        }
        
        public PacienteModel GetByID(int id_doctor) =>  _pacientes.Find<PacienteModel>(paciente => paciente.id_doctor == id_doctor).FirstOrDefault();
       
        
        
        public PacienteModel Create(PacienteModel paciente)
        {
            _pacientes.InsertOne(paciente);
            return paciente;
        }

        public async Task Update(int id_doctor, PacienteModel paciente)
        {
            await _pacientes.ReplaceOneAsync(pac => pac.id_doctor == id_doctor, paciente);
        }
        public void Remove(PacienteModel paciente)
        {
            _pacientes.DeleteOne(pac => pac.id_doctor ==   paciente.id_doctor );
        }

        public void Remove(int id_doctor)
        {
            _pacientes.DeleteOne(pac => pac.id_doctor == id_doctor);
        }
    }
}
