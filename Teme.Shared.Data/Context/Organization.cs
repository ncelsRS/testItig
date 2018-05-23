using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teme.Shared.Data.Context
{
    /// <summary>
    /// Структурные подразделения
    /// </summary>
    public class Organization : BaseEntity
    {
        /// <summary>
        /// Код структурного подразделения (OrganizationScopeEnum)
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// ИИН или БИН
        /// </summary>
        public string IdNumber { get; set; }

        /// <summary>
        /// Наименование на русском
        /// </summary>
        [Required]
        [MaxLength(512)]
        public string NameRu { get; set; }

        /// <summary>
        /// Наименование на казахском
        /// </summary>
        [Required]
        [MaxLength(512)]
        public string NameKz { get; set; }

        /// <summary>
        /// Краткое наименование
        /// </summary>
        [MaxLength(255)]
        public string ShortNameRu { get; set; }

        /// <summary>
        /// Краткое наименование
        /// </summary>
        [MaxLength(255)]
        public string ShortNameKz { get; set; }

        /// <summary>
        /// Признак удаления
        /// </summary>
        public bool IsDeleted { get; set; } = false;

        /// <summary>
        /// Адрес организации
        /// </summary>
        public OrganizationAddress Address { get; set; }

        /// <summary>
        /// Родитель
        /// </summary>
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Organization Parent { get; set; }

        /// <summary>
        /// Дочерние записи
        /// </summary>
        public virtual ICollection<Organization> Children { get; set; }
    }
}
