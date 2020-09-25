using System;
using System.ComponentModel.DataAnnotations;
using Blazor30days.Attributes;
using Blazor30days.Enums;

namespace Blazor30days.Model
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "名字欄位為必填！")]
        [StringLength(10, ErrorMessage = "名字太長啦！", MinimumLength = 5)]
        public string Name { get; set; }

        [Range(1, 200, ErrorMessage = "抱歉，本系統會員只能一到兩百歲使用。")]
        public int? Age { get; set; }

        [RegularExpression(@"^09\d{8}$", ErrorMessage = "電話格式錯誤！")]
        public string Phone { get; set; }

        [EmailAddress(ErrorMessage = "信箱格式錯誤！")]
        public string Email { get; set; }

        [MemberRequired(ErrorMessage = "會員需要填寫地址？")]
        public string Address { get; set; }

        public UserType UserType { get; set; }

        public DateTime StartDate { get; set; }

        [AfterThat(nameof(StartDate))]
        public DateTime EndDate { get; set; }
    }
}