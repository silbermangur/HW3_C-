using Store;


namespace main
{
    public class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product();
            p1.ParentCategoryId = "1";
            Category c1 = new Category("food","0");
            Category c2 = new Category("sub-food","1");
            c2.ParentCategoryId = "0";

            Console.WriteLine(p1);
            Console.WriteLine(c1);
            Console.WriteLine(c2);
        }
    }
}
