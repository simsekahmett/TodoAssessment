import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TodoAppComponent } from './todo-app/todo-app.component';
import { CreateEntryComponent } from './create-entry/create-entry.component';
import { UpdateEntryComponent } from './update-entry/update-entry.component';
import { ListEntriesComponent } from './list-entries/list-entries.component';
import { SafePipe } from './pipes/safe-pipe';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TodoAppComponent,
    CreateEntryComponent,
    UpdateEntryComponent,
    ListEntriesComponent,
    SafePipe
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'create', component: CreateEntryComponent },
      { path: 'update', component: UpdateEntryComponent },
      { path: 'list', component: ListEntriesComponent },
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent },
      { path: 'todo-app', component: TodoAppComponent }
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

