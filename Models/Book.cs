namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Book")]
    public partial class Book
    {
      

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "ID không được để trống")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Tiêu đề không được để trống")]
        [StringLength(100,ErrorMessage = "Tiêu đề không quá 100 ký tự!")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Mô tả không được để trống")]
        [StringLength(255)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Tác giả không được để trống")]
        [StringLength(30, ErrorMessage = "Tên tác giả không quá 30 ký tự!")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Hình ảnh không được để trống")]
        [StringLength(255)]
        public string Images { get; set; }

        [Required(ErrorMessage = "Giá không được để trống")]
        [Range(1000,1000000,ErrorMessage = "Giá sách từ 1000 đến 1000000!")]
        public int? Price { get; set; }
        public Book(int iD, string title, string description, string author, string images, int? price)
        {
            ID = iD;
            Title = title;
            Description = description;
            Author = author;
            Images = images;
            Price = price;
        }

        public Book()
        {
        }
    }
}
