using System;
using System.IO;
using UniversitySystem;

namespace Laboratory_2
{
    public static class FileManager
    {
        public static void FileAdd(Entity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (!entity.IsValid())
            {
                throw new Exception("Entity is invalid");
            }

            var record = entity.Info();

            using (var writer = new StreamWriter(entity.FileName, true))
            {
                writer.WriteLine(record);
            }
        }
    }
}