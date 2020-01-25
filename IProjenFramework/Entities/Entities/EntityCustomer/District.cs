﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityCustomer.Entities.Entities
{
    public class District : CardBaseEntity<int>
    {
        public District(bool create, int userId)
             : base(create, userId)
        {
        }

        public District()
            : base(false, null)
        {
        }
        public int CityId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey(nameof(CityId))]
        [InverseProperty("Districts")]
        public virtual City City { get; set; }
        [InverseProperty("District")]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
    }
}
