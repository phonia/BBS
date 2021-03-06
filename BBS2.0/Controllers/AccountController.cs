﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BBS2._0.Common;
using BBS2._0.Services;
using BBS2._0.ViewModel;
using Microsoft.Practices.Unity;

namespace BBS2._0.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/
        [Dependency]
        public IAccountService AccountService { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(String name,String password)
        {
            AccountDTO accountDto = AccountService.Login(name, password);
            //throw new DomainException("异常测试");
            Session[Constant.ACCOUNT_SESSION] = accountDto;
            return Json(new JsonMessageDTO()
            {
                Success = true,
                Message = "登录成功",
                Data = accountDto
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Register(String name,String password,String sex,String age,String tel,String email)
        {
            AccountDTO account = new AccountDTO()
            {
                Name = name,
                Password=password,
                Sex=(Sex)(Convert.ToInt32(sex)),
                Age=Convert.ToInt32(age),
                Tel=tel,
                Email=email
            };
            AccountDTO ret = AccountService.RegisterAccount(account);
            return Json(new JsonMessageDTO() { Success = true, Data = ret }, JsonRequestBehavior.AllowGet);
        }

        //数据加载
        public JsonResult LoadSexCombobox()
        {
            List<ComboboxDTO> list = new List<ComboboxDTO>() { 
                new ComboboxDTO(){Id="0",Text="男"},
                new ComboboxDTO(){Id="1",Text="女"},
                new ComboboxDTO(){Id="2",Text="未知"}
            };
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllAccount()
        {
            List<AccountDTO> list = AccountService.GetAllAccount();
            return Json(new DataGridDTO<AccountDTO>() { total = list.Count, rows = list }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SetAccountRole(String accountIds, String roleIds)
        {
            if (accountIds.Length < 0 || roleIds.Length < 0 )
            {
                return Json(new JsonMessageDTO() { Success = false, Message = "参数不能为空" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<Int32> accountId = accountIds.Split(',').Select(it => Convert.ToInt32(it)).ToList();
                List<Int32> roleId = roleIds.Split(',').Select(it => Convert.ToInt32(it)).ToList();
                if (AccountService.SetAccountRole(accountId, roleId))
                {
                    return Json(new JsonMessageDTO() { Success = true, Message = "success" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new JsonMessageDTO() { Success = false, Message = "NOT MENTIONED!" }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}
