import { HttpErrorResponse } from '@angular/common/http';
import { Component, ViewEncapsulation } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { MyObjectService } from 'src/app/services/my-object.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class HomeComponent {
  constructor(private myObjectService: MyObjectService) { }

  inputObject: string = `[
    { "1": "value 1" },
    { "2": "value 3" },
    { "3": "value 1" },
    { "4": "value 5" },
    { "1": "value 1" },
    { "8": "value 7" },
    { "5": "value 1" },
    { "7": "value 9" },
    { "2": "value 11" },
    { "12": "value 12" },
    { "12": "value 13" },
    { "13": "value 14" },
    { "14": "value 15" },
    { "12": "value 16" },
    { "13": "value 17" },
    { "12": "value 18" },
    { "11": "value 19" },
    { "10": "value 100" },
  ]`;
  errorMessage: boolean = false;
  successMessage: boolean = false;

  sendInput() {
    this.errorMessage = false;
    this.successMessage = false;
    this.myObjectService.addMyObjectData(`${this.inputObject}`)
      .pipe(
        catchError((a) => this.handleError(a, this))
      )
      .subscribe(() => {
        this.successMessage = true;
      });
  }

  private handleError(error: HttpErrorResponse, context: HomeComponent) {
    context.errorMessage = true;
    return throwError(() => new Error(error.message));
  }
}
