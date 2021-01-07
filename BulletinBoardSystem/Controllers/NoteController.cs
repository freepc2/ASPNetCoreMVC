using BulletinBoardSystem.DataContext;
using BulletinBoardSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace BulletinBoardSystem.Controllers
{
    public class NoteController : Controller
    { 
        /// <summary>
        /// 게시물 리스트 표시
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //로그인 확인
            if(HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안되었을 경우
                return RedirectToAction("Login", "Account");
            }

            using(var db = new AspNetNoteDbContext())
            {
                var list = db.Notes.ToList();
                return View(list);
            }
        }

        /// <summary>
        /// 게시물 추가
        /// </summary>
        /// <returns></returns>
        public IActionResult Add()
        {            
            return View();
        }

        [HttpPost]
        public IActionResult Add(Note model)
        {
            //로그인 확인
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안되었을 경우
                return RedirectToAction("Login", "Account");
            }

            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());
            
            if (ModelState.IsValid)
            {
                
                using(var db = new AspNetNoteDbContext())
                {
                    db.Notes.Add(model);
                    if (db.SaveChanges() > 0)   //Commit 성공갯수 리턴
                    {
                        return Redirect("Index");
                    }
                    ModelState.AddModelError(string.Empty, "게시물을 저장 할수 없습니다.");
                }
            }
            return View(model);
        }
        /// <summary>
        /// 게시판 상세 내역
        /// </summary>
        /// <param name="NoteNo"></param>
        /// <returns></returns>
        public IActionResult Detail(int noteNo)
        {
            //로그인 확인
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안되었을 경우
                return RedirectToAction("Login", "Account");
            }
            using(var db = new AspNetNoteDbContext())
            {
                var note = db.Notes.FirstOrDefault(u => u.No.Equals(noteNo));
                return View(note);
            }
        }
        public IActionResult Edit(Note model)
        {
            return View(model);
        }
        /// <summary>
        /// 게시물 수정
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(Note model)
        {
            //로그인 확인
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안되었을 경우
                return RedirectToAction("Login", "Account");
            }
            model.UserNo = int.Parse(HttpContext.Session.GetInt32("USER_LOGIN_KEY").ToString());

            if (ModelState.IsValid)
            {

                using (var db = new AspNetNoteDbContext())
                {

                    db.Entry(model).State = EntityState.Modified;
                    if (db.SaveChanges() > 0)   //Commit 성공갯수 리턴
                    {
                        return Redirect("Index");
                    }
                    ModelState.AddModelError(string.Empty, "게시물을 수정 할수 없습니다.");
                }
            }
            return View(model);
        }
        /// <summary>
        /// 게시물 삭제
        /// </summary>
        /// <returns></returns>
        public IActionResult Delete()
        {
            //로그인 확인
            if (HttpContext.Session.GetInt32("USER_LOGIN_KEY") == null)
            {
                //로그인이 안되었을 경우
                return RedirectToAction("Login", "Account");
            }
            return View() ;
        }
    }
}
