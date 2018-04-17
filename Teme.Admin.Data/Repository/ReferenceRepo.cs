﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Teme.Admin.Data.Model;
using Teme.Shared.Data.Context;
using Teme.Shared.Data.Context.References;

namespace Teme.Admin.Data.Repository
{
    public class ReferenceRepo : IReferenceRepo
    {
        private readonly TemeContext _context;

        public ReferenceRepo(TemeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Условия хранения(справочник)
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ref_StorageCondition> StorageCondition() => _context.Ref_StorageConditions.Where(e => !e.IsDeleted);
        
        /// <summary>
        /// Классификатор областей медицинского применения медицинских изделий(справочник)
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ref_ClassifierMedicalArea> ClassifierMedicalArea() => _context.Ref_ClassifierMedicalAreas.Where(e => !e.IsDeleted);

        /// <summary>
        /// Код Номенклатуры медицинских изделий Республики Казахстан 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IQueryable<Ref_NomenclatureCodeMedProduct> NomenclatureCodeMedProduct(string name, string culture)
        {
            Expression<Func<Ref_NomenclatureCodeMedProduct, bool>> nomeclature;
            if(name != null)
            {
                switch (culture)
                {
                    case "ru":
                        nomeclature = x => x.NameRu.Contains(name) && !x.IsDeleted;
                        break;
                    case "kz":
                        nomeclature = x => x.NameKz.Contains(name) && !x.IsDeleted;
                        break;
                    default:
                        nomeclature = x => x.Id == 0;
                        break;
                }
            }
            else
            {
                nomeclature = x => !x.IsDeleted;
            }
            return _context.Ref_NomenclatureCodeMedProducts.AsQueryable().Where(nomeclature).Take(10);
        }

        /// <summary>
        /// Класс в зависимости от степени потенциального риска применения(справочник)
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ref_DegreeRiskClass> DegreeRiskClass() => _context.Ref_DegreeRiskClasses.Where(e => !e.IsDeleted);

        /// <summary>
        /// Организационная форма(справочник)
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ref_OrganizationForm> OrganizationForm() => _context.Ref_OrganizationForms.Where(e => !e.IsDeleted && e.IsConfirmed);

        /// <summary>
        /// Добавить новую Организационную форума(справочник)
        /// </summary>
        /// <returns></returns>
        public int SaveOrganizationForm(string nameRu, string nameKz, bool isConfirmed)
        {
            var orgForm = new Ref_OrganizationForm()
            {
                NameRu = nameRu,
                NameKz = nameKz,
                IsConfirmed = isConfirmed
            };
            _context.Ref_OrganizationForms.Add(orgForm);
            _context.SaveChanges();
            return orgForm.Id;
        }

        /// <summary>
        /// Банки(справочник)
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ref_Bank> Banks() => _context.Ref_Banks.Where(e => !e.IsDeleted && e.IsConfirmed);

        /// <summary>
        /// Добавить новый Банк(справочник)
        /// </summary>
        /// <param name="nameRu"></param>
        /// <param name="nameKz"></param>
        /// <param name="isConfirmed"></param>
        /// <returns></returns>
        public int SaveBank(string nameRu, string nameKz, bool isConfirmed)
        {
            var bank = new Ref_Bank()
            {
                NameRu = nameRu,
                NameKz = nameKz,
                IsConfirmed = isConfirmed
            };
            _context.Ref_Banks.Add(bank);
            _context.SaveChanges();
            return bank.Id;
        }

        /// <summary>
        /// Валюта
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ref_Currency> Currency() => _context.Ref_Currencies.Where(e => !e.IsDeleted);

        /// <summary>
        /// Страны
        /// </summary>
        /// <returns></returns>
        public IQueryable<Ref_Country> Country() => _context.Ref_Countries.Where(e => !e.IsDeleted);
    }
}
