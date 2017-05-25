using System.ComponentModel.DataAnnotations;

namespace AccountSystem.Entities
{
    public class ImageModelBase: EntityBase
    {
        [DataType(DataType.ImageUrl), StringLength(255)]
        public string OriginalUrl { get; set; }

        [DataType(DataType.ImageUrl), StringLength(255)]
        public string SmUrl { get; set; }

        [DataType(DataType.ImageUrl), StringLength(255)]
        public string MdUrl { get; set; }

        [DataType(DataType.ImageUrl), StringLength(255)]
        public string LgUrl { get; set; }
    }
}
