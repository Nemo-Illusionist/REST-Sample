using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Radilovsoft.Rest.Data.Core.Contract.Entity;
using Radilovsoft.Rest.Data.Ef.Annotation;
using Sample.Db.Model.App;

namespace Sample.Db.Model.Client
{
    [Table("user", Schema = DbSchemeConstant.Client)]
    public class User : IEntity<Guid>, ICreatedUtc, IUpdatedUtc, IDeletable
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Index(isUnique: true)]
        public string Login { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [Required]
        public byte[] Salt { get; set; }

        public Guid SecurityTimestamp { get; set; }

        [Index]
        public DateTime CreatedUtc { get; set; }

        public DateTime UpdatedUtc { get; set; }

        [Index]
        public DateTime? DeletedUtc { get; set; }

        
        public UserData UserData { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<Test> Tests { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
    }
}