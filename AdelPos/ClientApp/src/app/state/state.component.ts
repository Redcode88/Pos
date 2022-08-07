import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { Stateservice } from './state.service';
import { stateModel } from './stateModel';
import { NgbModal,ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
@Component({
    selector: 'app-state-component',
    templateUrl: './state.component.html'
})

export class StateComponent implements OnInit{
   
constructor(private stateservice:Stateservice,private modalService: NgbModal){
}
    ngOnInit(): void {
        this.GetState_Data();
    }
//object who reserve Data of state table 
public stateData:stateModel[]

GetState_Data(){
    this.stateservice.GetStateData().subscribe(res =>{
        this.stateData = res
        console.log(res)
    })
}

private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
        return 'by pressing ESC';
      } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
        return 'by clicking on a backdrop';
      } else {
        return `with: ${reason}`;
      }
}

closeResult='';
      open(content) {
        this.modalService.open(content, {size: 'lg'}).result.then((result) => {
          this.closeResult = `Closed with: ${result}`;
        }, (reason) => {
          this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        });
      }
 @ViewChild('addEditTemp') private addEditTemp:TemplateRef<Object>;
}  