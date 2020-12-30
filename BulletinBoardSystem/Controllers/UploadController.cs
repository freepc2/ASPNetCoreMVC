using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardSystem.Controllers
{
    public class UploadController : Controller
    {
        // 환경부분에 접속하기 위해서 필요하다.
        private readonly IHostingEnvironment _environment;

        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }
        // http://www.example.com/Upload/Image/Upload
        // http://www.example.com/api/upload
        [HttpPost, Route("api/upload")]
        public async Task<IActionResult> ImageUpload(IFormFile fileToUpload)
        {
            // # 이미지나 파일을 업로드 할때 필요한 구성
            // 1. Path (경로) - 저장위치
            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
            // 2. Name (이름) - DateTime(동시 업로드일 경우 문제) + GUID(전역고유식별자)-중복 될수 있음
            //var fileName = fileToUpload.FileName;
            // 3. Extension(확장자) - jpg, png... txt
            // File 이름 변경 
            var fileFullName = fileToUpload.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}_{Guid.NewGuid()}.{fileFullName[1]}";
            using(var fileStream = new FileStream(Path.Combine(path,fileName), FileMode.Create))
            {
                await fileToUpload.CopyToAsync(fileStream);
            }
            return Ok(new { file = "/images/upload/" + fileName, success=true });

            // # URL 접근 방식
            // ASP .NET : 호스트명 + api/upload
            // Javascript : (호스트명 + / + api/upload)
        }
    }
}
