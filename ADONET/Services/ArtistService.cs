using ADONET.Abstractions;
using ADONET.Helper;
using ADONET.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET.Services
{
    internal class ArtistService : IService<Artist>
    {
        public void Add(Artist model)
        {
            Sql.ExecCommand($"insert into Artists values ('{model.Name}',{model.Surname},{model.Birthday},{model.Gender})");

        }

        public void Delete(int Id)
        {
            Sql.ExecCommand($"delete Artists where ID={Id}");

        }

        public List<Artist> GetAll()
        {
            DataTable dt1 = Sql.ExecQuery("SELECT*FROM Artists");
            List<Artist> list1 = new List<Artist>();
            foreach (DataRow dr in dt1.Rows)
            {
                Artist artist = new Artist
                (
                    Convert.ToInt32(dr["ID"]),
                    dr["Name"].ToString(),
                   dr["Surname"].ToString(),
                   Convert.ToDateTime(dr["Birthday"]),
                   dr["Gender"].ToString()
                 );
                list1.Add(artist);
            }
            return list1;
        }

        public Artist GetById(int Id)
        {
            DataTable dt = Sql.ExecQuery($"SELECT*FROM Artists WHERE ID={Id}");
            DataRow dr = dt.Rows[0];
            Artist artist = new Artist
                 (
                     Convert.ToInt32(dr["ID"]),
                    dr["Name"].ToString(),
                   dr["Surname"].ToString(),
                   Convert.ToDateTime(dr["Birthday"]),
                   dr["Gender"].ToString()
                  );
            return artist;
        }


        public void Update(Artist model)
        {
            Console.WriteLine("Neyi deyishmek isteyirsiniz:\n1.Name\n2.Surname\n3.Birthday\n4.Gender");
            int choise = Convert.ToInt16(Console.ReadLine());
            switch (choise)
            {
                case 1:
                    Console.WriteLine("New Name:");
                    string name = Console.ReadLine();
                    Sql.ExecCommand($"Update Artists Set name='{name}' where id={model.ID}");

                    break;
                case 2:
                    Console.WriteLine("New Surname:");
                    string sn = Console.ReadLine();
                    Sql.ExecCommand($"Update Artists Set surname='{sn}' where id={model.ID}");

                    break;
                case 3:
                    Console.WriteLine("New birthday:");
                    string date = Console.ReadLine();
                    DateTime dateTime = Convert.ToDateTime(date);
                    Sql.ExecCommand($"Update Artists Set birthday={dateTime} where id={model.ID}");

                    break;

                case 4:
                    Console.WriteLine("New Gender:");
                    string gender = Console.ReadLine();
                    Sql.ExecCommand($"Update Artists Set gender='{gender}' where id={model.ID}");

                    break;
                default:
                    Console.WriteLine("bele secim yoxdur");
                    break;
            }
        }
    }
}