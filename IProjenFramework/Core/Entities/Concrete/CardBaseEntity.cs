using Core.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
    public abstract class CardBaseEntity<TKey, TUser> : BaseEntity<TKey>, ICardBaseEntity<TKey, TUser>
        where TUser : User
    {
        [MaxLength(128)]
        public int? UpdateUser { get; set; }

        [MaxLength(128)]
        public int? CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public Guid RowVersion { get; set; }

        [DefaultValue(true)]
        public bool Active { get; set; }

        public bool IsDeleted { get; set; }

        [ForeignKey("UpdateUser")]
        public TUser UpdatedByUser { get; set; }

        [ForeignKey("CreateUser")]
        public TUser CreatedByUser { get; set; }

        public CardBaseEntity(bool create, int? userId)
            : base(create)
        {
            if (create)
            {
                this.CreateUser = userId;
                this.CreateDate = DateTime.Now;
                this.RowVersion = Guid.NewGuid();
                this.Active = true;
                this.IsDeleted = false;
            }
        }

    }
}
