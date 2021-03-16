using System; 
using System.IO; 
using System.Xml.Linq; 
using System.Xml.Serialization; 
 
namespace LibXML{
    /// <summary>
    /// Класс для работы с XML файлами
    /// </summary>
    public static class Xml
    {
        /// <summary>         
        /// XML-сереализация объекта         
        /// </summary>        
        /// <typeparam name="T">Тип объекта</typeparam>        
        /// <param name="source">Сереализуемый объект</param>         
        /// <returns>XML-документ</returns>         
        public static XDocument Serelialize<T>(T source)         
        {             
            if (source == null) throw new ArgumentNullException("source не должен быть null"); 
 
            // Создаем объект для потокового чтения/записи в память (RAM)             
            // Используем оператор using, чтобы гарантировать освобождение памяти из под этого объекта             
            using (var stream = new MemoryStream())            
            {                 
                // Создаем сериализатор для типа T                 
                var ser = new XmlSerializer(typeof(T));                 
                // Сериализуем объект в память                 
                ser.Serialize(stream, source);                 
                // Перемещаем курсор в начало                 
                // Так как запись происходит порциями,                 
                // то крусор все время перемещается в конец записанной порции,                 
                // чтобы следующая порция не переписала записывалась дальше                 
                stream.Position = 0;                 
                // Создаем XML-документ из потока                 
                return XDocument.Load(stream);            
            }         
        } 
 
        /// <summary>         
        /// XML-десереализация объекта         
        /// </summary>         
        /// <typeparam name="T">Тип получаемого объекта</typeparam>        
        /// <param name="source">Сереализуемый объект</param>         
        /// <returns>Объект типа <typeparamref name="T"/></returns>         
        public static T Deserelialize<T>(XDocument source)         
        {             
            // Создаем объект для потокового чтения из XML-документа             
            // Используем оператор using, чтобы гарантировать освобождение памяти из под этого объекта             
            using (var stream = source.CreateReader())             
            {                 
                // Создаем сериализатор для типа T                 
                var ser = new XmlSerializer(typeof(T));                 
                // Десериализуем память в объект 
                return (T)ser.Deserialize(stream);             
            }        
        } 
 
        /// <summary>         
        /// Загрузка объекта из XML-файла         
        /// </summary>         
        /// <typeparam name="T">Тип объекта</typeparam>         
        /// <param name="path">Путь к XML-файлу</param>         
        /// <returns>Объект типа <typeparamref name="T"/></returns>         
        public static T LoadObjectFromFile<T>(string path)         
        {             
            // Создаем XML-документ из текстового файла            
            var xml = XDocument.Load(path);             
            // Десериализуем XML-документ в объект             
            return Deserelialize<T>(xml);         
        } 
 
        /// <summary>         
        /// Загрузка объекта из XML-строки         
        /// </summary>         
        /// <typeparam name="T">Тип объекта</typeparam>         
        /// <param name="textXml">XML в виде строки</param>        
        /// <returns>Объект типа <typeparamref name="T"/></returns>         
        public static T LoadObjectFromString<T>(string textXml)        
        {             
            // Создаем XML-документ из текста             
            var xml = XDocument.Parse(textXml);             
            // Десериализуем XML-документ в объект             
            return Deserelialize<T>(xml);         
        }    
    } 
} 