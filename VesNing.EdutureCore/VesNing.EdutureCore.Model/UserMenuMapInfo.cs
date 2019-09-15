namespace VesNing.EdutureCore.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class UserMenuMapInfo
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? MenuID { get; set; }
    }
}
