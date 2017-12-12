﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PW.Ncels.Database.DataModel;
using PW.Ncels.Database.Helpers;
using PW.Ncels.Database.Models;
using PW.Ncels.Database.Models.EMP;
using PW.Ncels.Database.Repository.EMP;

namespace PW.Ncels.Controllers
{
    [Authorize()]
    public class EMPContractController : Controller
    {
        EMPContractRepository emp = new EMPContractRepository();

        // GET: EMPContract
        public ActionResult Index(string scope)
        {
            ViewBag.Scope = scope;
            ViewBag.ScopeName = emp.GetContractScopeName(scope);
            return View();
        }

        public ActionResult Contract(Guid? id, string scope)
        {
            //ViewBag.ListAction = "Index";
            ViewBag.Scope = scope;
            ViewBag.ReturnUrl = HttpContext.Request.UrlReferrer;
            return View(id);
        }

        /// <summary>
        /// Получение списка договоров
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<JsonResult> ReadContract(ModelRequest request, string scope)
        {
            return Json(await emp.GetContractList(request, true, scope), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetHolderTypes()
        {
            var result = emp.GetHolderTypes();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetContractTypes()
        {
            var result = emp.GetContractType().Select(e => new { e.Id, e.NameRu, e.NameKz });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetCurrency()
        {
            string[] note = {"KZT","RUB","USD", "EUR" };
            var result = emp.GetCurrency().Where(e=> note.Contains(e.Note)).Select(o => new { o.Id, o.Name, o.Code, o.NameKz });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetExpertOrganizations()
        {
            var expertOrganizations = emp.GetExpertOrganizations();
            return Json(expertOrganizations.ToList(), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetBanks()
        {
            var result = emp.GetBanks().Select(e => new { e.Id, e.NameRu, e.NameKz }); ;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult SaveNewBank(string bankNameRu, string bankNameKz)
        {
            var result = emp.SaveNewBank(bankNameRu, bankNameKz);
            return Json(result);
        }
        [HttpGet]
        public ActionResult GetChangeType()
        {
            var result = emp.GetChangeType();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetServiceType()
        {
            var result = emp.GetServiceType();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetServiceTypeParentId(string id)
        {
            var result = emp.GetServiceTypeParentId(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetPriceType(string id)
        {
            var result = emp.GetPriceTypeWhithPriceList(id);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult GetCalculation(string serviceTypeId, string serviceTypeModifId, bool isImport, int count)
        {
            var result = emp.GetPriceList(Guid.Parse(serviceTypeId), Guid.Parse(serviceTypeModifId), isImport, count);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetClearCostWork(Guid contractId)
        {
            emp.GetClearCostWork(contractId);
            return Json(new {IsSuccess = true}, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult FindDeclarant(string bin)
        {
            if (bin != null && bin.Length == 12)
            {
                var organization = emp.FindOrganization(bin);
                if (organization != null)
                {
                    var declarantJson = GetDeclarantJson(organization);
                    return Json(declarantJson, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        private object GetDeclarantJson(OBK_Declarant organization)
        {
            if (organization != null)
            {
                var declarantContact = organization.OBK_DeclarantContact.OrderByDescending(x => x.CreateDate).FirstOrDefault();
                if (declarantContact != null)
                {
                    var declarantJson = new
                    {
                        organization.Id,
                        organization.OrganizationFormId,
                        organization.IsResident,
                        organization.NameKz,
                        organization.NameRu,
                        organization.NameEn,
                        organization.CountryId,
                        
                        DeclarantContractId = declarantContact.Id,
                        declarantContact.AddressLegalRu,
                        declarantContact.AddressLegalKz,
                        declarantContact.AddressFact,
                        declarantContact.Phone,
                        declarantContact.Email,
                        declarantContact.BossLastName,
                        declarantContact.BossFirstName,
                        declarantContact.BossMiddleName,
                        declarantContact.BossPosition,
                        declarantContact.BossPositionKz,
                        declarantContact.BossDocType,
                        declarantContact.IsHasBossDocNumber,
                        declarantContact.BossDocNumber,
                        declarantContact.BossDocCreatedDate,
                        declarantContact.BossDocEndDate,
                        declarantContact.BossDocUnlimited,
                        declarantContact.SignerIsBoss,
                        declarantContact.SignLastName,
                        declarantContact.SignFirstName,
                        declarantContact.SignMiddleName,
                        declarantContact.SignPosition,
                        declarantContact.SignPositionKz,
                        declarantContact.SignDocType,
                        declarantContact.IsHasSignDocNumber,
                        declarantContact.SignDocNumber,
                        declarantContact.SignDocCreatedDate,
                        declarantContact.SignDocEndDate,
                        declarantContact.SignDocUnlimited,
                        declarantContact.BankIik,
                        declarantContact.BankBik,
                        declarantContact.CurrencyId,
                        declarantContact.BankNameRu,
                        declarantContact.BankNameKz
                    };
                    return declarantJson;
                }
                else
                {
                    var declarantJson = new
                    {
                        organization.Id,
                        organization.OrganizationFormId,
                        organization.IsResident,
                        organization.NameKz,
                        organization.NameRu,
                        organization.NameEn,
                        organization.CountryId
                    };
                    return declarantJson;
                }
            }
            return null;
        }
        
        public ActionResult ContractSave(Guid Guid, EMPContractViewModel contractViewModel)
        {
            EMPContractViewModel savedContract = emp.SaveContract(Guid, contractViewModel);
            return Json(savedContract);
        }
        [HttpGet]
        public ActionResult LoadContract(Guid contractId)
        {
            EMPContractViewModel view = emp.LoadContract(contractId);
            return Json(view, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SendToCoz(Guid contractId)
        {
            try
            {
                emp.SendToCoz(contractId);
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);
            }
        }
    }
}