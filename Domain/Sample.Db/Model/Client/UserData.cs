using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Radilovsoft.Rest.Data.Core.Contract.Entity;
using Sample.Core.Common;

namespace Sample.Db.Model.Client
{
    [Table("user_data", Schema = DbSchemeConstant.Client)]
    public class UserData : IUpdatedUtc, IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }
        
        public DateTime UpdatedUtc { get; set; }

        [ForeignKey(nameof(Id))]
        public User User { get; set; }
    }
}