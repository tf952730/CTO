using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using D01.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace D01.Views.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager,
                                 UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerVM.UserName
                };

                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("logon", "account");
                }

                return View(registerVM);
            }

            return View(registerVM);
        }

        public IActionResult Logon()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logon(LoginVM loginVM)
        {
            if (ModelState.IsValid)
            {
                // 提取用户对象
                var user = await _userManager.FindByNameAsync(loginVM.UserName);
                if (user != null)
                {
                    // 检查用户是否被锁定
                    if (user.LockoutEnabled)
                    {
                        // 登录系统
                        var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, lockoutOnFailure: false);
                        if (result.Succeeded)
                        {
                            return RedirectToAction("index", "people");
                        }
                        else
                        {
                            ModelState.AddModelError("Password", "输入密码错误，请核实后重新输入。");
                            return View(loginVM);
                        }
                    }
                    else
                    {
                        ViewData["LoginStatusString"] = "用户已被锁定，无法登录!";
                        return View(loginVM);
                    }
                }
                else
                {
                    ViewData["LoginStatusString"] = "用户名或者密码错误。";
                    return View(loginVM);
                }

            }
            ViewData["LoginStatusString"] = "";
            return View(loginVM);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}