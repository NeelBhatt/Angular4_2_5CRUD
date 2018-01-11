import { Component, OnInit } from '@angular/core';
import 'rxjs/add/operator/catch';
import { EmployeeService } from "./employeeService";
import { Observable } from "rxjs/Observable";
import { Employee } from "./employeeService"

@Component({
    selector: 'employee',
    providers: [EmployeeService],
    templateUrl: './employee.component.html'
})
export class EmployeeComponent implements OnInit {
    public employeeList: Observable<Employee[]>;

    showEditor = true;
    myName: string;
    employee: Employee;
    constructor(private dataService: EmployeeService) {
        this.employee = new Employee();
    }
    // if you want to debug info  just uncomment the console.log lines.  
    ngOnInit() {
        //    console.log("in ngOnInit");  
        this.employeeList = this.dataService.employeeList;
        this.dataService.getAll();
    }
    public addEmployee(item: Employee) {        
        let employeeId = this.dataService.addEmployee(this.employee);
    }
    public updateEmployee(item: Employee) {        
        this.dataService.updateEmployee(item);       
    }
    public deleteEmployee(employeeId: number) {
        this.dataService.removeItem(employeeId);
    }
}  