namespace AraVirtualTour.Models 
{
    public class useraccounts
    {
        public int ID {get; set;}

        [Required(ErrorMessage = "Username is Required")]
        [StringLength(maximumLength:100, MinimumLength = 2)]
        public string? Username {get; set;}

        [Required(ErrorMessage = "Password is Required")]
        [StringLength(maximumLength: 16, MinimumLength = 8)]
        public string? Password {get; set;}


    }
}