using System.ComponentModel.DataAnnotations;

namespace PaltformService.DTOs
{
    public class PlatformPublishDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Event { get; set; }
    }
}
