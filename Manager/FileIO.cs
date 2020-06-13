using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Manager
{
    // Я понимаю что возможно структура не лучший выбор
    // но мне давно хотелось попробовать
    struct FileIO<T>
    {
        static XmlSerializer formatter;
        static FileIO()
        {
            formatter = new XmlSerializer(typeof(List<T>));
        }
        public void Write(string filename, T data)
        {
            List<T> records = Read(filename);
            if (records != null) records.Add(data);
            else
            {
                records = new List<T>();
                records.Add(data);
            }
            WriteA(filename, records);
        }
        // Приватная функция которая записывает массив данных в файл
        private void WriteA(string filename, List<T> data)
        {
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
                fs.Close();
            }
        }
        public List<T> Read(string filename)
        {
            List<T> data;
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    data = (List<T>)formatter.Deserialize(fs);
                }
                catch(System.InvalidOperationException e)
                {
                    fs.Close();
                    return default(List<T>);
                }
                fs.Close();
            }
            return data;
        }
        // Удалить элемент по его id
        public void RemoveId(string filename, int id)
        {
            if (id == -1) return;
            List<T> records = Read(filename);
            File.Copy(filename, filename + ".backup",true);
            File.Delete(filename);
            records.RemoveAt(id);
            WriteA(filename,records);
            
        }
    }
}
