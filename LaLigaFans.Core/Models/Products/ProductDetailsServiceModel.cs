using LaLigaFans.Core.Models.Comment;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace LaLigaFans.Core.Models.Products
{
    public class ProductDetailsServiceModel : ProductServiceModel
    {
        [Display(Name = "Units Available")]
        public int UnitsAvailable { get; set; }

        public string Description { get; set; } = null!;

        public IEnumerable<CommentServiceModel> Comments { get; set; } = null!;

        public CommentFormModel CommentForm { get; set; } = null!;

    }
}
