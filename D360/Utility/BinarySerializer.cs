using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace D360.Utility
{
    public static class BinarySerializer
    {
        public static void SaveObject<TObject>(TObject bindings, string path)
        {
            var bindingsFileStream =
                new FileStream(Application.StartupPath + @"\" + path, FileMode.Create);
            var bindingsBinaryFormatter = new BinaryFormatter();

            bindingsBinaryFormatter.Serialize(bindingsFileStream, bindings);
            bindingsFileStream.Close();
        }

        public static void LoadObject<TObject>(ref TObject loadObject, string path)
        {
            var bindingsFileStream =
                new FileStream(Application.StartupPath + @"\" + path, FileMode.Open);
            var bindingsBinaryFormatter = new BinaryFormatter();

            loadObject = (TObject)bindingsBinaryFormatter.Deserialize(bindingsFileStream);
            bindingsFileStream.Close();
        }
    }
}
