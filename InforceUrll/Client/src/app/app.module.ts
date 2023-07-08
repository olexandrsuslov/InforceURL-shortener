import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from "@angular/common/http";
import {CommonModule} from "@angular/common";
import {BrowserTestingModule} from "@angular/platform-browser/testing";


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CommonModule,
    BrowserTestingModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
