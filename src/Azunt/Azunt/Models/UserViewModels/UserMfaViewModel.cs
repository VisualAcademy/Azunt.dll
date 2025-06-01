namespace Azunt.Models.UserViewModels
{
    /// <summary>
    /// MFA 설정에 필요한 사용자 정보만 포함하는 ViewModel
    /// </summary>
    public class UserMfaViewModel
    {
        public string Email { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; } = string.Empty;
        public bool PhoneNumberConfirmed { get; set; }

        public bool TwoFactorEnabled { get; set; }
    }
}
