using System;
using Sample.Core.Common;

namespace Sample.Dto.Users
{
    public class UserDataFullResponse : UserDataResponse
    {
        public Gender Gender { get; set; }
        public DateTime CreatedUtc { get; set; }
        public DateTime UpdatedUtc { get; set; }
    }
}