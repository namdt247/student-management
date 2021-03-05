﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManager.Models
{
    public class Clazz
    {
        public int ClazzId { get; set; }

        [StringLength(255)]
        [Required]
        public string ClazzName { get; set; }

        [StringLength(255)]
        [Required]
        public string ClazzCode { get; set; }

        [StringLength(255)]
        [Required]
        public string ListStudentId { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public ClazzStatus Status { get; set; }

        public enum ClazzStatus
        {
            ACTIVE, DEACTIVE, DELETED
        }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}