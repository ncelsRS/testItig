﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PW.Ncels.Database.Models.OBK
{
    public class OBKTaskListResearchCenter
    {
        public Guid Id { get; set; }
        public int RegisterId { get; set; }
        public int ProductSeriesId { get; set; }
        public string ProductNameRu { get; set; }
        public string ProductNameKz { get; set; }
        public string Series { get; set; }
        public string SeriesMeasure { get; set; }
        public string SeriesStartdate { get; set; }
        public string SeriesEndDate { get; set; }
        public string SeriesParty { get; set; }

        /// <summary>
        /// кол-во переданных
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// кол-во в акте
        /// </summary>
        public int? ActQuantity { get; set; }

        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public string IdNumber { get; set; }

        /// <summary>
        /// условия хранения
        /// </summary>
        public Guid StorageCondition { get; set; }

        /// <summary>
        /// Внешнее состояние
        /// </summary>
        public Guid ExternalCondition { get; set; }

        /// <summary>
        /// выбранные лаборатории
        /// </summary>
        public List<OBKLaboratory> Laboratory { get; set; }

        /// <summary>
        /// для отображения
        /// </summary>
        public string LaboratoryName { get; set; }

        /// <summary>
        /// ФИО исполнителя
        /// </summary>
        public string ExecutorLaboratoryName { get; set; }

        /// <summary>
        /// Подпись исполнителя
        /// </summary>
        public bool ExecutorLaboratorySign { get; set; }

        public List<SelectedResearchCenter> SelectedResearchCenter { get; set; }

        public List<SelectedQuantity> SelectedQuantity { get; set; }

        public List<SubTaskIndicator> SubTaskResult { get; set; }

        /// <summary>
        /// Размерность ИМН
        /// </summary>
        public string DimensionIMN { get; set; }

        /// <summary>
        /// Исполнитель лаборатории
        /// </summary>
        public IEnumerable<SelectListItem> ExecutorLaboratoryList { get; set; }

        public Guid LaboratoryAssistantId { get; set; }

        public List<Guid> LaboratoryAssistantIds { get; set; }

        /// <summary>
        /// если уже результат ИЦ создан
        /// </summary>
        public bool CreateBtnValid { get; set; }

        public string StorageConditionNameRu { get; set; }
        public string StorageConditionNameKz { get; set; }
        public string ExternalConditionNameRu { get; set; }
        public string ExternalConditionNameKz { get; set; }

    }

    public class OBKLaboratory
    {
        public Guid LaboratoryId { get; set; }
        public string LaboratoryName { get; set; }
        
        /// <summary>
        /// для визульного отображения
        /// </summary>
        public string ResearchcenterNameRu { get; set; }
        public string ResearchcenterNameKz { get; set; }
        public int? Quantity { get; set; }
    }

    /// <summary>
    /// Наименование лабораторий
    /// </summary>
    public class SelectedResearchCenter
    {
        public Guid LaboratoryId { get; set; }
        public Guid ResearchcenterId { get; set; }
    }

    /// <summary>
    /// Кол-во переданных образцов по лаборавториям 
    /// </summary>
    public class SelectedQuantity
    {
        public Guid LaboratoryId { get; set; }
        public int Quantity { get; set; }
    }
}
