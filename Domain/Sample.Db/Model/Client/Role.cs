using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Radilovsoft.Rest.Data.Core.Contract.Entity;
using Radilovsoft.Rest.Data.Ef.Annotation;

namespace Sample.Db.Model.Client
{
    [Table("role", Schema = DbSchemeConstant.Client)]
    public class Role : IEntity<Guid>, ICreatedUtc
    {
        [Key]
        [AutoIncrement]
        public Guid Id { get; set; }

        [Required]
        [Index(isUnique: true)]
        public string Name { get; set; }

        [Index]
        public DateTime CreatedUtc { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}