using System;
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
            formatter = new XmlSerializer(typeof(T[]));
        }
        public void Write(string filename, T data)
        {
            T[] records = Read(filename);
            if (records != null) records[records.Length] = data;
            else
            {
                T[] rc = { data };
                records = rc;
            }
            WriteA(filename, records);
        }
        private void WriteA(string filename, T[] data)
        {
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
                fs.Close();
            }
        }
        public T[] Read(string filename)
        {
            T[] data;
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    data = (T[])formatter.Deserialize(fs);
                }
                catch(System.InvalidOperationException e)
                {
                    fs.Close();
                    return default(T[]);
                }
                fs.Close();
            }
            return data;
        }
        public void RemoveId(string filename, int id)
        {
            T[] records = Read(filename);
            records[id] = default(T);
            if (records.Length > id + 1)
            {
                for(int i = id + 1; i < records.Length; i++)
                {
                    records[i - 1] = records[i];
                    records[i] = default(T);
                }
            }
            
        }
    }
}
