using Domain.IRepository;
using Domain.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Controllers.BabyPhoto
{
    [Route("api/[controller]")]
    public class BabyPhotoController: Controller
    {
        private IHostingEnvironment hostingEnvironment;
        private IBabyPhotoRepository babyPhotoRepository;
        public BabyPhotoController(IHostingEnvironment hostingEnvironment,
            IBabyPhotoRepository babyPhotoRepository)
        {
            this.hostingEnvironment = hostingEnvironment;
            this.babyPhotoRepository = babyPhotoRepository;
        }
        [HttpPost]
        [Authorize]
        public string UpLoad()
        {
            string msg = "";
            string webRoot = this.hostingEnvironment.WebRootPath;
            IFormFileCollection listFiles=this.Request.Form.Files;
            foreach (IFormFile formFile in listFiles)
            {
                long imageSize = formFile.Length;
                string filrNmae = formFile.FileName;
                string path = webRoot + @"\Image\" + filrNmae;
                try
                {
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                    BabyPhotoModel obj = new BabyPhotoModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        PhotoName = filrNmae,
                        PhotoSize = (int)imageSize,
                        Url = "Image/"+ filrNmae,
                        UploadDate = DateTime.Now,
                        UploadPerson = "宁凡栋"
                    };
                    this.babyPhotoRepository.SaveEntity(obj);
                }
                catch(Exception e2)
                {
                    throw e2;
                }
                msg = $"文件名:{formFile.FileName};文件类型：{formFile.ContentType}";
            }
            return msg;
        }
        [HttpGet("showImage")]
        public IEnumerable<BabyPhotoModel>  ShowImage()
        {
            IEnumerable < BabyPhotoModel >  list=this.babyPhotoRepository.GetAll();
            return list;
        }
        [HttpGet]
        [Authorize]
        public object[] ShowImagePaginated(int pageIndex, int pageSize)
        {
            IEnumerable<BabyPhotoModel> list = this.babyPhotoRepository.GetAll();
            int pageCont = list.Count();
            IEnumerable<BabyPhotoModel> taskList=list.Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return new object[] { pageCont,taskList};
        }
    }
}
