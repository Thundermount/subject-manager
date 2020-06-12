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
            formatter = new XmlSerializer(typeof(T));
        }
        public void Write(string filename, object data)
        {
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, data);
                fs.Close();
            }
        }
        public T Read(string filename)
        {
            T data;
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                try
                {
                    data = (T)formatter.Deserialize(fs);
                }
                catch(System.InvalidOperationException e)
                {
                    fs.Close();
                    return default(T);
                }
                fs.Close();
            }
            return data;
        }
    }
}
