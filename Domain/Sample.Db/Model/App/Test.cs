using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Radilovsoft.Rest.Data.Core.Contract.Entity;
using Radilovsoft.Rest.Data.Ef.Annotation;
using Sample.Db.Model.Client;

namespace Sample.Db.Model.App
{
    [Table("test", Schema = DbSchemeConstant.App)]
    public class Test : ICreatedUtc, IUpdatedUtc, IDeletable, IEntity<Guid>
    {
        [Key]
        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }

        [Index]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Index]
        public DateTime CreatedUtc { get; set; }

        public DateTime UpdatedUtc { get; set; }

        [Index]
        public DateTime? DeletedUtc { get; set; }

        
        [ForeignKey(nameof(AuthorId))]
        public User Author { get; set; }

        public ICollection<TestTopic> TestTopics { get; set; }
    }
}