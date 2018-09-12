using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StringParserAssignment.Models
{
    public class StringParserViewModel
    {
        [DisplayName("Enter input:")]
        [Required]
        public string InputText { get; set; }

        [DisplayName("Output:")]
        public string ParsedOutputText { get; set; }

        [DisplayName("Select parser type:")]
        [Required]
        public string[] Parsers { get; set; }
    }
}