using Store;


namespace main
{
    public class Program
    {
        static void Main(string[] args)
        {
            Product p1 = new Product();
            Category c1 = new Category("Italic",""); // root
            Category c2 = new Category("franch", ""); // root
            Category c3 = new Category("pizza", "Italic");
            Category c4 = new Category("Onine", "pizza");
            Category c5 = new Category("Onine", "franch");



            Console.WriteLine(p1);
            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);
            Console.WriteLine(c4);
            Console.WriteLine(c5);
        }
    }
}
