﻿function empContractForm($scope, $http, DTColumnBuilder, $interval, $uibModal, $window) {
    $scope.object = {};

    $scope.object.Manufactur = {};
    $scope.object.Declarant = {};
    $scope.object.Payer = {};
    $scope.object.Manufactur.Contact = {};
    $scope.object.Declarant.Contact = {};
    $scope.object.Payer.Contact = {};

    $scope.Calulator = {};

    $scope.object.ServicePrices = [];
    $scope.object.ServiceRegisterResults = [];

    $scope.Payer = {};

    $scope.showAttach = false;

    $scope.iinSearchActiveManufactur = false;
    $scope.showContactInformationManufactur = true;
    $scope.showContactInformationDeclarant = true;
    $scope.showContactInformationPayer = true;

    $scope.addManufacturNewBankName = false;
    $scope.addDeclarantNewBankName = false;
    $scope.addPayerNewBankName = false;

    $scope.DeclarantIsManufactur = null;

    $scope.showFindInformationPayer = true;
    $scope.searchDrugWorking = false;

    //calculator
    $scope.showServiceTypeNameEaes = true;
    $scope.showServiceTypeName = true;
    $scope.showServiceTypeNameModif = true;
    $scope.showCalculatorForm = true;
    $scope.showRadioIsImport = true;
    $scope.Calulator.IsImport = false;
    $scope.Calulator.Count = 1;
    $scope.Calulator.showChangeType = false;

    $scope.bankValidManufactur = true;
    $scope.bankValidDeclarant = true;

    $scope.resultRegisterSearch = false;

    // Patterns start
    $scope.emailPattern = ".+@.+\\..+";
    $scope.iikPattern = "[a-z0-9]+";
    $scope.bankBikPattern = "[a-z0-9]+";
    $scope.bankBikMinLength = 8;
    $scope.bankBikMaxLength = 11;
    $scope.phonePattern = "[0-9 ()+,]+";
    $scope.iinPattern = "[0-9]+";
    $scope.iinMinLength = 12;
    $scope.iinMaxLength = 12;
    $scope.rusLangPattern = "[а-яА-ЯёЁ]+";
    // Patterns end


    //a-zA-Z0-9

    $scope.ExpertOrganizations = [];
    $scope.HolderType = [];

    $scope.object.ContractScope = "";
    //$scope.setContractScope = function (contractScope) {
    //    debugger;
    //    $scope.object.ContractScope = contractScope;
    //}

    debugger;
    // loadRefs
    $scope.object.ContractScope = $("#scopeCode").val();
    if ($scope.object.ContractScope === "national") {
        loadHolderTypes($scope, $http, "national");
        loadServiceType($scope, $http, "national");
    } else {
        loadHolderTypes($scope, $http, "eaes");
        loadServiceType($scope, $http, "eaes");
    }
    loadContractTypes($scope, $http);
    loadExpertOrganizations($scope, $http);
    loadDictionary($scope, 'OpfType', $http);
    loadDictionary($scope, 'Country', $http);
    //loadDictionary($scope, 'Currency', $http);
    loadEMPContractDocumentType($scope, $http);
    loadCurrency($scope, $http);
    loadBanks($scope, $http);

    $scope.loadContract = function () {
        var projectId = $("#projectId").val();
        debugger;
        $http({
            method: 'GET',
            url: '/EMPContract/LoadContract',
            params: {
                contractId: projectId
            }
        }).success(function (response) {
            debugger;
            $scope.object = response;
        });
    }

    var contractId = $("#projectId").val();
    if (contractId) {
        debugger;
        $scope.loadContract();
    };

    $scope.saveBtnClick = function () {
        debugger;
        if ($scope.validate())
            $scope.editProject();
    };

    $scope.sendWithoutDigitalSign = function() {

        if (!$scope.validate()) return;

        $http({
            url: '/EMPContract/SendToCoz',
            method: 'POST',
            data: { contractId: $("#modelGuid").val() }
        }).success(function () {
            $("#btnBackToList").click();
        }).error(function() {
            alert("Возникла ошибка при отправке в ЦОЗ");
        });
    };

    $scope.sendWithDigitalSign = function() {
        if (!$scope.validate()) return;
        $scope.doSign();
    };

    // saveContract
    $scope.editProject = function () {
        debugger;
        var modelGuid = $("#modelGuid").val();
        var object = $scope.object;
        if (object.ServiceRegisterResults !== undefined) {
            object.ServiceRegisterResults.length = 0;
        }
        $http({
            url: '/EMPContract/ContractSave',
            method: 'POST',
            data: { Guid: modelGuid, contractViewModel: object }
        }).success(function (response) {
            $scope.showRegister = false;
            $scope.object = response;
            alert("Договор успешно сохранен");
        }).error(function () {
            alert("Возникла ошибка при сохранении договора");
        });
    }

    //$scope.IsBossDocTypes = [
    //    {
    //        Id: true,
    //        Name: "Да"
    //    }, {
    //        Id: false,
    //        Name: "Нет"
    //    }];

    //$scope.BossDocTypes = [
    //    {
    //        Id: '1',
    //        Name: "Представительство"
    //    }, {
    //        Id: '2',
    //        Name: "Доверенное лицо"
    //    }];

    //choose Payer
    $scope.ChoosePayers = [{
        Id: 'Manufactur',
        Name: "Производитель"
    }, {
        Id: 'Declarant',
        Name: "Заявитель"
    }, {
        Id: 'Payer',
        Name: "Третье лицо"
        }
    ];

    $scope.editPayer = function () {
        debugger;
        if ($scope.object['Payer'] != null)
            $scope.clearForm('Payer');
        switch ($scope.object.ChoosePayer) {
            case 'Manufactur':
                $scope.object['Payer'] = angular.copy($scope.object['Manufactur']);
                $scope.showContactInformationPayer = true;
                //$scope.object['Payer'].IsResident = null; //todo временно для тестирования
                break;
            case 'Declarant':
                $scope.object['Payer'] = angular.copy($scope.object['Declarant']);
                $scope.showContactInformationPayer = true;
                //$scope.object['Payer'].IsResident = null; //todo временно для тестирования
                break;
            case 'Payer':
                $scope.showContactInformationPayer = true;
                $scope.showFindInformationPayer = false;
                break;
                default:
        }
    }

    $scope.isManufacturer = function () {
        debugger;
        if ($scope.object.DeclarantIsManufactur) {
            $scope.object['Declarant'] = angular.copy($scope.object['Manufactur']);
            //$scope.object['Declarant'].IsResident = null; //todo временно для тестирования
        }
        if (!$scope.object.DeclarantIsManufactur) {
            $scope.clearForm('Declarant');
        }
    }

    $scope.residentChange = function (obj) {
        debugger;
        $scope.showHideBin(obj);
    }
    //check radioBtn
    $scope.showHideBin = function (obj) {
        debugger;
        if ($scope.object[obj].IsResident == true) {
        }
        else {
            $scope.object[obj].Country = null;
            $scope.object[obj].NameNonResident = null;
        }
        $scope.cancelFind(obj);
        $scope.object[obj].Bin = null;
        

        switch(obj) {
            case 'Manufactur':
                $scope.showContactInformationManufactur = true;
                $scope.manufacturNotFound = false;
                break;
            case 'Declarant':
                $scope.showContactInformationDeclarant = true;
                $scope.declarantNotFound = false;
                break;
            case 'Payer':
                $scope.showContactInformationPayer = true;
                $scope.payerNotFound = false;
                break;
                default:
        }
    }

    $scope.cancelFind = function (obj) {
        debugger;
        switch(obj) {
            case 'Manufactur':
                $scope.iinSearchActiveManufactur = false;
                $scope.manufacturNotFound = false;
                $scope.showContactInformationManufactur = true;
                $scope.addManufacturDisabled = false;
                break;
            case 'Declarant':
                $scope.iinSearchActiveDeclarant = false;
                $scope.declarantNotFound = false;
                $scope.showContactInformationDeclarant = true;
                $scope.addDeclarantDisabled = false;
                break;
            case 'Payer':
                $scope.iinSearchActivePayer = false;
                $scope.payerNotFound = false;
                $scope.showContactInformationPayer = true;
                $scope.addPayerDisabled = false;
                break;
            default:
        }
        $scope.clearForm(obj);
    }

    $scope.clearForm = function (obj) {
        $scope.object[obj].Id = null;
        $scope.object[obj].Bin = null;
        $scope.object[obj].OrganizationFormId = null;
        $scope.object[obj].NameKz = null;
        $scope.object[obj].NameRu = null;
        $scope.object[obj].NameEn = null;
        $scope.object[obj].CountryId = null;

        //$scope.object[obj].IsManufactur = null;
        //$scope.object[obj].ChoosePayer = null;

        if ($scope.object[obj].Contact != null) {
            $scope.object[obj].Contact.AddressLegalRu = null;
            $scope.object[obj].Contact.AddressLegalKz = null;
            $scope.object[obj].Contact.AddressFact = null;
            $scope.object[obj].Contact.Phone = null;
            $scope.object[obj].Contact.Phone2 = null;
            $scope.object[obj].Contact.Email = null;
            $scope.object[obj].Contact.BossLastName = null;
            $scope.object[obj].Contact.BossFirstName = null;
            $scope.object[obj].Contact.BossMiddleName = null;
            $scope.object[obj].Contact.BossPosition = null;
            $scope.object[obj].Contact.BossPositionKz = null;
            $scope.object[obj].Contact.BossDocType = null;
            $scope.object[obj].Contact.IsHasBossDocNumber = null;
            $scope.object[obj].Contact.BossDocNumber = null;
            $scope.object[obj].Contact.BossDocCreatedDate = getDate(null);
            $scope.object[obj].Contact.BossDocEndDate = getDate(null);
            $scope.object[obj].Contact.BossDocUnlimited = false;
            $scope.object[obj].Contact.SignerIsBoss = false;
            $scope.object[obj].Contact.SignLastName = null;
            $scope.object[obj].Contact.SignFirstName = null;
            $scope.object[obj].Contact.SignMiddleName = null;
            $scope.object[obj].Contact.SignPosition = null;
            $scope.object[obj].Contact.SignPositionKz = null;
            $scope.object[obj].Contact.SignDocType = null;
            $scope.object[obj].Contact.IsHasSignDocNumber = null;
            $scope.object[obj].Contact.SignDocNumber = null;
            $scope.object[obj].Contact.SignDocCreatedDate = getDate(null);
            $scope.object[obj].Contact.SignDocEndDate = getDate(null);
            $scope.object[obj].Contact.SignDocUnlimited = false;
            $scope.object[obj].Contact.BankId = null;
            $scope.object[obj].Contact.BankIik = null;
            $scope.object[obj].Contact.BankBik = null;
            $scope.object[obj].Contact.CurrencyId = null;
            $scope.object[obj].Contact.BankNameRu = null;
            $scope.object[obj].Contact.BankNameKz = null;
        }
       
    }

    $scope.addManufactur = function (obj) {
        
        if ($scope.object[obj].IsResident == false) {
            $scope.object[obj].CountryId = $scope.object[obj].Country;
        }
        else if ($scope.object[obj].IsResident == true) {
            $scope.object[obj].CountryId = null;
        }
        switch (obj) {
            case 'Manufactur':
                debugger;
                $scope.showContactInformationManufactur = false;
                $scope.addManufacturDisabled = true;
                break;
            case 'Declarant':
                $scope.showContactInformationDeclarant = false;
                $scope.addDeclarantDisabled = true;
                break;
            case 'Payer':
                $scope.showContactInformationPayer = false;
                $scope.addPayerDisabled = true;
                break;
            default:
        }
    }

    $scope.loadNamesNonResidents = function (obj) {
        $scope.NamesNonResidents = [];

        $http({
            method: 'GET',
            url: '/OBKContract/GetNamesNonResidents',
            params: {
                countryId: $scope.object[obj].Country
            }
        }).then(function (resp) {
            if (resp.data) {
                $scope.NamesNonResidents = resp.data;
            }
        });
    }

    $scope.nonResidentCountryChange = function (obj) {
        
        $scope.loadNamesNonResidents(obj);
        $scope.object[obj].NameNonResident = null;
        
        switch (obj) {
            case 'Manufactur':
                $scope.manufacturNotFound = false;
                $scope.showContactInformationManufactur = true;
                break;
            case 'Declarant':
                $scope.declarantNotFound = false;
                $scope.showContactInformationDeclarant = true;
                break;
            case 'Payer':
                $scope.payerNotFound = false;
                $scope.showContactInformationPayer = true;
                break;
            default:
        }
    }

    $scope.nameNonResidentChange = function (obj) {
        //$scope.showContactInformationManufactur = false;
        if ($scope.object[obj].NameNonResident) {
            if ($scope.object[obj].NameNonResident == "00000000-0000-0000-0000-000000000000") {
                switch(obj) {
                    case 'Manufactur':
                        $scope.manufacturNotFound = true;
                        $scope.addManufacturDisabled = false;
                        break;
                    case 'Declarant':
                        $scope.declarantNotFound = true;
                        $scope.addDeclarantDisabled = false;
                        break;
                    case 'Payer':
                        $scope.payerNotFound = true;
                        $scope.addPayerDisabled = false;
                        default:
                }
                
            }
            else {
                switch (obj) {
                    case 'Manufactur':
                        $scope.manufacturNotFound = false;
                        $scope.addManufacturDisabled = true;
                        break;
                    case 'Declarant':
                        $scope.declarantNotFound = false;
                        $scope.addDeclarantDisabled = true;
                        break;
                    case 'Payer':
                        $scope.payerNotFound = false;
                        $scope.addPayerDisabled = true;
                        break;
                    default:
                }
                $scope.addManufacturDisabled = true;
                //$scope.loadOrganizationData($scope.manufacturObject.NameNonResident);
            }
        }
    }

   

    $scope.changeBank = function (obj) {
        debugger;
        if ($scope.object[obj].Contact.BankId == "999") {
            switch (obj) {
                case 'Manufactur':
                    $scope.addManufacturNewBankName = true;
                    $scope.bankValidManufactur = true;
                    break;
                case 'Declarant':
                    $scope.addDeclarantNewBankName = true;
                    $scope.bankValidDeclarant = true;
                    break;
                case 'Payer':
                    $scope.addPayerNewBankName = true;
                    break;
                default:
            }
            
        } else {
            switch (obj) {
                case 'Manufactur':
                    $scope.addManufacturNewBankName = false;
                    $scope.bankValidManufactur = false;
                    break;
                case 'Declarant':
                    $scope.addDeclarantNewBankName = false;
                    $scope.bankValidDeclarant = false;
                    break;
                case 'Payer':
                    $scope.addPayerNewBankName = false;
                    break;
                default:
            }

            //editProject();
        }
    }

    $scope.addNewBank = function (obj) {
        debugger;
        if ($scope.object[obj].Contact.BankNameRu == null || $scope.object[obj].Contact.BankNameKz == null)
            return alert("Заполните наименование банка");
        $http({
            url: '/EMPContract/SaveNewBank',
            method: 'POST',
            data: { BankNameRu: $scope.object[obj].Contact.BankNameRu, BankNameKz: $scope.object[obj].Contact.BankNameKz }
        }).success(function (response) {
            debugger;
            loadBanks($scope, $http);
            $scope.object[obj].Contact.BankId = response.Id;
            switch (obj) {
                case 'Manufactur':
                    $scope.addManufacturNewBankName = false;
                    break;
                case 'Declarant':
                    $scope.addDeclarantNewBankName = false;
                    break;
                case 'Payer':
                    $scope.addPayerNewBankName = false;
                    break;
                default:
            }
        });
        switch (obj) {
            case 'Manufactur':
                $scope.bankValidManufactur = false;
                break;
            case 'Declarant':
                $scope.bankValidDeclarant = false;
                break;
            case 'Payer':
                break;
            default:
        }
        
    };
    //для еаэс
    $scope.editServiceTypeEaes = function() {
        if ($scope.Calulator.ServiceType == "00000000-0000-0000-0000-000000000000") {
            $scope.showServiceTypeNameEaes = true;
        } else {
            $scope.Calulator.ServiceTypeName = null;
            $scope.showServiceTypeNameEaes = false;
            $http({
                method: "GET",
                url: "/EMPContract/GetServiceTypeParentId",
                params: {
                    id: $scope.Calulator.ServiceType
                }
            }).success(function (result) {
                $scope.ServiceTypeNames = result;
            });
        }
    }

    $scope.editServiceType = function () {
        debugger;
        if ($scope.Calulator.ServiceType == "00000000-0000-0000-0000-000000000000") {
            $scope.showServiceTypeName = true;
            $scope.Calulator.showChangeType = false;
            $scope.Calulator.ChangeType = null;
        } else {
            var serviceType = $scope.ServiceTypes.find(item => item.Id === $scope.Calulator.ServiceType);
            if (serviceType.ChangeType) {
                loadChangeType($scope, $http);
                $scope.Calulator.showChangeType = true;
            } else {
                $scope.Calulator.showChangeType = false;
                $scope.Calulator.ChangeType = null;
            }
            $scope.Calulator.ServiceTypeName = null;
            $scope.Calulator.ServiceTypeNameModif = null;
            $scope.Calulator.Count = 1;
            $scope.showServiceTypeName = false;
            $http({
                method: "GET",
                url: "/EMPContract/GetServiceTypeParentId",
                params: {
                    id: $scope.Calulator.ServiceType
                }
            }).success(function (result) {
                $scope.ServiceTypeNames = result;
            });
        }
    }

    $scope.editChangeType = function () {
        debugger;
        var changeType = $scope.ChangeTypes.find(item => item.Id === $scope.Calulator.ChangeType);
        $scope.ChangeTypeCode = changeType.Code;
        $scope.DegreeRiskCode = null;
    }

    $scope.showBossDocType = true;
    $scope.changeBossDocType = function () {
        debugger;
        var changeType = $scope.EMPContractDocumentTypes.find(item => item.Id === $scope.object.Declarant.Contact.BossDocType);
        switch (changeType.Code) {
            case "powerOfAttorney":
                $scope.showBossDocType = true;
                break;
            case "charter":
                $scope.showBossDocType = false;
                break;
            default:
                break;
        }
    }

    $scope.editServiceTypeName = function() {
        debugger;
        if ($scope.Calulator.ServiceTypeName == "00000000-0000-0000-0000-000000000000") {
            $scope.showServiceTypeNameModif = true;
            $scope.showCalculatorForm = true;
        } else {
            $scope.showServiceTypeNameModif = false;
            $scope.Calulator.ServiceTypeNameModif = null;
            $scope.Calulator.Count = 1;
            $http({
                method: "GET",
                url: "/EMPContract/GetServiceTypeParentId",
                params: {
                    id: $scope.Calulator.ServiceTypeName
                }
            }).success(function (result) {
                debugger;
                $scope.ServiceTypeNameModifs = result;
                var degreeRisk = $scope.ServiceTypeNames.find(item => item.Id === $scope.Calulator.ServiceTypeName);
                if ($scope.ChangeTypeCode != null) {
                    $scope.DegreeRiskCode = null;
                } else {
                    $scope.DegreeRiskCode = degreeRisk.Code;
                    $scope.ChangeTypeCode = null;
                }
            });
        }
    }

    $scope.editServiceTypeNameModif = function () {
        debugger;
        if ($scope.Calulator.ServiceTypeNameModif == "00000000-0000-0000-0000-000000000000") {
            $scope.showCalculatorForm = true;
            $scope.showRadioIsImport = false;
            $scope.Calulator.Count = 1;
        } else {
            $scope.showCalculatorForm = false;
            $scope.showRadioIsImport = false;
        }
    }

    $scope.tab5click = function() {
        $scope.showAttach = true;
    }

    $scope.totalPrice = function () {
        var total = 0;
        if ($scope.object.ServicePrices != null) {
            for (var i = 0; i < $scope.object.ServicePrices.length; i++) {
                var servicePrice = $scope.object.ServicePrices[i];
                total += (servicePrice.Price);
            }
            return total;
        }
        return total;
    }
    $scope.totalCount = function () {
        var total = 0;
        if ($scope.object.ServicePrices != null) {
            for (var i = 0; i < $scope.object.ServicePrices.length; i++) {
                var servicePrice = $scope.object.ServicePrices[i];
                total += (servicePrice.Count);
            }
            return total;
        }
        return total;
    }
    $scope.totalTotalPrice = function () {
        var total = 0;
        if ($scope.object.ServicePrices != null) {
            for (var i = 0; i < $scope.object.ServicePrices.length; i++) {
                var servicePrice = $scope.object.ServicePrices[i];
                total += (servicePrice.TotalPrice);
            }
            return total;
        }
        return total;
    }

    $scope.calulatorChange = function (bool) {
        $scope.Calulator.IsImport = bool;
    }

    $scope.calculation = function (scopeCode) {
        switch (scopeCode) {
            case "national":

                var serviceType = null;
                if ($scope.Calulator.ServiceTypeNameModif == "00000000-0000-0000-0000-000000000000") {
                    serviceType = $scope.Calulator.ServiceTypeName;
                } else {
                    serviceType = $scope.Calulator.ServiceTypeNameModif;
                }
                $http({
                    method: "GET",
                    url: "/EMPContract/GetCalculation",
                    params: {
                        serviceTypeId: $scope.Calulator.ServiceTypeName,
                        serviceTypeModifId: $scope.Calulator.ServiceTypeNameModif,
                        isImport: $scope.Calulator.IsImport,
                        count: $scope.Calulator.Count
                    }
                }).success(function (response) {
                    if (response) {
                        $scope.clearCalc();
                        $scope.object.ServicePrices.length = 0;
                        $scope.object.ServicePrices.push.apply($scope.object.ServicePrices, response);
                    } else {
                        alert("Данных не найдено");
                    }
                });

                break;
            case "eaes":

                $http({
                    method: "GET",
                    url: "/EMPContract/GetCalculationEaes",
                    params: {
                        serviceTypeId: $scope.Calulator.ServiceTypeName
                    }
                }).success(function (response) {
                    if (response) {
                        $scope.clearCalc();
                        $scope.object.ServicePrices.length = 0;
                        $scope.object.ServicePrices.push.apply($scope.object.ServicePrices, response);
                    } else {
                        alert("Данных не найдено");
                    }
                });

                break;
                default:
        }
        
    };

    $scope.clearCalc = function() {
        if ($scope.object.Id != null && $scope.object.Id != "00000000-0000-0000-0000-000000000000") {
            $http({
                method: "GET",
                url: "/EMPContract/GetClearCostWork",
                params: {
                    contractId: $scope.object.Id
                }
            }).success(function (response) {
            });
        }
    }

    $scope.clearCalculation = function () {
        debugger;
        if ($scope.object.Id != null && $scope.object.Id != "00000000-0000-0000-0000-000000000000") {
            $http({
                method: "GET",
                url: "/EMPContract/GetClearCostWork",
                params: {
                    contractId: $scope.object.Id
                }
            }).success(function(response) {
                debugger;
                $scope.clearCalculationForm();
            });
        } else {
            $scope.clearCalculationForm();
        }
    }

    $scope.clearCalculationForm = function () {
        $scope.Calulator.ServiceType = null;
        $scope.Calulator.ChangeType = null;
        $scope.Calulator.showChangeType = false;
        $scope.Calulator.ServiceTypeName = null;
        $scope.Calulator.ServiceTypeNameModif = null;
        $scope.Calulator.Count = null;
        $scope.showServiceTypeName = true;
        $scope.showServiceTypeNameModif = true;
        $scope.showCalculatorForm = true;
        $scope.showRadioIsImport = true;
        $scope.Calulator.Count = 1;
        $scope.object.ServicePrices.length = 0;

        $scope.DegreeRiskCode = null;
        $scope.ChangeTypeCode = null;
    }

    //todo незабыть перечислить поля
    $scope.findDeclarant = function (obj) {
        debugger;
        if ($scope.object[obj].Bin && $scope.object[obj].Bin.length == 12) {
            $http({
                method: 'GET',
                url: '/EMPContract/FindDeclarant',
                params: {
                    bin: $scope.object[obj].Bin
                }
            }).then(function (resp) {
                switch(obj) {
                    case 'Manufactur':
                        $scope.iinSearchActiveManufactur = true;
                        break;
                    case 'Declarant':
                        $scope.iinSearchActiveDeclarant = true;
                        break;
                    case 'Payer':
                        $scope.iinSearchActivePayer = true;
                        break;
                        default:
                }
                if (resp.data) {
                    debugger;
                    $scope.object[obj].Contact = {};
                    $scope.object[obj].Id = resp.data.Id;
                    $scope.object[obj].OrganizationFormId = resp.data.OrganizationFormId;
                    $scope.object[obj].IsResident = resp.data.IsResident;
                    $scope.object[obj].NameKz = resp.data.NameKz;
                    $scope.object[obj].NameRu = resp.data.NameRu;
                    $scope.object[obj].NameEn = resp.data.NameEn;
                    $scope.object[obj].CountryId = resp.data.CountryId;
                    $scope.object[obj].IsFind = true;

                    $scope.object[obj].Contact.Id = resp.data.DeclarantContractId;
                    $scope.object[obj].Contact.AddressLegalRu = resp.data.AddressLegalRu;
                    $scope.object[obj].Contact.AddressLegalKz = resp.data.AddressLegalKz;
                    $scope.object[obj].Contact.AddressFact = resp.data.AddressFact;
                    $scope.object[obj].Contact.Phone = resp.data.Phone;
                    $scope.object[obj].Contact.Phone2 = resp.data.Phone2;
                    $scope.object[obj].Contact.Email = resp.data.Email;
                    $scope.object[obj].Contact.BossLastName = resp.data.BossLastName;
                    $scope.object[obj].Contact.BossFirstName = resp.data.BossFirstName;
                    $scope.object[obj].Contact.BossMiddleName = resp.data.BossMiddleName;
                    $scope.object[obj].Contact.BossPosition = resp.data.BossPosition;
                    $scope.object[obj].Contact.BossPositionKz = resp.data.BossPositionKz;
                    $scope.object[obj].Contact.BossDocType = resp.data.BossDocType;
                    $scope.object[obj].Contact.IsHasBossDocNumber = resp.data.IsHasBossDocNumber;
                    $scope.object[obj].Contact.BossDocNumber = resp.data.BossDocNumber;
                    $scope.object[obj].Contact.BossDocCreatedDate = getDate(resp.data.BossDocCreatedDate);
                    $scope.object[obj].Contact.BossDocEndDate = getDate(resp.data.BossDocEndDate);
                    $scope.object[obj].Contact.BossDocUnlimited = resp.data.BossDocUnlimited;
                    $scope.object[obj].Contact.SignerIsBoss = resp.data.SignerIsBoss;
                    $scope.object[obj].Contact.SignLastName = resp.data.SignLastName;
                    $scope.object[obj].Contact.SignFirstName = resp.data.SignFirstName;
                    $scope.object[obj].Contact.SignMiddleName = resp.data.SignMiddleName;
                    $scope.object[obj].Contact.SignPosition = resp.data.SignPosition;
                    $scope.object[obj].Contact.SignPositionKz = resp.data.SignPositionKz;
                    $scope.object[obj].Contact.SignDocType = resp.data.SignDocType;
                    $scope.object[obj].Contact.IsHasSignDocNumber = resp.data.IsHasSignDocNumber;
                    $scope.object[obj].Contact.SignDocNumber = resp.data.SignDocNumber;
                    $scope.object[obj].Contact.SignDocCreatedDate = getDate(resp.data.SignDocCreatedDate);
                    $scope.object[obj].Contact.SignDocEndDate = getDate(resp.data.SignDocEndDate);
                    $scope.object[obj].Contact.SignDocUnlimited = resp.data.SignDocUnlimited;
                    $scope.object[obj].Contact.BankIik = resp.data.BankIik;
                    $scope.object[obj].Contact.BankBik = resp.data.BankBik;
                    $scope.object[obj].Contact.CurrencyId = resp.data.CurrencyId;
                    $scope.object[obj].Contact.BankNameRu = resp.data.BankNameRu;
                    $scope.object[obj].Contact.BankNameKz = resp.data.BankNameKz;
                    $scope.object[obj].Contact.BankId = resp.data.BankId;
                    //$scope.saveDeclarantId(resp.data.Id);
                    //$scope.editProject();
                    debugger;
                    switch (obj) {
                        case 'Manufactur':
                            $scope.showContactInformationManufactur = false;//true;
                            $scope.manufacturNotFound = false;
                            break;
                        case 'Declarant':
                            $scope.showContactInformationDeclarant = false;//true;
                            $scope.declarantNotFound = false;
                            break;
                        case 'Payer':
                            $scope.showContactInformationPayer = false;//true;
                            $scope.payerNotFound = false;
                            break;
                    default:
                    }
                    
                }
                else {
                    switch (obj) {
                        case 'Manufactur':
                            $scope.manufacturNotFound = true;
                            $scope.addManufacturDisabled = false;
                            //$scope.declarant.Id = null;
                            break;
                        case 'Declarant':
                            $scope.declarantNotFound = true;
                            $scope.addDeclarantDisabled = false;
                            break;
                        case 'Payer':
                            $scope.payerNotFound = true;
                            $scope.addPayerDisabled = false;
                            break;
                    default:
                    }
                   
                }
            }, function (response) {

            });
        }
    }

    $scope.validatePhone = function () {
        if (!$scope.contractCreateForm.Phone.$valid && $scope.object.Phone && $scope.object.Phone.length > 0) {
            var message = "Поле должно содержать числовое значение и знаки \"+\", \",\", \"(\", \")\"";

            if ($scope.flag == true) {
                return;
            }

            $scope.flag = true;
            var title = "Предупреждение";
            $('<div></div>').html(message).dialog({
                title: title,
                resizable: false,
                modal: true,
                buttons: {
                    'Ok': function () {
                        $(this).dialog('close');
                        $scope.flag = false;
                    }
                },
                close: function () {
                    $scope.flag = false;
                },
                dialogClass: 'no-close alert-dialog'
            });
        }
    }

    $scope.validate = function () {
        debugger;
        var valid = $scope.ContractForm.$valid;
        var errors = $scope.ContractForm.$error;
        if (!valid)
            alert('Заполните все обязательные поля');
        return valid;
    }

    $scope.viewContract = function (id) {
        debugger;
        var modalInstance = $uibModal.open({
            templateUrl: '/EMPContract/ContractTemplate?Id=' + id + "&Url=" + "PrintContractReport",
            controller: ModalRegisterInstanceCtrl
        });
    };

    $scope.doSign = function () {
        var id = $scope.object.Id;
        if (id) {

            var funcSign = function signData() {
                debugger;
                $.blockUI({ message: '<h1><img src="../../Content/css/plugins/slick/ajax-loader.gif"/> Выполняется подпись...</h1>', css: { opacity: 1 } });
                signXmlCall(function () {
                    $http({
                        url: '/EMPContract/SignContract',
                        method: 'POST',
                        data: JSON.stringify({ contractId: id, signedData: $("#Certificate").val() })
                    }).success(function () {
                        $("#btnBackToList").click();
                    }).error(function () {
                        alert("Возникла ошибка при подписании договора");
                        $.unblockUI();
                    });
                });
            };

            startSign('/EMPContract/SignData', id, funcSign);
        }
    }

    $scope.showRegister = false;
    $scope.changeContractType = function () {
        var cType = $scope.ContractTypes.find(item => item.Id === $scope.object.ContractType);
        if (cType.Code === "2" || cType.Code === "3") {
            $scope.showRegister = true;
        } else {
            $scope.showRegister = false;
        }
    }

    $scope.clearSearchBtn = function() {
        $scope.object.RegNumber = null;
        $scope.object.TradeName = null;
        $scope.object.ServiceRegisterResults.length = 0;
        $scope.resultRegisterSearch = false;
    }

    $scope.searchBtn = function () {
        $scope.searchDrugWorking = true;

        var dRegNumber = $scope.object.RegNumber;
        var dTradeNumber = $scope.object.TradeName;
        $http({
            method: "GET",
            url: "/EMPContract/SearchDrug",
            params: {
                drugRegNumber: dRegNumber,
                drugTradeName: dTradeNumber
            }
        }).success(function (result) {
            debugger;
            if (result) {
                $scope.resultRegisterSearch = true;
                $scope.object.ServiceRegisterResults.length = 0;
                $scope.object.ServiceRegisterResults.push.apply($scope.object.ServiceRegisterResults, result);
                $scope.searchDrugWorking = false;
            } else {
                $scope.resultRegisterSearch = false;
                $scope.searchDrugWorking = false;
            }
        });
    }

    $scope.showSelectRow = function (idSelectedRow) {
        var srr = $scope.object.ServiceRegisterResults.find(item => item.Id === idSelectedRow);
        $scope.object.MedicalDeviceName = srr.RegNameRu;
        $scope.object.MedicalDeviceNameKz = srr.RegNameKz;
        $scope.object.RegisterManufacturName = srr.RegProducerNameRu;
        $scope.object.RegisterManufacturCountry = srr.RegCounrtyNameRu;
    }
}

