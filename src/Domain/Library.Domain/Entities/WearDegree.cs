using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Library.Domain.Core.Entities;

namespace Library.Domain.Entities
{
    public class WearDegree : EntityWithId<Guid>
    {
        [Display(Name = @"Data modificarii statusului")]
        public DateTime TimeStamp { get; set; }

        public int ValueStatus { get; set; }

        public Guid BookExmplaryId { get; set; }

        [ForeignKey(nameof(BookExmplaryId))]
        public BookExemplary BookExemplary { get; set; }

    }
}
