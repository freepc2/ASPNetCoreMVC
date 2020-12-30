using BulletinBoardSystem.DataContext;
using BulletinBoardSystem.Models;
using BulletinBoardSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BulletinBoardSystem.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        /// 로그인 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 로그인 기능 및 전송
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            // 필수 입력 사항 : ID, Password
            if(ModelState.IsValid)
            {
                using (var db = new AspNetNoteDbContext())
                {
                    //Linq 식 사용
                    // => A go to B
                    // DB의 자료와 사용자의 ID, Password 비교
                    // == 사용시 새로운 객체선언으로 인하여 메모리 누수가 발생하므로 Equals을 사용한다.
                    //var user = db.Users.
                    //    FirstOrDefault(u => u.ID == model.ID && u.Password == model.Password);

                    var user = db.Users.
                        FirstOrDefault(u => u.ID.Equals(model.UserId) && 
                                            u.Password.Equals(model.UserPassword));

                    if(user != null)
                    {
                        //로그인 성공 : Session 메모리 등록 및 이동
                        HttpContext.Session.SetInt32("USER_LOGIN_KEY", user.No);
                        return RedirectToAction("LoginSuccess", "Home");
                    }                   
                }

                // 로그인 실패
                // 아이디 검색을 방지
                ModelState.AddModelError(string.Empty, "사용자 아이디 혹은 비밀번호가 올바르지 않습니다.");

            }
            return View(model);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("USER_LOGIN_KEY");

            //HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User model)
        {
            if(ModelState.IsValid)
            {
                using(var db = new AspNetNoteDbContext())
                {
                    db.Users.Add(model);
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private IDisposable AspNetNoteDbContext()
        {
            throw new NotImplementedException();
        }
    }
}