function ModalRegisterInstanceCtrl($scope, $uibModalInstance) {
    debugger;
    $scope.ok = function () {
        $uibModalInstance.close();
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
}

function loadEMPContractDocumentType($scope, $http) {
    var name = "EMPContractDocumentTypes";
    $http({
        method: "GET",
        url: "/EMPContract/GetEMPContractDocumentType",
        data: "JSON"
    }).success(function (result) {
        $scope[name] = result;
    });
}

function loadCurrency($scope, $http) {
    $http({
        method: "GET",
        url: "/EMPContract/GetCurrency",
        data: "JSON"
    }).success(function (result) {
        $scope.Currency = result;
    });
}

function loadContractTypes($scope, $http) {
    $http({
        method: "GET",
        url: "/EMPContract/GetContractTypes",
        data: "JSON"
    }).success(function (result) {
        debugger;
        if ($scope.object.ContractScope === "national") {
            $scope.ContractTypes = result;
        } else {
            result.forEach(function (element, index) {
                debugger;
                if(element.Code === '2'){
                    result.splice(index, 1);
                }
            });
            $scope.ContractTypes = result;
        }
    });
}

function loadHolderTypes($scope, $http, contractScope) {
    debugger;
    $http({
        method: "GET",
        url: "/EMPContract/GetHolderTypes",
        params: {
            contractScope: contractScope
        }
    }).success(function (result) {
        $scope.HolderType = result;
    });
}

function loadExpertOrganizations($scope, $http) {
    $http({
        method: "GET",
        url: "/EMPContract/GetExpertOrganizations",
        data: "JSON"
    }).success(function (result) {
        $scope.ExpertOrganizations = result;
    });
}

function loadBanks($scope, $http) {
    $http({
        method: "GET",
        url: "/EMPContract/GetBanks",
        data: "JSON"
    }).success(function (result) {
        $scope.Bank = result;
    });
}

function loadServiceType($scope, $http, contractScope) {
    $http({
        method: "GET",
        url: "/EMPContract/GetServiceType",
        params: {
            contractScope: contractScope
        }
    }).success(function(result) {
        $scope.ServiceTypes = result;
    });
}

function loadChangeType($scope, $http) {
    $http({
        method: "GET",
        url: "/EMPContract/GetChangeType",
        data: "JSON"
    }).success(function (result) {
        $scope.ChangeTypes = result;
    });
}


angular
    .module('app')
    .controller('empContractForm', ['$scope', '$http', 'DTColumnBuilder', '$interval', '$uibModal', '$window', empContractForm])