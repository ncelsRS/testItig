﻿using Ncels.Helpers;
using PW.Ncels.Database.Constants;
using PW.Ncels.Database.DataModel;
using PW.Ncels.Database.Helpers;
using PW.Ncels.Database.Repository.Common;
using PW.Ncels.Database.Repository.OBK;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;

namespace PW.Prism.Controllers.OBK_OP
{
    public class OPController : Controller
    {
        //public readonly Guid UOBK = new Guid("f5eb95b6-fdf0-4f5a-afb6-85839419aa93");


        public ncelsEntities repo = new ncelsEntities();

        // GET: OP
        public ActionResult Index(Guid id)
        {
            var userId = UserHelper.GetCurrentEmployee().Id;
            ViewBag.IsExecutor = repo.OBK_AssessmentStageExecutors
                .Any(x => x.OBK_AssessmentStage.DeclarationId == id
                          && x.OBK_AssessmentStage.OBK_Ref_Stage.Code == "15"
                          && x.ExecutorId == userId && x.OBK_AssessmentStage.OBK_Ref_StageStatus.Code != "OPReportOnEC");
            return PartialView(id);
        }

        [HttpPost]
        public ActionResult SendToUOBK(Guid declarationId)
        {
            var declarationStage = repo.OBK_AssessmentStage.FirstOrDefault(x => x.DeclarationId == declarationId && x.StageId == 3);
            if (declarationStage == null)
            {
                declarationStage = new OBK_AssessmentStage
                {
                    Id = Guid.NewGuid(),
                    StageId = 2,
                    StageStatusId = 1,
                    DeclarationId = declarationId,
                    StartDate = DateTime.Now
                };
                repo.OBK_AssessmentStage.Add(declarationStage);
            }
            else
            {
                declarationStage.StageStatusId = 1;
                declarationStage.StartDate = DateTime.Now;
            }

            var executor = repo.OBK_AssessmentStageExecutors.FirstOrDefault(x => x.AssessmentStageId == declarationStage.Id && x.ExecutorType == 1);

            var expertOrganization = repo.OBK_AssessmentDeclaration.FirstOrDefault(x => x.Id == declarationId).OBK_Contract.ExpertOrganization;
            var organization = (repo.Units.FirstOrDefault(e => e.ParentId == expertOrganization && e.Code == OrganizationConsts.UobkDepartament) ??
                               repo.Units.FirstOrDefault(e => e.Parent.ParentId == expertOrganization && e.Code == OrganizationConsts.UobkDepartament)) ??
                              repo.Units.FirstOrDefault(e => e.Parent.Parent.ParentId == expertOrganization && e.Code == OrganizationConsts.UobkDepartament);

            var employeeIdstr = organization.BossId;
            var employeeId = new Guid(employeeIdstr);

            if (executor == null)
            {
                executor = new OBK_AssessmentStageExecutors
                {
                    AssessmentStageId = declarationStage.Id,
                    ExecutorId = employeeId,
                    ExecutorType = CodeConstManager.OBK_CONTRACT_STAGE_EXECUTOR_TYPE_ASSIGNING
                };
                repo.OBK_AssessmentStageExecutors.Add(executor);
            }
            else
            {
                executor.ExecutorId = employeeId;
            }

            var stage = repo.OBK_AssessmentStage.FirstOrDefault(x => x.DeclarationId == declarationId && x.StageId == 15);
            stage.StageStatusId = repo.OBK_Ref_StageStatus.Where(x => x.Code == "OPCompleted").Select(x => x.Id).Single();
            stage.EndDate = DateTime.Now;
            stage.FactEndDate = stage.EndDate;
            var declaration = repo.OBK_AssessmentDeclaration.FirstOrDefault(x => x.Id == declarationId);
            var status = repo.OBK_Ref_Status.FirstOrDefault(x => x.Code == "6");
            declaration.StatusId = status.Id;

            var reportOP = repo.OBK_AssessmentReportOP.FirstOrDefault(x => x.DeclarationId == declarationId);
            reportOP.StageStatusId = repo.OBK_Ref_StageStatus.Where(x => x.Code == "OPReportCompleted").Select(x => x.Id).FirstOrDefault();

            repo.SaveChanges();


          //  new SafetyAssessmentRepository().AddHistory(declarationId, OBK_Ref_StageStatus.OPCompleted);

            return Json(new { isSuccess = true });
        }

