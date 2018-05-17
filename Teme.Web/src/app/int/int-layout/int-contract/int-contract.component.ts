import {Component, OnInit, ViewChild, ViewEncapsulation} from '@angular/core';
import {IntContractBtnComponent} from "./int-contract-btn/int-contract-btn.component";
import {Menu} from "../../../shared/menu/menu.model";
import {RefIntContractService} from './int-contract-service';
import {LocalDataSource} from 'ng2-smart-table';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-int-contract',
  templateUrl: './int-contract.component.html',
  styleUrls: ['./int-contract.component.scss'],
  encapsulation: ViewEncapsulation.None,
  providers: [RefIntContractService],
})
export class IntContractComponent implements OnInit {
  public menuItems: Array<any>;
  public contractList=[];
  _selectRow:string;
  _workflowId:string;
  _statusContract:string;
  public isSelectRow:boolean=true;
  public data ;
  //   = [{
  //   number: '1321 #1223',
  //   contractAddition: 'sdfg',
  //   contractType: 'asd',
  //   type: 'sdac',
  //   serviceType: 'sdac',
  //   sendDate: 'sdac',
  //   legal: 'sdac',
  //   GV: 'sdac',
  //   DEF: 'sdac',
  //   declarant: 'sdac',
  //   productType: 'sdac',
  //   name: 'sdac',
  //   startDate: 'sdac',
  //   endDate: 'sdac'
  // }];

  @ViewChild(IntContractBtnComponent) intCntBtnChild:IntContractBtnComponent;

  public table1Settings = {
    selectMode: 'single',  //single|multi
    hideHeader: false,
    hideSubHeader: false,
    actions: false,
    noDataMessage: 'Нет данных',
    columns: {
      number: {
        title: 'Номер',
        type: 'custom',
        renderComponent: IntContractBtnComponent,
        onComponentInitFunction(instance) {
          instance.save.subscribe(row => {
            alert(`${row.name} saved!`)
          });
        }
      },
      contractAddition: {
        title: 'Договор или доп соглашение',
        type: 'string',
        hidden:true,
      },
      contractType: {
        title: 'Тип договора(Тип соглашения)',
        type: 'string'
      },
      type: {
        title: 'Тип',
        type: 'string'
      },
      serviceType: {
        title: 'Тип услуги',
        type: 'string'
      },
      sendDate: {
        title: 'Дата отправки',
        type: 'string'
      },
      legal: {
        title: 'Согласование юридической части',
        type: 'string'
      },
      GV: {
        title: 'Согласование стоимости(ГВ МРД МИ)',
        type: 'string'
      },
      DEF: {
        title: 'Согласование стоимости(ДЭФ)',
        type: 'string'
      },
      declarant: {
        title: 'Заявитель',
        type: 'string'
      },
      productType: {
        title: 'Вид продукции',
        type: 'string'
      },
      name: {
        title: 'Наиме-\nнование',
        type: 'string'
      },
      startDate: {
        title: 'Дата начала',
        type: 'string'
      },
      endDate: {
        title: 'Дата окончания',
        type: 'string'
      }
    },
    pager: {
      display: true,
      perPage: 10
    }
  };

  constructor(private refIntService: RefIntContractService, private route: ActivatedRoute) {

  }

  ngOnInit() {

    this.route.params.subscribe(params => {  this._statusContract = params.status;
      console.log(this._statusContract)
      this.GetListContracts(this._statusContract);});
    this.menuItems = this.getMenuItems();

  }

  public onDeleteConfirm(event): void {
    if (window.confirm('Are you sure you want to delete?')) {
      event.confirm.resolve();
    } else {
      event.confirm.reject();
    }
  }

  public onRowSelect(event) {

  }

  public onUserRowSelect(event) {
    this.isSelectRow = false;
    this._selectRow = event.data.number;
    this.getContractById();
  }

  public onRowHover(event) {
    //console.log(event);
  }

  getMenuItems() {
    return [
      new Menu (1, 'Не распределенные', '/int/spa/contracts/menu/onDistribution', null, 'tachometer', null, false, 0),
      new Menu (2, 'В работе', '/int/spa/contracts/menu/inWork', null, 'users', null, false, 0),
      new Menu (3, 'На карректировке', '/int/spa/contracts/menu/onAdjustment', null, 'laptop', null, true, 0),
      new Menu (4, 'Требует согдасования', '/int/spa/contracts/menu/requiredRegistration', null, 'keyboard-o', null, false, 3),
      new Menu (5, 'Согласованные', '/int/spa/contracts/menu/onAgreement', null, 'address-card-o', null, false, 3),
      new Menu (6, 'Не согласованные', '/int/spa/contracts/menu/onDistribution', null, 'creative-commons', null, false, 3),
      new Menu (7, 'Активные', '/int/spa/contracts/menu/active', null, 'font-awesome', null, false, 3),
      new Menu (8, 'Истекшие', '/int/spa/contracts/menu/expired', null, 'th-list', null, false, 3),
      new Menu (9, 'Все', '/int/spa/contracts/menu/all', null, 'object-group', null, false, 3),
    ]
  }

  GetListContracts(status)
  {
    this.refIntService.GetListContracts(status)
      .toPromise()
      .then(response => {
        console.log(response);
        this.contractList.push(response);
        this.loadContractData();

        console.log(this.contractList);
      })
      .catch(err => {
          console.error(err);
        }
      )

  }

  loadContractData()
  {
    this.data=null;
    this.data =  new LocalDataSource();
    console.log('contractList', this.contractList);
    this.contractList.forEach(condata => {
      condata.forEach(con => {
        this.data.add({
          number: con.id,
          contractAddition: con.number,
          contractType: con.contractScope,
          type: con.contractType,
          serviceType: 'test',//condata.serviceTypes.nameRu,
          sendDate: 'test',
          legal: 'test',
          GV: 'test',
          DEF: 'test',
          declarant: con.declarantNameRu,
          productType: 'test',
          name: 'test',
          startDate: con.startdate,
          endDate: 'test'
        })})
      }
    )
    this.data.refresh();

  }

  getContractById()
  {
    let responseData;
    console.log(this._selectRow);
    this.refIntService.GetContractById(this._selectRow)
      .toPromise()
      .then(response => {
        responseData = response;
        this._workflowId = responseData.workflowId;
        console.log(response);


      })
      .catch(err => {
          console.error(err);
        }
      )

  }

  DistributionByExecutors(selectUser)
  {
    let responseData;
    this.refIntService.DistributionByExecutors(this._workflowId, selectUser)
      .toPromise()
      .then(response => {
        responseData = response;
        this._workflowId = responseData.workflowId;


      })
      .catch(err => {
          console.error(err);
        }
      )
  }

  SelectExecuter(val)
  {
    this.DistributionByExecutors(val);
  }

}
