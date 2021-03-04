using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentManager.Models
{
    public class Session
    {
        public int SessionId { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public int SubjectId { get; set; }
        public virtual Subject Subject { get; set; }

        public int CLazzId { get; set; }
        public virtual Clazz Clazz { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public int NumBerSession { get; set; }

        [StringLength(255)]
        [Required]
        public string ListStudent { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DisplayName("Start Time")]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DisplayName("Finish Time")]
        public DateTime FinishTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Begin Time")]
        public DateTime BeginTime { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("End Time")]
        public DateTime EndTime { get; set; }

        public SessionStatus Status { get; set; }

        public enum SessionStatus
        {
            ACTIVE, DEACTIVE, DELETED
        }

        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}