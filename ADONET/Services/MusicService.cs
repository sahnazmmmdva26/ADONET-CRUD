using ADONET.Abstractions;
using ADONET.Helper;
using ADONET.Models;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET.Services
{
    internal class MusicService : IService<Music>
    {
        public void Add(Music model)
        {
            Sql.ExecCommand($"INSERT INTO Musics VALUES ('{model.Name}',{model.Duration},{model.CategoriesId},NULL)");
        }

        public void Delete(int Id)
        {
            Sql.ExecCommand($"delete Musics where ID={Id}");
        }

        public List<Music> GetAll()
        {
            DataTable dt = Sql.ExecQuery("SELECT*FROM Musics");
            List<Music> list = new List<Music>();
            foreach (DataRow dr in dt.Rows)
            {
                Music music = new Music
                (
                   Convert.ToInt32(dr["ID"]),
                   dr["Name"].ToString(),
                   Convert.ToInt32(dr["Duration"]),
                   Convert.ToInt32(dr["CategoriesId"]),
                   dr["DeletedTime"].ToString()
                 );
                list.Add(music);
            }
            return list;
        }

        public Music GetById(int Id)
        {
            DataTable dt = Sql.ExecQuery($"SELECT*FROM Musics WHERE ID={Id}");
            DataRow dr = dt.Rows[0];
            Music music = new Music
                 (
                    Convert.ToInt32(dr["ID"]),
                    dr["Name"].ToString(),
                    Convert.ToInt32(dr["Duration"]),
                    Convert.ToInt32(dr["CategoriesId"]),
                    dr["DeletedTime"].ToString()
                  );
            return music;
        }

        public void Update(Music model)
        {
            Console.WriteLine("Neyi deyishmek isteyirsiniz:\n1.Name\n2.Duration\n3.Category Id");
            int choise = Convert.ToInt16(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    Console.WriteLine("New Name:");
                    string name = Console.ReadLine();
                    Sql.ExecCommand($"Update Musics Set name='{name}' where id={model.ID}");
                    break;
                case 2:
                    Console.WriteLine("New Duration:");
                    int duration = Convert.ToInt16(Console.ReadLine());
                    Sql.ExecCommand($"Update Musics Set duration={duration} where id={model.ID}");

                    break;
                case 3:
                    Console.WriteLine("New Category Id:");
                    int categoryid = Convert.ToInt16(Console.ReadLine());
                    Sql.ExecCommand($"Update Musics Set categoriesid={categoryid} where id={model.ID}");

                    break;
                default:
                    Console.WriteLine("bele secim yoxdur");
                    break;
            }
          
        }

      
    }
}
