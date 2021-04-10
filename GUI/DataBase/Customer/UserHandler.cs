using GUI.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;



namespace GUI.DataBase
{
    class UserHandler
    {
        protected List<DBUser> records = new List<DBUser>();
        string filename = "";



        public async Task write(DBUser t)
        {
            var res = await GetAllAsync();
            res.Add(t);
            string stringObj = JsonSerializer.Serialize(res);
            using (StreamWriter sw = new StreamWriter(filename))
            {
                await sw.WriteAsync(stringObj);
            }



            //await File.WriteAllTextAsync(@"C:\study\2_year_of_study\c#\cs_project\GUI\DataBase\Customer\customers.json", json);
        }

        public async Task<List<DBUser>> GetAllAsync()
        {
            var res = new List<DBUser>();
            string t = "";
            using (StreamReader streamReader = new StreamReader(filename))
            {
                t = await streamReader.ReadToEndAsync();
            }

            res = JsonSerializer.Deserialize<List<DBUser>>(t);

            return res;
        }
        public string Filename { get => filename; set => filename = value; }
        public async Task<List<DBUser>> Find(string key)
        {
            var res = new List<DBUser>();
            string t = "";
            using (StreamReader streamReader = new StreamReader(filename))
            {
                t = await streamReader.ReadToEndAsync();
            }

            
            res = JsonSerializer.Deserialize<List<DBUser>>(t);
            
            foreach (var u in res
                .Where(obj => obj.Login == key))
            {
                //MessageBox.Show((string)u["FirstName"]);
                records.Add(u);
            }
            return records;
        }     
    }
}
