using System.ComponentModel.DataAnnotations;

namespace BOTCDatabase.Models
{
    public class Role
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string Name { get; set; } = string.Empty;
        [Display(Name = "Icon")]
        public string ImagePath { get; set; } = "/images/icons/Townsfolk/Amnesiac.png";
		public string DescPath { get; set; } = "/txts/desciptions/Townsfolk/Amnesiac.txt";
		public string TipsPath { get; set; } = "/images/tips/Townsfolk/Amnesiac.txt";

		public CharacterType Type { get; set; }
        [Display(Name="First Night Order")]
        public int FirstNightOrder { get; set; }
        [Display(Name = "Other Night Order")]
        public int OtherNightOrder { get; set; }
        [Display(Name = "First Night Reminder")]
        [StringLength(500)]
        public string FirstNightReminder { get; set; } = string.Empty;
        [Display(Name = "Other Night Reminder")]
        [StringLength(500)]
        public string OtherNightReminder { get; set; } = string.Empty;
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        public IList<string> ReminderTokens { get; set; } = new List<string>();
        public IList<KeyEffects> Effects { get; set; } = new List<KeyEffects>();


    }
}
