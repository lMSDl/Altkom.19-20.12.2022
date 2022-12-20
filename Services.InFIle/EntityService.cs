using Models;
using Newtonsoft.Json;
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
            var json = File.ReadAllText(_path);

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

        private void SaveData()
        {
            var json = JsonConvert.SerializeObject(_entities);

            File.WriteAllText(_path, json);

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