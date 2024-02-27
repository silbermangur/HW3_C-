using Store;
using System.Runtime.CompilerServices;

public class Category : BaseEntity
{
    private static List<Category> ls = new List<Category>();

    #region -- Properties --
    public string Name { get; set; }
    public string ParentCategoryId { get; set; }
    public int DepthLevel => CalculateDepthLevel();
    #endregion

    #region --Constractor --
    public Category(string name, string parentCategoryId) : base()
    {
       
        Name = name;
        ParentCategoryId = parentCategoryId;
        ls.Add(this);
    }
    public Category(string name) : this(name, string.Empty){ }
   
    public Category() : this("Default Category", string.Empty){}


    #endregion


    public int CalculateDepthLevel()
    {
        Category c = new Category(this.Name, this.ParentCategoryId);
        int cnt = 0;
        while (c.ParentCategoryId != "")
        {
            foreach (Category c2 in ls)
            {
                if (c2.Name == c.ParentCategoryId)
                {
                    c = c2;
                    break;
                }
            }
            cnt++;

        }
        return cnt;
    }




    public override string ToString()
    {
        return $"Name: {Name}, ParentCategoryId: {ParentCategoryId}, deepLevel: {DepthLevel}";
    }
}