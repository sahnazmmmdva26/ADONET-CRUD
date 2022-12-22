using ADONET.context;
using ADONET.Helper;
using ADONET.Models;
using ADONET.Services;
using System.Net.Http.Headers;

namespace ADONET
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

            Context context = new Context();
            while (true)
            {
            Console.WriteLine("\nHansi Cedvel uzre islemek isteyirsiniz:");
            Console.WriteLine("1. Musics\n2. Artists");
            int num = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("1. Get All\n2. Get By İd\n3. Create\n4. Update\n5. Delete\n0. Exit");
            int num1=Convert.ToInt16(Console.ReadLine());
            switch (num)
            {
                case 1:
                    switch (num1)
                    {
                        case 1:
                            List<Music> list = context.Musics.GetAll();
                            foreach (var item in list)
                            {
                                Console.WriteLine($"ID={item.ID}  Name={item.Name}  Duration={item.Duration}  CategoryId={item.CategoriesId}  Deleted time={item.DeletedTime}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("ID-ni daxil edin:");
                            int id=Convert.ToInt16(Console.ReadLine());
                            Music item1 = context.Musics.GetById(id);
                            Console.WriteLine($"ID={item1.ID}  Name={item1.Name}  Duration={item1.Duration}  CategoryId={item1.CategoriesId}  Deleted time={item1.DeletedTime}");
                            break;
                        case 3:

                            Console.WriteLine("Name:");
                            string name=Console.ReadLine();
                            Console.WriteLine("Duration:");
                            int duration=Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Category id:");
                            int categoryId=Convert.ToInt32(Console.ReadLine());
                            List<Music> list1 = context.Musics.GetAll();
                            int max=0;
                            foreach (var item in list1)
                            {
                                if(item.ID>max)
                                {
                                    max=item.ID;
                                }
                            }
                            Music music = new Music(max, name, duration, categoryId, "");
                            context.Musics.Add(music);
                            break;
                        case 4:
                            Console.WriteLine("Id-ni daxil edin:");
                            int id2 = Convert.ToInt32(Console.ReadLine());
                            Music music1 = context.Musics.GetById(id2);
                            context.Musics.Update(music1);
                            break;
                        case 5:
                            Console.WriteLine("Id-ni daxil edin:");
                            int id1 = Convert.ToInt32(Console.ReadLine());
                            context.Musics.Delete(id1);
                            break;
                        case 0:
                            return;
                        default:
                            Console.WriteLine("bele secim yoxdur");
                            break;
                    }
                    break;
                case 2:
                    switch (num1)
                    {
                        case 1:
                            List<Artist> list = context.Artists.GetAll();
                            foreach (var item in list)
                            {
                                Console.WriteLine($"ID={item.ID}  Name={item.Name}  Surname={item.Surname} Birthday={item.Birthday} Gender={item.Gender}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("ID-ni daxil edin:");
                            int id = Convert.ToInt16(Console.ReadLine());
                            Artist item1 = context.Artists.GetById(id);
                            Console.WriteLine($"ID={item1.ID}  Name={item1.Name}  Surname={item1.Surname} Birthday={item1.Birthday} Gender={item1.Gender}");
                            break;
                        case 3:
                            Console.WriteLine("Name:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Surname:");
                            string surname = Console.ReadLine();
                            Console.WriteLine("Birthday date:");
                            string date = Console.ReadLine();
                            DateTime dateTime = Convert.ToDateTime(date);
                            Console.WriteLine("Gender:");
                            string gender = Console.ReadLine();
                            List<Artist> list1 = context.Artists.GetAll();
                            int max = 0;
                            foreach (var item in list1)
                            {
                                if (item.ID > max)
                                {
                                    max = item.ID;
                                }
                            }
                            Artist artist = new Artist(max, name, surname, dateTime,gender);
                            context.Artists.Add(artist);
                            break;
                           
                        case 4:
                            Console.WriteLine("Id-ni daxil edin:");
                            int id2 = Convert.ToInt32(Console.ReadLine());
                            Artist artist1 = context.Artists.GetById(id2);
                            context.Artists.Update(artist1);
                            break;
                        case 5:
                            Console.WriteLine("Id-ni daxil edin:");
                            int id1 = Convert.ToInt32(Console.ReadLine());
                            context.Artists.Delete(id1);
                            break;
                        case 0:
                            return ;
                        default:
                            Console.WriteLine("bele secim yoxdur");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("bele class yoxdur");
                    break;
            }

            }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
