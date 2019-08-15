using Infrastructure.Entity;
using Infrastructure.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;


namespace Domain.Model
{
    /// <summary>
    /// 成长图片
    /// </summary>
    public class BabyPhotoModel// : EntityBase
    {
        public BabyPhotoModel()//: base(Guid.NewGuid())
        {

        }
        public string Id
        { get; set; }
        public string PhotoName
        {
            get; set;
        }
        public int PhotoSize
        {
            get; set;
        }
        public string Url
        {
            get; set;
        }
        public DateTime UploadDate
        {
            get; set;
        }
        public string UploadPerson
        {
            get; set;
        }
        public string UserId
        {
            get; set;
        }
        public AppUser User
        {
            get; set;
        }
    }
}
