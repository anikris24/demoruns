import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TimeControlModule } from '@aveva/shared/lib/time-control';

import { AppComponent } from './app.component';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    TimeControlModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
