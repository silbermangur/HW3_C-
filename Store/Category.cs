using Store;

public class Category : BaseEntity
{
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
    }
    public Category(string name) : this(name, string.Empty){ }
   
    public Category() : this("Default Category", string.Empty){}

   
    #endregion
    private int CalculateDepthLevel()
    {
        int depth = 0;
        Category parent = GetParentCategory();
        while (parent != null)
        {
            depth++;
            parent = parent.GetParentCategory();
        }
        return depth;
    }

    private Category GetParentCategory()
    {
        if (string.IsNullOrEmpty(ParentCategoryId))
        {
            return null;
        }
        // Logic to get parent category based on ParentCategoryId
        return this;
    }

    public override string ToString()
    {
        return $"Name: {Name}, ParentCategoryId: {ParentCategoryId}, DepthLevel: {DepthLevel}";
    }
}