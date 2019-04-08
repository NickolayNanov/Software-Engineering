using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Positions
{
    public class CreatePositionInputModel
    {
        [MinLength(3)]
        [MaxLength(30)]
        public string PositionName { get; set; }
    }
}
