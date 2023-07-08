import {Component} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CommitObject} from "@angular/cli/lib/config/workspace-schema";
import {DEBUG} from "@angular/compiler-cli/src/ngtsc/logging/src/console_logger";
import { HttpErrorResponse} from "@angular/common/http";
import {CommonModule} from "@angular/common";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
      public values: any[] = [];

  constructor(private http: HttpClient) { }
  ngOnInit () {
    this.http.get('http://127.0.0.1:5000/ShortUrl/GetUrls').subscribe(
        result => {
          console.log(result);
          this.values = result as any[];
        },
        (err: HttpErrorResponse) => {
            console.log (err.message);
        }
        );
  }
}
