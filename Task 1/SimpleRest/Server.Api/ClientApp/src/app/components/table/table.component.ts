import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatSelectChange } from '@angular/material/select';
import { MatTableDataSource, MatTableDataSourcePageEvent } from '@angular/material/table';
import { Subscription } from 'rxjs';
import MyObjectResponseModel from 'src/app/api/response-models/my-object-response.model';
import { MyObjectService } from 'src/app/services/my-object.service';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit, OnDestroy {
  private dataSubscription: Subscription | undefined;
  private staticDataSubscription: Subscription | undefined;

  dataSource: MatTableDataSource<MyObjectResponseModel> = new MatTableDataSource<MyObjectResponseModel>();
  years: number[] = [];
  currentYear: number | undefined = undefined;
  currentMonth: number | undefined = undefined;

  recordsCount: number = 0;
  currentPage: number = 0;
  currentRecordsPerPage: number = 15;
  recordsPerPage: number[] = [5, 15, 25, 100];

  constructor(private myObjectService: MyObjectService) { }

  ngOnInit() {
    this.loadData(this.currentRecordsPerPage, 0);
    this.loadStaticData();
  }

  ngOnDestroy() {
    this.dataSubscription?.unsubscribe();
    this.staticDataSubscription?.unsubscribe();
  }

  onYearChange(event: MatSelectChange) {
    this.currentYear = event.value;
    this.currentPage = 0;
    this.loadData(this.currentRecordsPerPage, 0);
  }

  onMonthChange(event: MatSelectChange) {
    this.currentMonth = event.value;
    this.currentPage = 0;
    this.loadData(this.currentRecordsPerPage, 0);
  }

  handlePageEvent(event: MatTableDataSourcePageEvent) {
    this.currentRecordsPerPage = event.pageSize;
    this.currentPage = event.pageIndex;
    this.loadData(event.pageSize, event.pageSize * event.pageIndex);
  }

  loadData(take: number, offset: number) {
    this.dataSubscription = this.myObjectService
      .getMyObjectData({ take, offset })
      .subscribe(r => {
        this.dataSource = new MatTableDataSource<MyObjectResponseModel>(r);
      });
  }

  loadStaticData() {
    this.staticDataSubscription = this.myObjectService
      .getMyObjectStaticData()
      .subscribe(r => {
        this.recordsCount = r;
      });
  }

  displayedColumns: string[] = ['index', 'id', 'code', 'value'];
}
