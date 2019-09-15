namespace VesNing.EdutureCore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class LogInfo
    {
        public int ID { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(200)]
        public string SourceObject { get; set; }

        [Column(TypeName = "text")]
        public string SourceContentJson { get; set; }

        public DateTime? OperateTime { get; set; }

        public int? OperateUserId { get; set; }

        [StringLength(50)]
        public string OperateAccount { get; set; }

        public int? MenuId { get; set; }

        [StringLength(50)]
        public string Menu { get; set; }

        public int? MenuType { get; set; }

        [StringLength(200)]
        public string Description { get; set; }

        public int? DeleteMark { get; set; }

        public int? EnabledMark { get; set; }
    }
}
