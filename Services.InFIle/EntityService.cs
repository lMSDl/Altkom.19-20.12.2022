using Models;
using Newtonsoft.Json;
using Services.InFile.Encryption;
using Services.Interfaces;
using System.Text;
using System.Text.Json.Serialization;

namespace Services.InFile
{
    public class EntityService<T> : InMemory.EntityService<T> where T : Entity
    {
        private string _path;

        public EntityService(string path)
        {
            _path = path;

            _entities = LoadData();
        }


        private ICollection<T> LoadData()
        {
            var bytes = File.Exists(_path) ?  File.ReadAllBytes(_path) : null;

            string json = string.Empty;
            if(bytes != null)
            {
                json = _encryption.DecryptToString(bytes, "ma kota");
            }

            //var json = File.Exists(_path) ? File.ReadAllText(_path) : "";


            /*
            //wykorzustanie using spowoduje automatyczne wywołanie funkcji Dispose
            using var fileStream = new FileStream(_path, FileMode.OpenOrCreate);
            using var streamReader = new StreamReader(fileStream);
            string json = streamReader.ReadToEnd();
            //streamReader.Dispose();
            //fileStream.Dispose();
            */
            var result = JsonConvert.DeserializeObject<ICollection<T>>(json);
            return result ?? new List<T>();
        }

        private SymmetricEncryption _encryption = new SymmetricEncryption("ala"); 

        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(_entities);
            var bytes = _encryption.Encrypt(json, "ma kota");

            File.WriteAllBytes(_path, bytes);
            
            //File.WriteAllText(_path, json);

            /* 
            using var fileStream = new FileStream(_path, FileMode.Create);
            byte[] bytes = Encoding.Default.GetBytes(json);

            fileStream.Write(bytes, 0, bytes.Length);
            //metoda flush wymusza wypchnięcie danych do strumienia
            fileStream.Flush();
            */

        }

        //override - nadpisujemy implementację funkcji wirtualnej lub abstrakcyjnej
        public override void Update(int id, T entity)
        {
            //base - owołujemy się do implementacji klasy bazowej
            base.Update(id, entity);

            SaveData();
        }

        public override int Create(T entity)
        {
            var result =  base.Create(entity);
            SaveData();
            return result;
        }

        public override bool Delete(int id)
        {
            var result =  base.Delete(id);
            if(result)
                SaveData();
            return result;
        }

    }
}