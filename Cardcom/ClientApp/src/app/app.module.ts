import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './components/app/app.component';
import { GenderPipe } from './pipes/gender.pipe';
import { ApiService } from './services/api.service';
import { HttpClientModule } from '@angular/common/http';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { HomeComponent } from './components/home/home.component';
import { PersonDetailsComponent } from './components/person-details/person-details.component';
import { AppRoutingModule } from './app-routing.module';
import { NgDatepickerModule } from 'ng2-datepicker';
import { ErrorAlertComponent } from './components/error-alert/error-alert.component';
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    GenderPipe,
    SpinnerComponent,
    HomeComponent,
    PersonDetailsComponent,
    ErrorAlertComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    NgDatepickerModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot(
      {
        positionClass: 'toast-top-center',
        tapToDismiss: true,
        progressBar: true,
        progressAnimation: 'increasing',
        maxOpened: 3,
        autoDismiss: true,
        preventDuplicates: true,
        resetTimeoutOnDuplicate: true,
        newestOnTop: false,
        timeOut: 5000,
        extendedTimeOut: 1500,
        enableHtml: true
      }),
  ],
  providers: [ApiService],
  bootstrap: [AppComponent],
  schemas: [NO_ERRORS_SCHEMA]
})
export class AppModule { }
