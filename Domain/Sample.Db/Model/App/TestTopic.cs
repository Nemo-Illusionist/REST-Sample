using System;
using System.ComponentModel.DataAnnotations.Schema;
using Radilovsoft.Rest.Data.Core.Contract.Entity;
using Radilovsoft.Rest.Data.Ef.Annotation;

namespace Sample.Db.Model.App
{
    [Table("test_topic", Schema = DbSchemeConstant.App)]
    public class TestTopic : ICreatedUtc, IDeletable
    {
        [MultiKey]
        public Guid TestId { get; set; }

        [MultiKey]
        public Guid TopicId { get; set; }

        public DateTime CreatedUtc { get; set; }

        [Index]
        public DateTime? DeletedUtc { get; set; }


        [ForeignKey(nameof(TestId))]
        public Test Test { get; set; }

        [ForeignKey(nameof(TopicId))]
        public Topic Topic { get; set; }
    }
}