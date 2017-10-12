using MyApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;

namespace MyApp.DataAccess
{
    public class JSONContext<T> where T : IEntity
    {
        private List<T> _items;
        private string _filePath;

        public JSONContext(string filePath)
        {
            _filePath = filePath;
            _items = new List<T>();
            LoadData();
        }

        public IEnumerable<T> GetAll()
        {
            return _items.OrderBy(i => i.Id).ToList();
        }

        #region CRUD operations

        public T Create(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = GetNewId();
            _items.Add(item);
            SaveChanges();
            return item;
        }

        public T Read(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public T Update(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            int index = _items.FindIndex(i => i.Id == item.Id);
            if (index == -1)
            {
                return default(T);
            }
            _items.RemoveAt(index);
            _items.Add(item);
            SaveChanges();
            return item;
        }

        public void Delete(int id)
        {
            _items.RemoveAll(i => i.Id == id);
            SaveChanges();
        }

        #endregion

        #region File operations

        private void LoadData()
        {
            var folder = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //get the Json filepath  
            string file = System.Web.Hosting.HostingEnvironment.MapPath(_filePath);
            if (!File.Exists(file))
            {
                // Create a file to write to.
                SaveChanges();
            }

            //deserialize JSON from file  
            string Json = File.ReadAllText(file);
            var ser = new JavaScriptSerializer();
            _items = ser.Deserialize<List<T>>(Json).OrderBy(i => i.Id).ToList();
        }

        private void SaveChanges()
        {
            //get the Json filepath  
            string file = System.Web.Hosting.HostingEnvironment.MapPath(_filePath);
            //deserialize JSON from file  
            var ser = new JavaScriptSerializer();
            var serializedResult = ser.Serialize(_items.OrderBy(i => i.Id).ToList());

            File.WriteAllText(file, serializedResult);
        }

        #endregion

        #region Helper

        private int GetNewId()
        {
            return _items.Any() ? _items.Max(i => i.Id) + 1 : 1;
        }

        #endregion

    }
}
