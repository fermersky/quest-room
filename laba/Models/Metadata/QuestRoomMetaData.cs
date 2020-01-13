using laba.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace laba.Models.Metadata
{
    [MetadataType(typeof(QuestRoomMetaData))]
    public partial class QuestRoom : IEntity
    {
        public int Id { get; set; }
    }


    public class QuestRoomMetaData
    {
        [Required]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(20)]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(255)]
        public string Description { get; set; }

        [Required(AllowEmptyStrings = false)]
        [MaxLength(1)]
        public string DurationTime { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Range(1, 10)]
        public int MinPlayersCount { get; set; }

        [Required]
        [Range(1, 10)]
        public int MaxPlayersCount { get; set; }

        [Required]
        public List<string> PhoneNumbers { get; set; }

        [Required]
        [Range(1, 10)]
        public int FearLevel { get; set; }

        [Required]
        [Range(1, 10)]
        public int Difficulty { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string LogoPath { get; set; }
    }
}