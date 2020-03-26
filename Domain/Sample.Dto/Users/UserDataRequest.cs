using Sample.Core.Common;

namespace Sample.Dto.Users
{
    public class UserDataRequest
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
    }
}