        public ActionResult SendToEC(Guid declarationId, int expertCouncilId)
        {
            try
            {
                var stage = repo.OBK_AssessmentStage.FirstOrDefault(x => x.DeclarationId == declarationId && x.OBK_Ref_Stage.Code == "15");
                stage.StageStatusId = repo.OBK_Ref_StageStatus.Where(x => x.Code == "OPReportOnEC").Select(x => x.Id).Single();

                var relationship = repo.OBK_AssessmentDeclaration__OBK_ExpertCouncil
                    .FirstOrDefault(x => x.DeclarationId == declarationId && x.ExpertCouncilId == expertCouncilId);
                if (relationship == null)
                {
                    var newRel = new OBK_AssessmentDeclaration__OBK_ExpertCouncil
                    {
                        DeclarationId = declarationId,
                        ExpertCouncilId = expertCouncilId
                    };
                    repo.OBK_AssessmentDeclaration__OBK_ExpertCouncil.Add(newRel);
                }

                var report = repo.OBK_AssessmentReportOP.FirstOrDefault(x => x.DeclarationId == declarationId);
                report.StageStatusId = repo.OBK_Ref_StageStatus
                    .Where(x => x.Code == "OPReportCompleted")
                    .Select(x => x.Id)
                    .FirstOrDefault();

                repo.SaveChanges();
               // new SafetyAssessmentRepository().AddHistory(stage.DeclarationId, OBK_Ref_StageStatus.InReWork);

                return Json(new { isSuccess = true }, JsonRequestBehavior.AllowGet);
            }
            catch (ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }

        #region MotivationRefusal

        public ActionResult MotivationRefusal(Guid declarationId)
        {
            try
            {
                return PartialView(declarationId);
            }
            catch (ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetMotivationRefusal(Guid declarationId)
        {
            try
            {
                var res = repo.OBK_AssessmentDeclaration__OBK_ExpertCouncil
                    .Where(x => x.DeclarationId == declarationId)
                    .ToList()
                    .Select(x => new
                    {
                        DeclarantName = x.OBK_AssessmentDeclaration.OBK_Contract.OBK_Declarant.NameRu,
                        DeclarationNumber = x.OBK_AssessmentDeclaration.Number,
                        ECNumber = x.OBK_ExpertCouncil.Number,
                        ECDate = x.OBK_ExpertCouncil.ActualDate?.ToString("dd.MM.yyyy"),
                        ECResult = x.Comment
                    })
                    .FirstOrDefault();
                return Json(res, JsonRequestBehavior.AllowGet);
            }
            catch (ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult ViewMotivationRefuse(Guid declarationId)
        {
            return PartialView("MotivationRefuseTemplate", declarationId);
        }

        public ActionResult PrintMotivationRefuse(Guid declarationId, bool view)
        {
            StiReport report = new StiReport();
            try
            {
                report.Load(Server.MapPath("~/Reports/Mrts/OBK/ObkOPMotivRefus.mrt"));
                foreach (var data in report.Dictionary.Databases.Items.OfType<StiSqlDatabase>())
                {
                    data.ConnectionString = UserHelper.GetCnString();
                }
                report.Dictionary.Variables[0].ValueObject = declarationId;
                report.Render(false);
            }
            catch (Exception ex)
            {
                LogHelper.Log.Error("ex: " + ex.Message + " \r\nstack: " + ex.StackTrace);
            }

            var stream = new MemoryStream();
            report.ExportDocument(StiExportFormat.Pdf, stream);
            stream.Position = 0;

            string name = "Мотивированный отказ" + DateTime.Now.ToString() + ".pdf";

            if (view)
            {
                return new FileStreamResult(stream, "application/pdf");

            }
            else
            {
                return File(stream, "application/pdf", name);
            }

        }

        [HttpGet]
        public ActionResult GetSign(Guid id)
        {
            var reslutStage = repo.OBK_AssessmentStage.FirstOrDefault(
                e => e.DeclarationId == id && e.StageId == CodeConstManager.STAGE_OBK_PIMS);

            if (reslutStage == null)
                return null;

            OBK_AssessmentStage ad = new OBK_AssessmentStage
            {
                Id = reslutStage.Id,
                DeclarationId = reslutStage.DeclarationId
            };
            var xmlData = SerializeHelper.SerializeDataContract(ad);
            var signData = xmlData.Replace("utf-16", "utf-8");
            return Json(new { data = signData }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveSigned(Guid id, string signedData)
        {
            try
            {
                var stage = repo.OBK_AssessmentStage.Single(x => x.DeclarationId == id && x.OBK_Ref_Stage.Code == "15");
                var userId = UserHelper.GetCurrentEmployee().Id;
                var stageSign = repo.OBK_AssessmentStageSignData
                    .FirstOrDefault(e => e.AssessmentStageId == stage.Id
                                        && e.SignerId == userId);
                if (stageSign == null)
                {
                    var stageSignData = new OBK_AssessmentStageSignData
                    {
                        Id = Guid.NewGuid(),
                        AssessmentStageId = stage.Id,
                        SignerId = userId,
                        SignXmlData = signedData,
                        SignDateTime = DateTime.Now
                    };
                    stage.OBK_AssessmentStageSignData.Add(stageSignData);
                }
                else
                {
                    stageSign.SignXmlData = signedData;
                    stageSign.SignDateTime = DateTime.Now;
                }

                var message = "Документ успешно подписан";

                stage.StageStatusId = repo.OBK_Ref_StageStatus.Single(x => x.Code == "OPCompleted").Id;
                stage.OBK_AssessmentDeclaration.StatusId = repo.OBK_Ref_StageStatus.Single(x => x.Code == "completed").Id;

                var reportStage = repo.OBK_AssessmentReportOP.Single(x => x.DeclarationId == id);
                reportStage.StageStatusId = repo.OBK_Ref_StageStatus.FirstOrDefault(x => x.Code == "OPMotivatedRefusalCompleted").Id;

                repo.SaveChanges();

                return Json(new { message });
            }
            catch (ArgumentException ex)
            {
                Response.StatusCode = 400;
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(ex, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion
    }
}