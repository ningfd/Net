namespace VesNing.EdutureCore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserInfo
    {
        [Key]
        [StringLength(50)]
        public string UId { get; set; }

        [StringLength(50)]
        public string UName { get; set; }

        [StringLength(50)]
        public string UCode { get; set; }

        [StringLength(50)]
        public string UAccount { get; set; }

        [StringLength(50)]
        public string UPassword { get; set; }

        [StringLength(50)]
        public string URealName { get; set; }

        [StringLength(50)]
        public string UContact { get; set; }

        public int? UDeleteMark { get; set; }

        public int? UEnabledMark { get; set; }

        [StringLength(200)]
        public string UDescription { get; set; }

        public DateTime? UCreateDate { get; set; }

        [StringLength(50)]
        public string UCreateUserId { get; set; }

        [StringLength(50)]
        public string UCreateUserName { get; set; }

        public DateTime? UModifyDate { get; set; }

        [StringLength(50)]
        public string UModifyUserId { get; set; }

        [StringLength(50)]
        public string UModifyUserName { get; set; }

        public int? UGender { get; set; }

        public int? UIsVIP { get; set; }
    }
}
