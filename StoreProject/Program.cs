using AutoMapper;
using DAL.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreProject
{
    class Program
    {
        private static IMapper _mapper = setupMapper();
        private static IMapper setupMapper()
        {
            MapperConfiguration config = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(GoodsDAL).Assembly)
                );
            return config.CreateMapper();
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("     ~~~Store~~~");
                Console.WriteLine(" Please choose an action:");
                Console.WriteLine("1 -- Create new goods");
                Console.WriteLine("2 -- Read all goods");
                Console.WriteLine("3 -- Update goods info");
                Console.WriteLine("4 -- Delete goods");
                Console.WriteLine(" ");
                Console.WriteLine("a -- Create new category");
                Console.WriteLine("b -- Read all categories");
                Console.WriteLine("c -- Update category info");
                Console.WriteLine("d -- Delete category");
                Console.WriteLine(" ");
                Console.WriteLine("e -- exit");

                char c = char.Parse(Console.ReadLine());

                switch (c)
                {
                    case '1':
                        CreateNewGoods();
                        break;
                    case '2':
                        ReadAllGoods();
                        break;
                    case '3':
                        UpdateOneGoods();
                        break;
                    case '4':
                        DeleteOneGoods();
                        break;
                    case 'a':
                        CreateNewCategory();
                        break;
                    case 'b':
                        ReadAllCategories();
                        break;
                    case 'c':
                        UpdateOneCategory();
                        break;
                    case 'd':
                        DeleteOneCategory();
                        break;


                    case 'e':
                        return;
                }
            }
        }

        private static void CreateNewGoods()
        {
            Console.WriteLine("Enter CategoryID of the goods: ");
            int categoryId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter name of the goods: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the goods color: ");
            string color = Console.ReadLine();
            Console.WriteLine("Enter price of the goods: ");
            double price = Convert.ToDouble(Console.ReadLine());

            var dal = new GoodsDAL(_mapper);
            var goods = new GoodsDTO
            {
                CategoryID = categoryId,
                Name = name,
                Color = color,
                Price = price
            };
            goods = dal.CreateGoods(goods);
            Console.WriteLine($"New goods ID: {goods.GoodsID}");
        }

        private static void ReadAllGoods()
        {
            var dal = new GoodsDAL(_mapper);
            var goods_a = dal.GetAllGoods();
            Console.WriteLine($"Goods ID\tCategory ID\tName\tColor\tPrice");
            foreach (var goods in goods_a)
            {
                Console.WriteLine($"{goods.GoodsID}\t{goods.CategoryID}\t{goods.Name}\t{goods.Color}\t{goods.Price}");
            }
        }

        private static void UpdateOneGoods()
        {
            throw new NotImplementedException();
        }

        private static void DeleteOneGoods()
        {
            throw new NotImplementedException();
        }

        private static void CreateNewCategory()
        {
            Console.WriteLine("Enter name of the category: ");
            string name = Console.ReadLine();

            var dal = new CategoryDAL(_mapper);
            var category = new CategoryDTO
            {
                Name = name
            };
            category = dal.CreateCategory(category);
            Console.WriteLine($"New category ID: {category.CategoryID}");
        }

        private static void ReadAllCategories()
        {
            var dal = new CategoryDAL(_mapper);
            var categories = dal.GetAllCategories();
            Console.WriteLine($"Category ID\tName");
            foreach (var category in categories)
            {
                Console.WriteLine($"{category.CategoryID}\t{category.Name}");
            }
        }

        private static void UpdateOneCategory()
        {
            throw new NotImplementedException();
        }

        private static void DeleteOneCategory()
        {
            throw new NotImplementedException();
        }
    }
}
