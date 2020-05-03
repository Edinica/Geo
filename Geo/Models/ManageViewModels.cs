using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Geo.Models
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать символов не менее: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение нового пароля")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Текущий пароль")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать символов не менее: {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Новый пароль")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение нового пароля")]
        [Compare("NewPassword", ErrorMessage = "Новый пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }
    }


    public class ChangeLogin
    {
        [Required]
        [Display(Name = "Текущий логин")]
        public string OldLogin { get; set; }

        [Required]
        [Display(Name = "Новый логин")]
        public string NewLogin { get; set; }
    }


    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Номер телефона")]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

    public class Point
    {
        public int PointId { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int? FloorId { get; set; }
        public Floor Floor { get; set; }
        public List<Point> points { get; set; }
    }
public class Floor
{
    public int Id { get; set; }
    public string Description { get; set; }
    public int Level { get; set; }
    public int? BuildingId { get; set; }
    public Building Building { get; set; }
    public ICollection<Point> Points { get; set; }
    public Floor()
    {
        Points = new List<Point>();
    }
        public Floor(string Description, int Level, int? BuildingId) 
        {
            this.Description = Description;
            this.Level = Level;
            this.BuildingId = BuildingId;
        }

        public Floor(string Description, int Level)
        {
            this.Description = Description;
            this.Level = Level;
        }

    }
    
    public class Building
    {
        public int Id { get; set; }
        public string Nameof { get; set; }
        public string Address { get; set; }
        public ICollection<Floor> Floors { get; set; }
        public Building()
        {
            Floors = new List<Floor>();
        }
        public Building(string Nameof, string Address, ICollection<Floor> Floors) 
        {

            this.Nameof = Nameof;
            this.Address = Address;
            foreach (var element in Floors) 
            {
                element.BuildingId = this.Id;
            }
            this.Floors = Floors;
        }

        public Building(string Nameof, string Address)
        {
            this.Nameof = Nameof;
            this.Address = Address;
        }
    }
    public class MapRedactor
    {

    }
    public class UserEditer
    {

    }
}