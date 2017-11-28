﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PW.Ncels.Database.Models.EMP
{
    public class Declarations
    {

        public Guid Id { get; set; }
        public bool IsResident { get; set; }
        public Guid? OrganizationFormId { get; set; }
        public string Bin { get; set; }
        public string NameKz { get; set; }
        public string NameRu { get; set; }
        public string NameEn { get; set; }
        public Guid? CountryId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Number { get; set; }
        public int Type { get; set; }
        public Guid? ExpertOrganization { get; set; }
        public Guid? Signer { get; set; }
        public int Status { get; set; }


        public Guid? DeclarantContractId { get; set; }
        public string AddressLegalRu { get; set; }
        public string AddressLegalKz { get; set; }
        public string AddressFact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string BossLastName { get; set; }
        public string BossFirstName { get; set; }
        public string BossMiddleName { get; set; }
        public string BossPosition { get; set; }
        public string BossPositionKz { get; set; }
        public Guid? BossDocType { get; set; }
        public bool IsHasBossDocNumber { get; set; }
        public string BossDocNumber { get; set; }
        public DateTime? BossDocCreatedDate { get; set; }
        public DateTime? BossDocEndDate { get; set; }
        public bool BossDocUnlimited { get; set; }
        public bool SignerIsBoss { get; set; }
        public string SignLastName { get; set; }
        public string SignFirstName { get; set; }
        public string SignMiddleName { get; set; }
        public string SignPosition { get; set; }
        public string SignPositionKz { get; set; }
        public Guid? SignDocType { get; set; }
        public bool IsHasSignDocNumber { get; set; }
        public string SignDocNumber { get; set; }
        public DateTime? SignDocCreatedDate { get; set; }
        public DateTime? SignDocEndDate { get; set; }
        public bool SignDocUnlimited { get; set; }
        public string BankIik { get; set; }
        public string BankBik { get; set; }
        public Guid? CurrencyId { get; set; }
        public string BankNameRu { get; set; }
        public string BankNameKz { get; set; }
        public string Iin { get; set; }
    }
}
