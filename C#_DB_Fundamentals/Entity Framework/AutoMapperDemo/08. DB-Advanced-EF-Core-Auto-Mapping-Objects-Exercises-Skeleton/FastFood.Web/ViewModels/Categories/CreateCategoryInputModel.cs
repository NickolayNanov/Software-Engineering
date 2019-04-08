namespace FastFood.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryInputModel
    {
        [MinLength(3)]
        [MaxLength(30)]
        public string CategoryName { get; set; }
    }
}
