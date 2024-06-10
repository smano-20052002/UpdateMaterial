namespace LXP.Common.ViewModels
{
    public class LoginRole
    {

        public bool Email { get; set; }
        public string LearnerId { get; set; }
        public bool Password { get; set; }

        public string? Role { get; set; }


        public bool AccountStatus { get; set; }

        public DateTime LastLogin { get; set; }



    }
}
